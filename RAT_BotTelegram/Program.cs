using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RAT_BotTelegram {
    class Program {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8");
        static void Main(string[] args) {

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            // Escucha servidor
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessageEdited(object sender, Telegram.Bot.Args.MessageEventArgs e) {
            throw new NotImplementedException();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e) {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text) {
                if (e.Message.Text == "/Hola") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Mensaje editado??");
                } else if (e.Message.Text == "/elseif") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Ésto es un elseif" + e.Message.Chat.Username);
                } else if (e.Message.Text == "/3") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "3" + e.Message.Chat.Username);
                } else {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @" Usa: 
                            /Hola
                            /elseif
                            /3

                        ");
                }




            }
                
        }
    }
}
