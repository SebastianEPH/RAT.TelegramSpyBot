using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAT_BotTelegram.Lib {
    class Features {
        public string getArquitectura () {
            // Obtiene la arquitecura del sistema operativo
            if (Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0").GetValue("Identifier").ToString().Contains("x86")) {
                return "32 Bit";
            } else {
                return "64 Bit";
            }
        }
        public string getNameProcessor() {
            // Obtiene Nombre del procesador
            if (Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0").GetValue("Identifier").ToString().Contains("x86")) {
                return "32 Bit";
            } else {
                return "64 Bit";
            }
        }


    }
}

