<!-- # [Clic aquí para leer la documentación en español](Doc/Readme.md)-->
````logo
█▀▀█  █▀▀█ ▀▀█▀▀ 　 
█▄▄▀  █▄▄█   █   　 
█  █  █  █   █   　 

▀▀█▀▀ █▀▀ █   █▀▀ █▀▀▀ █▀▀█ █▀▀█ █▀▄▀█  █▀▀▀█ █▀▀█ █  █  █▀▀█ █▀▀█ ▀▀█▀▀ 
  █   █▀▀ █   █▀▀ █ ▀█ █▄▄▀ █▄▄█ █ ▀ █  ▀▀▀▄▄ █  █ █▄▄█  █▀▀▄ █  █   █ 
  █   ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀ ▀▀ ▀  ▀ ▀   ▀  █▄▄▄█ █▀▀▀ ▄▄▄█  █▄▄█ ▀▀▀▀   ▀
````
# Please! use it only for educational and professional purposes...
## Information
* __Developed by:__ `SebastianEPH`
* __Product name:__ `RAT Telegram Spy Bot`
* __Type software:__ `Remote Administration Tool`
* __File version:__ `0.1.0`
* __Architecture:__ `x86 bits || x64 bits`
* __State:__ `Beta`
* __Size:__ `400KB aprox`
* __Undetectable:__ `Not Tester`
* __Plataform:__ `Windows 7, 8.1, 10`
* __Programming language:__ `C#.net Framework - Console`
* __Licence:__ `MIT`
* __IDE or text editor:__ `Visual Studio Comunity 2019`
* __Documentation date:__ `30/05/2020`
* __Description:__ `Remote access Trojan, spies and obtains information from the infected pc, controlled by telegram commands. `

# Features
## `Commands and examples:`

<img src="https://i.imgur.com/59EsirM.png"
     alt="Commands List" title="Commands List">

### `/Status`
Show a message only if the infected PC is online

<img src="https://i.imgur.com/NYBXToL.png"
     alt="Command /Status " title="Command /Status - Example">

### `/Show_Information`
Shows detailed information of the infected PC

<img src="https://i.imgur.com/BTubIpL.png"
     alt="Command Show_Information " title="Command Show_Information - Example">


### `/Get_FilesAll`
It shows default system folders where there can be: [Images] [Photos] [Documents] [Music] and gets them, the process can take many minutes

In case you can't find the folder, show a message a controlled exception

<img src="https://i.imgur.com/5G271Hi.png"
     alt="Command /Status " title="Command /Status - Example">


### `/Get_OnlyFile <Path>`
- Write the command plus the file path with extension.
- The accepted file extensions are as follows, the file must not exceed 50MB
     ````csharp
     string[] video = { "gif", "mp4", "avi", "div", "m4v", "mov", "mpg", "mpeg", "qt", "wmv", "webm", "flv", "3gp" };
     string[] audio = { "midi", "mp1", "mp2", "mp3", "wma", "ogg", "au", "m4a" };
     string[] doc = { "doc", "docx", "txt", "log", "ppt", "pptx", "pdf" };
     string[] imagen = { "jpg", "jpeg", "png", "bmp", "ico", "jpe", "jpe" };
     string[] system = { "ani", "bat", "bfc", "bkf", "blg", "cat", "cer", "cfg", "chm", "chk", "clp", "cmd", "cnf", "com", "cpl", "crl", "crt", "cur", "dat", "db", "der", "dll", "drv", "ds", "dsn" , "dun","exe","fnd","fng","fon","grp","hlp","ht","inf","ini","ins","isp","job","key","lnk","msi","msp","msstyles", "nfo","ocx","otf","p7c","pfm","pif","pko","pma","pmc","pml","pmr","pmw","pnf","psw","qds","rdp","reg","scf","scr","sct","shb","shs","sys","theme", "tmp","ttc","ttf","udl","vxd","wab","wmdb","wme","wsc","wsf","wsh","zap"};
     ````
__NOTE:__ `Do not enclose path in double or single quotes`

![/Get_OnlyFile](https://i.imgur.com/4zT3BAb.png)

![sad](https://i.imgur.com/7RnOe6p.png)
### `/Dir <Path>`
Only list subfolders of a drive

__Example:__ __`/Dir`__  `C:\User\Photos and videos`

![/Dir](https://i.imgur.com/hMddo0N.png)

__NOTE:__ `Do not enclose path in double or single quotes`

![/Dir <Path>](https://i.imgur.com/8UkVGKH.png)

It will show all files folders and subfolders within the specified path, plus each file found is detailed.

### `/Dir_FolderDisk` |Menu|
As the previous command only lists specific folders but does not list a complete drive, this command fulfills that function. It would only be enough to select the drive, and if the drive exists it will list all the directories, otherwise it will display a message that the drive does not exist, it becomes a complete of __`/Dir`__

![](https://i.imgur.com/mSttp2m.png)

### `/Keylogger`
Developing...
### `/Delete_OnlyFile <Path> `

![Delete File](https://i.imgur.com/46NFjiv.png)
### `/Delete_Folder <Path> `

![Delete Folder](https://i.imgur.com/2VDCWKm.png)
### `/Help`

<img src="https://i.imgur.com/59EsirM.png"
     alt="Commands List" title="Commands List">

### `/About`
_Show creator info._

<img src="https://i.imgur.com/cyhbQzj.png"
     alt="Command /About "
     width="355"
     height="700"
     title="Command /About">

# Compilation

![](https://i.imgur.com/SHf4GIi.png)

Path : `[GitHub] RAT_BotTelegram\RAT TelegramSpyBot\bin\Debug`

# Infection method
___How do I infect the victim?___

__Note:__ Do not rename the file `RAT TelegramSpyBot.exe`, sIf you change the name, the RAT will be obsolete.
- You save the files on a USB.
- It will connect the __USB__ to the __ [PC] __ to infect.
- It is recommended to disable the antivirus or add an exclusion in the following path: `"C:\Users\Public"`.
- Next is to run the `RAT TelegramSpyBot.exe` file on the USB, the RAT will be replicated in the following path: `"C:\Users\Public\RAT_Telegram"`, It is recommended not to remove the USB instantly as the `RAT Telegram` will be replicating on the specified path.

__Note:__ When executing the file, it will automatically modify the windows registry so that it always starts when you turn on the computer.

The RAT will modify the following registry path`"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run"` therefore you will need administrator permissions, therefore it is recommended that the first execution be carried out with administrator permissions, in case you do not execute it with administrator permissions, the RAT will modify the following path`"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run"`

__Explanation:__ 
* `HKEY_LOCAL_MACHINE:` the RAT will run on all existing users and new computer users.
* `HKEY_CURRENT_USER:` the RAT will only run on the current user, if another user will be created, the RAT will only work on the main user
<!-- Creador  -->
---
## Contact:
__Note:__ Contact me only if you found a bug or want to contribute to the repository, thanks.

__Developed:__ by SebastianEPH
- [Website](https://sebastianeph.github.io/)
- [Github](https://github.com/SebastianEPH)
- [Linkedin](https://www.linkedin.com/in/sebastianeph/)
- [Telegram](https://t.me/sebastianeph)
