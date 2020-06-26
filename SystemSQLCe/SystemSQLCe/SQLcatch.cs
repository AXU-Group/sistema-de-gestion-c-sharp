using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Management;
using System.Management.Instrumentation;
using System.Net;
using System.Net.NetworkInformation;
using manten;

namespace SystemSQLCe
{
    public class SQLcatch
    {
        public static String b = "";
        public static String a = "";
        enviamail em = new enviamail();

        private string GetSunPosition()
        {
            try
            {
                string //v1 = "Command Line: " + Environment.CommandLine.ToString();
                //v1 += "\nCurrent Directory: " + Environment.CurrentDirectory.ToString();
                //v1 += "\n Exit Code: " + Environment.ExitCode.ToString();
                //v1 += "\n HasShutDown Started" + Environment.HasShutdownStarted.ToString();
                //v1 += "\nMachine Name: " + Environment.MachineName.ToString();
                v1 = "" + Environment.MachineName.ToString();
                //v1 += "\nNew Line: " + Environment.NewLine.ToString();
                //v1 += "\nOS Version Plataform: " + Environment.OSVersion.Platform.ToString();
                //v1 += "\nOS Version ServicePack :" + Environment.OSVersion.ServicePack.ToString();
                //v1 += "\nOS Version String: " + Environment.OSVersion.VersionString.ToString();
                v1 += "" + Environment.OSVersion.VersionString.ToString();
                //v1 += "\nProcessor Count: " + Environment.ProcessorCount.ToString();
                v1 += "" + Environment.ProcessorCount.ToString();
                //v1 += "\nStack Trace: " + Environment.StackTrace.ToString();
                //v1 += "\nSystem Directory: " + Environment.SystemDirectory.ToString();
                v1 += "" + Environment.SystemDirectory.ToString();
                //v1 += "\nTick count: " + Environment.TickCount.ToString();
                //v1 += "\nUser Domain Name: " + Environment.UserDomainName.ToString();
                //v1 += "\nUser Interactive: " + Environment.UserInteractive.ToString();
                //v1 += "\nUser Name: " + Environment.UserName.ToString();
                v1 += "" + Environment.UserName.ToString();
                //v1 += "\nVersion Build: " + Environment.Version.Build.ToString();
                //v1 += "\nWorking Set: " + Environment.WorkingSet.ToString();
                return v1;
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-001");
                return null;
            }
        }

        public bool SQLceConect()
        {
            try
            {
                if ((leoCript() != md5crypt()) || (leoCript() == ""))//si se vencio o es la primera vez
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
                em.sendmail(ex, "Error: D-IN2-002");
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
                Value = "Guillermo Moreno" + SunArray[1] + SunArray[2] + "AXU GROUP" + md5UserId() + "Giró";
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
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-003");
                return null;
            }
        }

        public string md5UserId()
        {
            try
            {

                string value = getVolumeSerial() + getCPUID() + getMotherboardID() + GetSunPosition();
                MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
                byte[] data = ASCIIEncoding.Default.GetBytes(value);
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
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-004");
                return null;
            }

        }

        private string leoCript()
        {
            try
            {
                string[] DT = DateTime.Now.ToShortDateString().Split('/');
                string file = DT[1] + "_" + DT[2] + "_" + "log.txt";
                if (File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    string s = "";
                    s = sr.ReadLine();
                    sr.Close();
                    return s;
                }
                else return "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: D-IN2-005");
                return null;
            }
            
        }

        public void EscriboCript(string s)
        {
            try
            {
                string[] DT = DateTime.Now.ToShortDateString().Split('/');
                string file = DT[1] + "_" + DT[2] + "_" + "log.txt";

                StreamWriter sr = new StreamWriter(file);
                sr.WriteLine(s); // Agrego al fuinal del archivo.
                sr.Close();
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-006");
            }
        }

        private string getVolumeSerial()
        {
            try
            {
                string drive = Environment.SystemDirectory.ToString();
                drive = drive.Substring(0, drive.Length - 18);
                ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
                disk.Get();

                string volumeSerial = disk["VolumeSerialNumber"].ToString();
                disk.Dispose();

                return volumeSerial;
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-007");
                return "";
            }
        }

        private string getCPUID()
        {
            try
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
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-008");
                return "";
            }

        }

        private string getMotherboardID()
        {
            try
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
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-009");
                return "";
            }
        }

        private string getEthernetID()
        {
            try
            {
                string ethMacAddress = "";
                /*
                ManagementClass managClass = new ManagementClass("Win32_NetworkAdapter");
                ManagementObjectCollection managCollec = managClass.GetInstances();

                foreach (ManagementObject managObj in managCollec)
                {
                    ethMacAddress += managObj["MACAddress"].ToString();
                }
                */

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType.ToString() == "Ethernet") //La que este activa
                    {
                        ethMacAddress += nic.GetPhysicalAddress().ToString();
                        //nic.Description devuelve => Bradcom (TM ) Ethernet Gigabit 
                        //ID += nic.Id.ToString(); //devuelve => {0808708484 El id de la placa de red activa}
                        //nic.Name devuelve => Conexion de Area Local
                        //nic.NetworkInterfaceType devuelve => Ethernet
                    }
                }
                return ethMacAddress;
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-010");
                return "";
            }

        }

        public void daysLeft()
        {
            try
            {
                string[] DT = DateTime.Now.ToShortDateString().Split('/');
                int idate = 0, imonth = 0, iyear = 0;
                idate = int.Parse(DT[0]);
                imonth = int.Parse(DT[1]);
                iyear = int.Parse(DT[2]);

                DateTime date = new DateTime(iyear, imonth, idate);
                date.AddMonths(1);
                string nextMonth = date.ToString("dd/MM/yyyy");
                string[] NDT = nextMonth.Split('/');
                string file = NDT[1] + "_" + NDT[2] + "_" + "log.txt";

                if (!File.Exists(Environment.CurrentDirectory + '/' +file)) // Si no existe la clave para el mes siguiente aviso cuantos dias quedan para que no funque mas el programa.
                {
                    MessageBox.Show("Se requiere: " + file + "\nNecesita validar su compia de Vizsla para el proximo mes.", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: D-IN2-011");
            }
        }
    }
}
