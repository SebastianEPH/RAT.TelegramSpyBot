using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAT_TelegramBot.Models {
    public class AppSettings {
        // URL Telegram API
        public static string Url { get; set; } = "https://telegrambotapp.azurewebsite.net:443/{0}";

        //Nombre del Bot
        public static string Name { get; set; } = "SEPH_TelegramCSharp_bot";
        // Token de acceso generado de BotFather  t.me/SEPH_TelegramCSharp_bot
        public static string Key { get; set; } = "1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8";




        // Cliente 
        //private static readonly TelegramBotClient Bot = new TelegramBotClient("");

        //###contrasenia Na55
    }
}