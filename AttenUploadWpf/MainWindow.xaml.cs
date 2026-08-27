using ATTNLIB;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AttenUploadWpf
{
    
    public partial class MainWindow : Window
    {

        public static bool IsDeviceConnected = false;
        private static string comcod = "XXXX";
        //private static string connetionString = "Data Source=202.74.240.84\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=PTL@2021$#9";
        //private static string connetionString = "Data Source=103.228.134.140;initial Catalog=PTLSPEDB;User ID=sa;Password=@ptl*1qaz`123*$#";
        //private static string connetionString = "Data Source=103.78.53.5\\mssql2k14;initial Catalog=asitinteriordbglg;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=202.0.94.61\\mssql2k14;initial Catalog=ASITINTERIORDBBH;User ID=sa;Password=@ptl*zaq1`123^^";
        //private static string connetionString = "Data Source=GLGERP\\MSSQL2K14;initial Catalog=ASITINTERIORDBGLG;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=FPLSERVER\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=@*pintech1qaz`321#";
        //private static string connetionString = "Data Source=ZDSL-01\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=ZDSL-01\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=123.200.12.115;initial Catalog=ASITINTERIORDB;User ID=sa;Password=msp@msp123";
        //private static string connetionString = "Data Source=SERVER\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=@ssure1qaz`321#";
        //private static string connetionString = "Data Source=103.41.213.58;initial Catalog=ASITINTERIORDB;User ID=sa;Password=msp@msp123";
        //private static string connetionString = "Data Source=202.0.94.92;initial Catalog=ASITINTERIORDB;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=103.228.134.140;initial Catalog=PTLSPEDB;User ID=sa;Password=@ptl@2026#";
        //private static string connetionString = "Data Source=BRIDGE-DB-01\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=BRIDGE-DB-01\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=103.23.31.79;initial Catalog=PTLSPEDB;User ID=sa;Password=@ptl*zaq1`123^^";
        //private static string connetionString = "Data Source=WIN-S2K5ABFBF99\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=@#Assure2K25#@"; //assure
        //private static string connetionString = "Data Source=103.23.31.80;initial Catalog=ASITINTERIORDB;User ID=sa;Password=@ptl*zaq1`123^^";
        //private static string connetionString = "Data Source=SERVER\\MSSQL2K14;initial Catalog=MODEL_ASITBDACCDB;User ID=sa;Password=talbhl1qaz`123";
        //private static string connetionString = "Data Source=WIN-S2K5ABFBF99\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=@#Assure2K25#@";
        //private static string connetionString = "Data Source=192.168.36.66;initial Catalog=PTLSPEDB;User ID=sa;Password=@ptl*zaq1`123^^";
        //private static string connetionString = "Data Source=BASUMATI\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=basumoti@#123erp";
        //private static string connetionString = "Data Source=103.134.90.88\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=12345";
        //private static string connetionString = "Data Source=192.168.88.9\\MSSQL2K14;initial Catalog=ASITINTERIORDBDUMMY;User ID=sa;Password=chlerp1qaz`123#";
        //private static string connetionString = "Data Source=202.4.115.195\\MSSQL2K19;initial Catalog=ASITINTERIORDB_PTLHRM;User ID=sa;Password=@ptl*1qaz321`*%$#@#$";
        //private static string connetionString = "Data Source=WIN-S2K5ABFBF99\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=@#Assure2K25#@";
        //private static string connetionString = "Data Source=BASUMATI\\MSSQL2K19;initial Catalog=ASITINTERIORDB;User ID=sa;Password=basumoti@#123erp";
        private static string connetionString = "Data Source=192.168.88.9\\MSSQL2K14;initial Catalog=ASITINTERIORDB;User ID=sa;Password=chlerp1qaz`123#1@3$";



        //public MainWindow()
        //{
        //    this.InitializeComponent();
        //    MainWindow.UploadData();
        //    this.Close();
        //}


        public MainWindow()
        {
            InitializeComponent();           
            StartUploadLoop();           
            //this.Close();

        }

        private async void StartUploadLoop()
        {
            while (true)
            {
                MainWindow.UploadData();
                await Task.Delay(TimeSpan.FromMinutes(35));
            }
        }


        private string DBConnstr()
        {
            return ConfigurationManager.ConnectionStrings["dbconnstr"].ConnectionString;
        }
        private static void UploadData()
        {
            try
            {
                MainWindow.comcod = MainWindow.GetCompCode();
                foreach (DeviceInfo deviceInfo in MainWindow.Get_Machine_IP_Address())
                    MainWindow.McDataUp(deviceInfo.portno, deviceInfo.IpAddress, deviceInfo.Mcinno);



            }


            catch (Exception ex)
            {
                Library.WriteErrorLog("Device Not Found");
            }
        }
        public static List<DeviceInfo> Get_Machine_IP_Address()
        {
            List<DeviceInfo> machineIpAddress = new List<DeviceInfo>();
            try
            {
                string str1 = "xxxxx";
                DataTable table = new GetData(MainWindow.connetionString).GetDataSetResult(new SQLParams()
                {
                    ComCod = str1,
                    ProcName = "dbo_hrm.SP_ENTRY_ATTENDENCE",
                    Segment = "GET_COMWISE_MACH_IP"
                }).Tables[0];
                //for (int index = 0; index < table.Rows.Count; ++index)
                //{


                for (int index = table.Rows.Count - 1; index >= 0; --index)
                {
                    string str2 = table.Rows[index]["machno"].ToString();
                    string str3 = table.Rows[index]["ipaddress"].ToString();
                    int int32 = Convert.ToInt32(table.Rows[index]["port"]);
                    machineIpAddress.Add(new DeviceInfo()
                    {
                        portno = int32,
                        IpAddress = str3,
                        Mcinno = str2
                    });
                }

            }
            catch (Exception ex)
            {
                Library.WriteErrorLog("Data Not Found." + ex.Message);
            }
            return machineIpAddress;
        }
        public static string GetCompCode()
        {
            string str = "xxxxx";
            DataSet dataSetResult = new GetData(MainWindow.connetionString).GetDataSetResult(new SQLParams()
            {
                ComCod = str,
                ProcName = "dbo_hrm.SP_ENTRY_ATTENDENCE",
                Segment = "GETCOMCODE"
            });
            if (dataSetResult == null)
                Library.WriteErrorLog("Data Access Error: ");
            return dataSetResult.Tables[0].Rows[0]["comcod"].ToString();

        }
        public static void McDataUp(int port, string ip, string mcno)
        {
            try
            {
                DeviceManipulator deviceManipulator = new DeviceManipulator();
                ZkemClient objZkeeper = new ZkemClient(new Action<object, string>(MainWindow.RaiseDeviceEvent));
             
                MainWindow.IsDeviceConnected = objZkeeper.Connect_Net(ip, port);

               

                Library.WriteErrorLog("Device: " + mcno + "  " + MainWindow.IsDeviceConnected.ToString());

                DataSet dataSet = new DataSet();
                dataSet.DataSetName = "ds1";

                DataTable table = new DataTable();
                table.TableName = "tbl1";
                table.Columns.Add("MachineNumber", typeof(int));
                table.Columns.Add("IndRegID", typeof(int));
                table.Columns.Add("DateTimeRecord", typeof(string));
                table.Columns.Add("DateOnlyRecord", typeof(DateTime));
               
                List<MachineInfo> list = deviceManipulator.GetLogData(objZkeeper, int.Parse(mcno)).ToList<MachineInfo>();                
                DateTime stdate = DateTime.Today.AddDays(-3);
                DateTime endate = DateTime.Today.AddDays(1).AddTicks(-1);
                // Filter logs based on date range
                List<MachineInfo> all = list.FindAll(l => l.TimeOnlyRecord.Date >= stdate.Date && l.TimeOnlyRecord.Date <= endate.Date);

                if (all != null && all.Count > 0)
                {
                    foreach (MachineInfo machineInfo in all)
                    {
                       
                        table.Rows.Add(
                            Convert.ToInt32(machineInfo.MachineNumber),
                            Convert.ToInt32(machineInfo.IndRegID),
                            machineInfo.DateTimeRecord,
                            machineInfo.DateOnlyRecord);
                    }

          
                    DataView defaultView = table.DefaultView;

                    string stdateStr = stdate.ToString("yyyy-MM-dd HH:mm:ss");
                    string endateStr = endate.ToString("yyyy-MM-dd HH:mm:ss");

                    defaultView.RowFilter = $"DateOnlyRecord >= '#{stdateStr}#' AND DateOnlyRecord <= '#{endateStr}#'";
                    
                    dataSet.Merge(defaultView.ToTable());            
                    new GetData(MainWindow.connetionString).GetDataSetResult(new SQLParams()
                    {                      
                                               
                        ComCod = MainWindow.comcod,
                        ProcName = "dbo_hrm.SP_ENTRY_ATTENDENCE",
                        Segment = "INSERTDATAFRMATTEN",
                        var01 = endate.ToString("dd-MMM-yyyy"),
                        var02 = stdate.ToString("dd-MMM-yyyy"),
                        var03 = mcno,
                        varXml01 = dataSet



                    });

                    Library.WriteErrorLog("Device: " + mcno + "  " + dataSet.Tables[0].Rows.Count.ToString());
                }
                else
                {
                    Library.WriteErrorLog("Device: " + mcno + "  No data found in date range.");
                }
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog("Device: " + mcno + "  " + ex.Message);
            }
        }
        private static void RaiseDeviceEvent(object sender, string actionType)
        {
            if (!(actionType == "Disconnected"))
                return;
            Library.WriteErrorLog("Connect");
        }
  
    }
}
