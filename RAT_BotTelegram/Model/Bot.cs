using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RAT_BotTelegram.Model{
    public static class Bot{
        private static TelegramBotClient client;

        // Método asincrono Devolverá la instancia del cliente 
        
        public async Task<TelegramBotClient> Get() {
            // Verifica si el cliente esta inicializado, si no devolverá una nueva instancia
            if (client != null) {
                return client;
            }
            // Creará una nueva instancia usando el token de acceso
            client = new TelegramBotClient(Config.Key);
            client.SetWebhookAsync("");


        }


    }
}
