using System;
using Telegram.Bot;

namespace RAT_BotTelegram
{
    class Program
    {
        // Cliente 
        // Buscalo como "SEPH_TelegramCSharp_bot"
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8");
        static void Main(string[] args)
        {
            // Inicia el Bot
            Bot.StartReceiving();
            Console.WriteLine("Hola");
            Bot.StartReceiving();

        }
    }
}
