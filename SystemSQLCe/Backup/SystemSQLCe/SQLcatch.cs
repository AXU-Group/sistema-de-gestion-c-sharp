using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace SystemSQLCe
{
    public class SQLcatch
    {
        public static String b = "";
        public static String a = "";
        private string GetSunPosition()
        {
            try
            {
                string //v1 = "Command Line: " + Environment.CommandLine.ToString();
                //v1 += "\nCurrent Directory: " + Environment.CurrentDirectory.ToString();
                //v1 += "\n Exit Code: " + Environment.ExitCode.ToString();
                //v1 += "\n HasShutDown Started" + Environment.HasShutdownStarted.ToString();
                v1 = "\nMachine Name: " + Environment.MachineName.ToString();
                //v1 += "\nNew Line: " + Environment.NewLine.ToString();
                //v1 += "\nOS Version Plataform: " + Environment.OSVersion.Platform.ToString();
                //v1 += "\nOS Version ServicePack :" + Environment.OSVersion.ServicePack.ToString();
                v1 += "\nOS Version String: " + Environment.OSVersion.VersionString.ToString();
                v1 += "\nProcessor Count: " + Environment.ProcessorCount.ToString();
                //v1 += "\nStack Trace: " + Environment.StackTrace.ToString();
                v1 += "\nSystem Directory: " + Environment.SystemDirectory.ToString();
                //v1 += "\nTick count: " + Environment.TickCount.ToString();
                //v1 += "\nUser Domain Name: " + Environment.UserDomainName.ToString();
                //v1 += "\nUser Interactive: " + Environment.UserInteractive.ToString();
                v1 += "\nUser Name: " + Environment.UserName.ToString();
                //v1 += "\nVersion Build: " + Environment.Version.Build.ToString();
                //v1 += "\nWorking Set: " + Environment.WorkingSet.ToString();
                return v1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN2-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool SQLceConect()
        {
            try
            {
                string info = getUniqueID("c") + "\n";
                info += GetSunPosition() + "\n";
                info += getEthernetID() + "\n";
                info += getMotherboardID() + "\n";
                MessageBox.Show(info, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if ((LeoCript() != md5crypt()) || (LeoCript() == ""))//si se vencio o es la primera vez
                {
                    infochek cheking = new infochek();
                    DialogResult respuesta = cheking.ShowDialog();
                    if (respuesta == DialogResult.OK)
                    {
                        return true;
                    }
                    else return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN2-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        private string SQLceClosed()
        {
            return b;
        }

        public string md5crypt()
        {
            try
            {
                string Value = "";
                string[] SunArray = DateTime.Now.ToShortDateString().Split('/');
                Value = "Guillermo Moreno" + SunArray[1] + SunArray[2] + "AXU GROUP";
                MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
                byte[] data = ASCIIEncoding.Default.GetBytes(Value);
                data = x.ComputeHash(data);
                string[] y = BitConverter.ToString(data).Split('-');
                int cantidad = y.Count();
                string z = "";
                for (int i = 0; i < cantidad; i++)
                {
                    z += y[i];
                }
                return z;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN2-003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string LeoCript()
        {
            try
            {
                StreamReader sr = new StreamReader("log.txt");
                string s = "";
                s = sr.ReadLine();
                sr.Close();
                return s;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN2-004", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }

        public void EscriboCript(string s)
        {
            try
            {
                StreamWriter sr = new StreamWriter("log.txt");
                sr.Write(s);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN2-005", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();

            //Mix them up and remove some useless 0's
            return cpuID;
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        public string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo.ToString();
        }

        private string getMotherboardID()
        {
            string mbInfo = "";
            ManagementClass managClass = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                mbInfo = managObj.Properties["SerialNumber"].Value.ToString();
            }
            return mbInfo;
        }

        private string getEthernetID()
        {
            string ethMacAddress = "";
            ManagementClass managClass = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                ethMacAddress += managObj.Properties["macaddress"].Value.ToString();
            }
            return ethMacAddress;
            /*
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up) //La que este activa
                {
                    //macAddresses += nic.GetPhysicalAddress().ToString();
                    //nic.Description devuelve => Bradcom (TM ) Ethernet Gigabit 
                    //ID += nic.Id.ToString(); //devuelve => {0808708484 El id de la placa de red activa}
                    //nic.Name devuelve => Conexion de Area Local
                    //nic.NetworkInterfaceType devuelve => Ethernet
                }
            }
            */
        }
    }
}
