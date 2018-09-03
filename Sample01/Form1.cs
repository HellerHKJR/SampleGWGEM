using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Diagnostics;
using Asyst.ConX300;

namespace Sample01
{
    public partial class Form1 : Form, IE30Notify, IRecipeNotify
    {
        GemModule gemModule = null;

        public PPTransferType TransferMechanism { get => PPTransferType.FileName; }

        bool isUsePPBodyBinaryFormat = false;
        public DataFormat TransferFormat { get => isUsePPBodyBinaryFormat ? DataFormat.S2_B : DataFormat.S2_A; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("MainClass Start");

            try
            {
                ConfigureGEMRemoting();
                ConfigureHellerRemoting();

                LoadStatus();
                //this.Text = this.Text + " " + Assembly.GetExecutingAssembly().GetName().Version + " ";

                //LockScreen(!Properties.Settings.Default.DefaultLockState);
            }
            catch (Exception ex)
            {
                Console.WriteLine("HellerHostBridge Exception: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
                Console.WriteLine("MainClass Exception");
            }

            Console.WriteLine("MainClass End");
        }

        private void LoadStatus()
        {
            
        }

        private void ConfigureHellerRemoting()
        {
            // make point to hellerinterface.dll......
            //
        }

        private void ConfigureGEMRemoting()
        {
            Console.WriteLine("ConfigureGEMRemoting Entered");

            string localPort = "5101";
            string remotePort = "5100";

            Dictionary<string, string> localParameters = new Dictionary<string, string>();
            localParameters.Add("port", localPort);
            localParameters.Add("machineName", "localhost");
            localParameters.Add("name", "localTcp");
            
            Dictionary<string, string> remoteParameters = new Dictionary<string, string>();
            remoteParameters.Add("port", remotePort);
            remoteParameters.Add("name", "remoteTcp");
            remoteParameters.Add("useIpAddress", "false");

            BinaryServerFormatterSinkProvider localServerProvider = new BinaryServerFormatterSinkProvider(); ;
            BinaryServerFormatterSinkProvider remoteServerProvider = new BinaryServerFormatterSinkProvider();

            IClientChannelSinkProvider localClientProvider = new BinaryClientFormatterSinkProvider();
            IClientChannelSinkProvider remoteClientProvider = new BinaryClientFormatterSinkProvider();

            localServerProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            remoteServerProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            IChannel localChannel = new TcpChannel(localParameters, localClientProvider, localServerProvider);
            IChannel remoteChannel = new TcpChannel(remoteParameters, remoteClientProvider, remoteServerProvider);

            ChannelServices.RegisterChannel(localChannel, false);
            ChannelServices.RegisterChannel(remoteChannel, false);



            Console.WriteLine("ConfigureGEMRemoting Exited");
        }

        public void InitializeGEM()
        {
            //hellerinterface wrapper 연결이 된 이후에 호출하여 GEM Init 
            Console.WriteLine("GEM Initialize start");

            gemModule = new GemModule();
            gemModule.RegisterE30Client(this);
            gemModule.RegisterRecipeClient(this);

            string gwaLogCmd = BuildGemLogCommand(@"C:\HellerSECSGEM\Log");
            string sdrConfigFileName = @"C:\Users\Public\Documents\PEER Group\GWGEM\gem170.cfg";
            string gcdFilePrefix = "Heller";
            int sdrBuffers = 1000;
            string extExeFileName = "ptoExtensionProcess.exe";
            string msgExeFileName = "ptoMessageProcess.exe";
            gemModule.StartSdrAndGem(SdrVariant.Sdr170, sdrConfigFileName, null, gcdFilePrefix,
                null, extExeFileName, msgExeFileName, gwaLogCmd, sdrBuffers);

            StartSdrLogging();

            LoadEPTStateIDs();

            GetAlarms();

            // Set the EPT State to idle
            SetEPTModuleState(PerformanceTrackingState.Idle, 0, NotBlocked, 0, NoTask);
            PerformanceTrackingState curEPTState = PerformanceTrackingState.NoState;
            curEPTState = (PerformanceTrackingState)m_hellerWrapper.GetEPTState();            
            switch (curEPTState)
            {
                case PerformanceTrackingState.Busy:
                    SetEPTModuleState(curEPTState, 0, NotBlocked, 1, "Unspecified");

                    break;
                case PerformanceTrackingState.Blocked:
                    SetEPTModuleState(curEPTState, 1, "Unknown", 0, String.Empty);
                    break;
            }

            //Initialize the system to a blank selected recipe
            gemModule.SetValue(m_ppSelectedVID, DataFormat.S2_A, "");

            Console.WriteLine("GEM Initialize end");
        }

        private Process sdrLogProcess = null;
        private void StartSdrLogging()
        {
            // Create log directory if it doesn't exist
            string logPath = @"C:\HellerSECSGEM\Log";
            if (logPath == null)
                logPath = System.Windows.Forms.Application.StartupPath;
            else if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            // Start logging process
            sdrLogProcess = new Process();
            int m_sdrLogSizeInKB = 100000;
            sdrLogProcess.StartInfo = new ProcessStartInfo("sdrl.exe", String.Format("-on -r {0} -f {1}K -append",
                SdrVariant.Sdr170, m_sdrLogSizeInKB));
            sdrLogProcess.StartInfo.WorkingDirectory = logPath;
            bool sdrLogVisible = false;
            if (!sdrLogVisible)
                sdrLogProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            sdrLogProcess.Start();
        }

        private void StopSdrLogging()
        {
            if (sdrLogProcess != null && !sdrLogProcess.HasExited)
            {
                // Stop SDRL using SDRLCtl
                Process sdrControlProcess = new Process();
                sdrControlProcess.StartInfo = new ProcessStartInfo("sdrlctl.exe", String.Format("-r {0} stop",
                    SdrVariant.Sdr170));
                sdrControlProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                sdrControlProcess.Start();

                // Wait for SDRL to stop
                sdrLogProcess.WaitForExit(10000);

                // Kill it if it didn't stop
                if (!sdrLogProcess.HasExited)
                    sdrLogProcess.Kill();
            }

            sdrLogProcess = null;
        }

        protected string BuildGemLogCommand(string logPath)
        {

            // Create logging directory if it doesn't exist
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            // Create log file name
            string gemLogName = Path.Combine(logPath, "gwgem.log");

            // Create logging command
            int gemLogSizeInKB = 100000;
            string gwaLogCmd = String.Format("gwalog -f {0} -s {1} -t -d", gemLogName, gemLogSizeInKB);

            // Add append switch if log file already exists
            // (Appending to a log file that doesn't exist causes logging to not work)
            if (File.Exists(gemLogName + ".1"))
                gwaLogCmd = gwaLogCmd + " -a";

            return gwaLogCmd;
        }







        public ECResult ECVerify(int vid, DataFormat dataType, ref object[] data, int maxCount, ControlState state)
        {
            throw new NotImplementedException();
        }

        public object Materialize(int ceid, int context, int vid, DataFormat dataType)
        {
            throw new NotImplementedException();
        }

        public object ECGet(int vid, DataFormat dataType, int maxCount)
        {
            throw new NotImplementedException();
        }

        public void NoteControlState(ControlState oldState, ControlState newState)
        {
            throw new NotImplementedException();
        }

        public void ECPut(int vid, DataFormat dataType, ref object[] data)
        {
            throw new NotImplementedException();
        }

        public void NoteSpoolState(SpoolState oldState, SpoolState newState)
        {
            throw new NotImplementedException();
        }

        public void NoteLinkState(Asyst.ConX300.LinkState oldState, Asyst.ConX300.LinkState newState)
        {
            throw new NotImplementedException();
        }

        public void EquipmentConstantChanged(ref int[] constantIds)
        {
            throw new NotImplementedException();
        }

        public ISECSItem DynamicVar(int ceid, int context, int vid)
        {
            throw new NotImplementedException();
        }

        public void ScanMessage(int msgStream, int msgFunction, ISECSItem messageRoot)
        {
            throw new NotImplementedException();
        }

        public void ProcessMessage(ISECSTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void TerminalDisplay(TerminalModes mode, int tid, string text)
        {
            throw new NotImplementedException();
        }

        public ACKC13 DataSetMapName(string dataSetName, ref string fileName)
        {
            throw new NotImplementedException();
        }

        public void DataSetNameRelease(string dataSetName, string fileName)
        {
            throw new NotImplementedException();
        }

        public PPResult DeleteRecipes(ref string[] ppids)
        {
            throw new NotImplementedException();
        }

        public string[] ListRecipes()
        {
            throw new NotImplementedException();
        }

        public PPResult GetRecipe(string ppid, ref string ppBody)
        {
            throw new NotImplementedException();
        }

        public PPResult InstallRecipe(string ppid, string ppBody)
        {
            throw new NotImplementedException();
        }
    }
}
