using RAT_TelegramBot.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RAT_TelegramBot.Models {
    public static class Bot {
        private static TelegramBotClient client;

        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }


        // Método asincrono Devolverá la instancia del cliente 
        public static async Task<TelegramBotClient> Get() {
            // Verifica si el cliente esta inicializado, si no devolverá una nueva instancia
            if (client != null) {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommands());

            // Agregar más comandos ¿? 


            // Creará una nueva instancia usando el token de acceso
            client = new TelegramBotClient(AppSettings.Key);
            await client.SetWebhookAsync("");
            return client;

        }


    }
}