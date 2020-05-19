using Telegram.Bot;
using Telegram.Bot.Types;

namespace RAT_BotTelegram.Model.Commands {
    class HelloCommands : Command {

        public override string Name => "hola"; // Nombre del comando

        public override async void Execute(Message message, TelegramBotClient client) {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            
            // Todo lo que hará el boot   
            await client.SendTextMessageAsync(chatId,"Te conectaste !!", replyToMessageId: messageId);
        }
    }
}
