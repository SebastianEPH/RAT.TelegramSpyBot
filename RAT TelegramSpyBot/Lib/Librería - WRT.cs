using System;
using Microsoft.Win32;  //Librería importante 
using System.Collections;
/// <summary>
/// The main Math class.
/// Contains all methods for performing basic math functions.
/// </summary>
/// <remarks>
/// solo valido en la clase
/// </remarks>
/// 

// Developed by SebastianEPH
// Versión: 3.1.1
// Link de documentació y ejemplos en :  https://github.com/SebastianEPH/WindowsRegistryTools_Library 

class RegistryTools {
    string message = "";
    /// <summary>
    /// Ésta función creará un nuevo valor de registro tipo <typeparamref name="String"/> y al ser creadas sobrescribirá los valores y datos existentes.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data String";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| En ésta variable se almacenará el texto , la unica restricción es no poder usar saltos de linea.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/>  valueData = "Soy dato tipo texto";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_String"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">En ésta variable se almacenará el texto , la unica restricción es no poder usar saltos de linea.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKeyValue_String(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, string valueData /*Datos almacenados del valor*/) {

            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;
                /// <value>Gets the value of PI.</value>
            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada no e tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
    }


    /// <summary>
    /// Ésta función creará un nuevos valores <c>HEX</c> en el registro, pero no es necesario introducir datos <c>HEX</c> 
    /// , los datos aceptados son de tipo <typeparamref name=" byte"/>[] y al ser creadas sobrescribirá los valores y datos existentes.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Binary";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| Los datos ingresados seben ser números positivos y de tipo <typeparamref name="byte"/> en el rango de [0-255], la longitud del array, no tiene limite, el array puede ser de 1 dato, cómo tambien de 500 datos.
    /// Cabe mencionar que al ver estos datos en el regitro, se verán en formato HEX.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" byte"/>[] valueData = { 1,45,78,152,23,2,1,5,4,255,0 };</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_Binary"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">Los datos ingresados seben ser números positivos y de tipo <paramref name="byte"/> en el rango de [0-255], la longitud del array, no tiene limite, el array puede ser de un dato, cómo tambien de 500 datos.
    /// Cabe mencionar que al ver estos datos en el regitro, se verán en formato HEX.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKeyValue_Binary(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, byte [] valueData /*Datos almacenados del valor*/) {
            //los datos deben ser guardadas en binario
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch  {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
        }


    /// <summary>
    /// Ésta función creará un nuevo valor de registro tipo <c> <typeparamref name="Int32"/></c> y remplazará a la existente.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Int32";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| Los datos ingresados seben ser números positivos y de tipo <typeparamref name="Int32"/> en el rango de [0-2147483647].</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" Int32"/> valueData = 2147483647;</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_DWORD"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">Los datos ingresados seben ser números positivos y de tipo <typeparamref name="Int32"/> en el rango de [0-2147483647].</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKeyValue_DWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, Int32 valueData /*Datos almacenados del valor*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;


            // Verificar si sobrepasó el int32

            // Valor DWORD, número entero no negativo de 32 bits (números entre el 0 y el 4.294.967.295 [232 – 1])



            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }

        }


    /// <summary>
    /// Ésta función creará un nuevo valor de registro tipo <c> <typeparamref name="Int64"/></c> y remplazará a la existente.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Int64";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| Los datos ingresados seben ser números positivos y de tipo <typeparamref name="Int64"/> en el rango de [0-29223372036854775807].</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" Int32"/> valueData = 9223372036854775808;</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_QWORD"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">Los datos ingresados seben ser números positivos y de tipo <typeparamref name="Int64"/> en el rango de [0-29223372036854775807].</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKeyValue_QWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, Int64 valueData /*Datos almacenados del valor*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
        }


    /// <summary>
    /// Ésta función creará un nuevo valor de registro tipo <typeparamref name="String"/> [] y al ser creadas sobrescribirá los valores y datos existentes.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" Multistring"/> valueName = "Data MultiString";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| En ésta variable se almacenará el texto con saltos de linea.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/>[]  valueData = {"linea 1","linea 2","linea 3","linea 4","linea x..."};</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_MultiString"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">En ésta variable se almacenará el texto con saltos de linea.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKeyValue_MultiString(string path/*Ruta completa del key*/, string valueName/*valores de la llave*/, string [] valueData/*Datos almacenados del valor*/) {

            //Los valores de cadena no requieren un <Value type> (ver ejemplo), pero backslashes ("\") necesita ser escrita como una doble barra invertida ("\ \")
            //Por ejemplo, para añadir los valores "Value A", "Value B", "Value C", "Value D", "Value E", "Value F", "Value G", "Value H", "Value I", "Value J", and "Value K" a la clave HKLM\SOFTWARE\Microsoft, 


            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //              Quieres separar por coma? Usa
            //              string[] arValores = tuTextBox.Text.Split(",");
            //              Con eso tienes los números en un arreglo de strings. Luego usa un for each y parsea cada ítem con TryParse
            //Limpiar path 
            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
        }


    /// <summary>
    /// Ésta función creará un nuevo valor de registro tipo <typeparamref name="String"/> y al ser creadas sobrescribirá los valores y datos existentes.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data ExpandString";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| En ésta variable se almacenará el texto , la unica restricción es no poder usar saltos de linea.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/>  valueData = "Soy dato tipo texto";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_ExpandString"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">En ésta variable se almacenará el texto , la unica restricción es no poder usar saltos de linea.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKeyValue_ExpandString(string path/*Ruta completa del key*/, string valueName/*valores de la llave*/, string valueData/*Datos almacenados del valor*/) {        //Función crear llave de Registro en formato ExpandableString
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //              Quieres separar por coma? Usa
            //              string[] arValores = tuTextBox.Text.Split(",");
            //              Con eso tienes los números en un arreglo de strings. Luego usa un for each y parsea cada ítem con TryParse
            //Limpiar path 
            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }

        }


    /// <summary>
    /// Ésta función creará una nueva llave (Es el contenedor donde se se guardan los valores y datos)
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta donde se creará la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="keyName"/></c></term>
    /// <description>| El nombre que tendrá la llave.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> keyName = "Soy una llave";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKey"/>(<paramref name="path"/>, <paramref name="keyName"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta donde se creará la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="keyName">El nombre que tendrá la llave.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String CreateKey(string path /*Ruta completa del key*/, string keyName /*Nombre del Key*/ ) {
            //Verifica algún código de error o advertenciaa
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            try {
                //Verificar si el Nombre ingresado está vacío
                if (keyName == "") {
                    return "E#R005 ";  //
                } else {
                    Registry.SetValue(RoutePath(path) + @"\" + keyName, "", "");
                    return "E#XITO";  // Se creó correctamente el contenedor
                }



            } catch (Exception) {
                return "E#CR01";    // No pudo crear la llave contenedora
            }
        }


    /// <summary>
    /// Ésta función eliminará una llave con todos los valores y datos que ésta llave pueda contener.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta donde se encuentra la llave y debe incluir el nombre de la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription\Soy la llave a eliminar";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="DeleteKey"/>(<paramref name="path"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta donde se creará la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String DeleteKey(string path /*camino completa del valor*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            //Se obtiene key 
            if (GetkeyName(path) == "") {
                return "E#R004";    //No se encontró el nombre del la llave
            }

            try {
                RegistryKey k;

                switch (GetTypeRegistry(path)) {
                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    default:
                    message = "";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#NN01";    // No se encontró la llave , o no se puedo eliminar por permisos 
            }
        }


    /// <summary>
    /// Ésta función creará un nuevo valor de registro y remplazará a la existente.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Binary";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueData"/></c></term>
    /// <description>| Los datos ingresados seben ser números positivos y de tipo <typeparamref name="byte"/> en el rango de [0-255], la longitud del array, no tiene limite, el array puede ser de 1 dato, cómo tambien de 500 datos.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" byte"/>[] valueData = { 1,45,78,152,23,2,1,5,4,255,0 };</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="CreateKeyValue_Binary"/>(<paramref name="path"/>, <paramref name="valueName"/>, <paramref name="valueData"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <seealso cref="Math.Subtract(double, double)"/>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor, si existiera algún valor con ese nombre y así ésta sea de un distinto tipo de dato, se sobreescribirá el valor.</param>
    /// <param name="valueData">Los datos ingresados seben ser números positivos y de tipo <paramref name="byte"/> en el rango de [0-255], la longitud del array, no tiene limite, el array puede ser de un dato, cómo tambien de 500 datos.</param>
    /// <returns>
    /// Retorna un mensaje de [<c><paramref name="Error"/></c>] ó [<c><paramref name="Exito"/></c>], según sea el caso. (Verifique la lista de códigos en la documentación)
    /// </returns>
    public String DeleteValue(string path /*camino completa del valor*/, string valueName /*Nombre del valor*/) {

            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica NameValue
            if (valueName == "") {
                return "E#RR03";    // Mensaje de Error, El nombre ingresado del valor está vacío
            }
            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            try {
                RegistryKey k;
                switch (GetTypeRegistry(path)) {
                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;

                    default:
                    return "E#R002"; // La ruta ingresada no es válida

                }
                return "E#XITO";
            } catch (Exception) {
                message = "E#RR02";

            }





            return message;
        }


    //public String GetDataValues(string path /*camino completa del valor*/, string valueName /*Nombre del valor*/) {

    //        string typeRegistry = GetTypeRegistry(path);
    //        if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
    //            return typeRegistry;
    //        }
    //        // Verifica si el NombreValue
    //        if (valueName == "") {
    //            //Verifica si el nombre del Key no esté vacío
    //            return "E#R003";    // El nombre del valor está vacio
    //        }

    //        //Limpiando Ruta y obtiene datos
    //        path = RoutePath(path);

    //        //Obtiene string        - ok 
    //        //Obtiene MultiString   - Error 

    //        try {

    //            // Intenta Int32
    //            try {       
    //                Int32 Int32Values = (Int32) Registry.GetValue(path, valueName, "E#RR02");
    //                return Int32Values.ToString();
    //            } catch { 
    //                //No es un int32
    //            }

    //            // Intenta Int64
    //            try {       
    //                Int64 Int64Values = (Int64) Registry.GetValue(path, valueName, "E#RR02");
    //                return Int64Values.ToString();
    //            } catch {
    //                // No se pudo
    //            }

    //            // Intenta multistring 
    //            try {
    //                string [] tArray = (string []) Registry.GetValue(path, valueName, new string [] {"E#RR02"});
    //                    // Leer Array 

    //                    ArrayList vector1;
    //                    vector1 = new ArrayList();

    //                    String salida = "";
    //                    String salida2 = "";

    //                    for (int i = 0; i < tArray.Length; i++) {
    //                        vector1.Add(tArray [i]);

    //                        salida = String.Join(" ", vector1 [i]);

    //                        salida2 = salida2 + "\r\n" + salida;

    //                    }

    //                    return salida2;
    //            } catch {
    //                // No es 
    //            }

    //        //// Insertar los datos en un String 
    //        message = (string) Registry.GetValue(path, valueName, "E#RR02");
    //        return message;


    //    } catch {
    //            //Mensaje de error +  su Codigo de error
    //            message = "E#RR01"; // Hubo un error al leer la llave
    //        }

    //        return message;
    //    }







    /// <summary>
    /// Ésta función retornará un tipo de dato los datos <typeparamref name="String"/> de un valor especificado del registro
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna los datos del valor, en caso de error, devolverá un mensaje de [<c><paramref name="Error"/></c>].(Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor,  si en caso no se encuentré ningún valor con ese nombre, se retornará un código de error.(Verifique la lista de códigos en la documentación)</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data String";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="getDataValue_String"/>(<paramref name="path"/>, <paramref name="valueName"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor,  si en caso no se encuentré ningún valor con ese nombre, se retornará un código de error.(Verifique la lista de códigos en la documentación)</param>
    /// <returns>
    /// Retorna los datos del valor, en caso de error, devolverá un mensaje de [<c><paramref name="Error"/></c>].(Verifique la lista de códigos en la documentación)
    /// </returns>
    public String getDataValue_String(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return "E#R003";    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);


            message = (string) Registry.GetValue(path, valueName, "E#RR02");
            return message;

        }


    /// <summary>
    /// Ésta función retornará  datos <typeparamref name="Byte"/>[] de un valor especificado del registro, especificamente en un array.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="Byte"/> []</term>
    /// <description>Retorna los datos del valor, cada valor va independientemente en cada array.</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Byte HEX";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code>
    /// <typeparamref name="String"/> [] texto = <paramref name="registro"/>.getDataValue_Binary(<paramref name="path"/>, <paramref name="valueName"/>);
    /// <para><typeparamref name="    "/>// Mostrar Números enteros en consola</para>
    /// <para><typeparamref name="    "/>for (<typeparamref name="int"/> i = 0; i&lt; texto.<paramref name="Length"/>; i++) {</para>
    /// <para><typeparamref name="         "/><paramref name="Console"/>.WriteLine(texto [i]);</para>
    /// <para><typeparamref name="    "/>}</para>
    /// <para><typeparamref name="    "/>// Mostrar Números HEX en consola - </para>
    /// <para><typeparamref name="    "/><typeparamref name="string"/> hex = <paramref name="BitConverter"/>.ToString(texto).<paramref name="Replace"/>("-", " ");</para>
    /// <para><typeparamref name="    "/><paramref name="Console"/>.WriteLine(hex);</para>
    /// </code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor.</param>
    /// <returns>
    /// Retorna los datos del valor, cada valor va independientemente en cada array.
    /// </returns>
    public byte [] getDataValue_Binary(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                                                                                                                                                            //weekDays [1]=  { "Sun"};
                return new byte [] {  };
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return new byte [] {  };    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            byte [] valueData = (byte []) Registry.GetValue(path, valueName, new byte []{ });



            return valueData;
        }


    /// <summary>
    /// Ésta función retornará un tipo de dato los datos <typeparamref name="Int32"/> de un valor especificado del registro
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="Int32"/></term>
    /// <description>Retorna los datos del valor.</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Int32";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="getDataValue_DWORD"/>(<paramref name="path"/>, <paramref name="valueName"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor de error.</param>
    /// <returns>
    /// Retorna los datos del valor.
    /// </returns>
    public Int32 getDataValue_DWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return -000001;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return -000003;    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);


            Int32 Int32Values = (Int32) Registry.GetValue(path, valueName, -000002);

            return Int32Values;

        }


    /// <summary>
    /// Ésta función retornará un tipo de dato los datos <typeparamref name="Int64"/> de un valor especificado del registro
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="Int32"/></term>
    /// <description>Retorna los datos del valor.</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data Int64";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="getDataValue_QWORD"/>(<paramref name="path"/>, <paramref name="valueName"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor de error.</param>
    /// <returns>
    /// Retorna los datos del valor.
    /// </returns>
    public Int64 getDataValue_QWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return -000001;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return -000003;    // El nombre del valor está vacio
            }
            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            Int64 Int64Values = (Int64) Registry.GetValue(path, valueName, -000002);
            return Int64Values;

        }

    /// <summary>
    /// Ésta función retornará  datos <typeparamref name="String"/>[] de un valor especificado del registro, especificamente en un array.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/> []</term>
    /// <description>Retorna los datos del valor, cada salto de linea será separada por arrays, en caso de error devolverá un mensaje de [<c><paramref name="Error"/></c>].(Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor,  si en caso no se encuentré ningún valor con ese nombre, se retornará un código de error.(Verifique la lista de códigos en la documentación)</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data MultiString";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code>
    /// <typeparamref name="String"/> [] texto = <paramref name="registro"/>.getDataValue_MultiString(<paramref name="path"/>, <paramref name="valueName"/>);
    /// <para><typeparamref name="    "/>for (<typeparamref name="int"/> i = 0; i&lt; texto.<paramref name="Length"/>; i++) {</para>
    /// <para><typeparamref name="         "/><paramref name="Console"/>.WriteLine(texto [i]);</para>
    /// <para><typeparamref name="    "/>}</para>
    /// </code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor,  si en caso no se encuentré ningún valor con ese nombre, se retornará un código de error.(Verifique la lista de códigos en la documentación)</param>
    /// <returns>
    /// Retorna los datos del valor, cada salto de linea será separada por arrays, en caso de error devolverá un mensaje de [<c><paramref name="Error"/></c>].(Verifique la lista de códigos en la documentación)
    /// </returns>
    public String [] getDataValue_MultiString(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
           
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                //weekDays [1]=  { "Sun"};
                return new string [1] { typeRegistry };
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return new string [1] { "E#R003" };    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            ArrayList vector1;
            vector1 = new ArrayList();

            string [] tArray = (string []) Registry.GetValue(path, valueName, new string [] { "E#RR02" });
            // Leer Array 

            
            //Codigo comentado , mandará 
            //String salida = "";
            //String salida2 = "";

            //for (int i = 0; i < tArray.Length; i++) {
            //    vector1.Add(tArray [i]);

            //    //salida = String.Join(" ", vector1 [i]);

            //    //salida2 = salida2 + "\r\n" + salida;

            //}

            return tArray;

           
        }

    /// <summary>
    /// Ésta función retornará un tipo de dato  <typeparamref name="String"/> de un valor especificado del registro.
    /// <para>Retorno:</para>
    /// <list type="bullet">
    /// <item>
    /// <term><typeparamref name="String"/></term>
    /// <description>Retorna los datos del valor, en caso de error devolverá un mensaje de [<c><paramref name="Error"/></c>].(Verifique la lista de códigos en la documentación)</description>
    /// </item>
    /// </list>
    /// <para>Argumentos: </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c><paramref name="path"/></c></term>
    /// <description>| Ruta completa del la llave, procure usar un <typeparamref name="@"/> al momento de escribir la ruta.</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> path = <typeparamref name="@"/>"Computer\HKEY_CURRENT_USER\Control Panel\Accessibility\AudioDescription";</c></para>
    /// </item>
    /// <item>
    /// <term><c><paramref name="valueName"/></c></term>
    /// <description>| Nombre del valor,  si en caso no se encuentré ningún valor con ese nombre, se retornará un código de error.(Verifique la lista de códigos en la documentación)</description>
    /// <para>Ejemplo:  <c> <typeparamref name=" string"/> valueName = "Data ExpandString";</c></para>
    /// </item>
    /// </list>
    /// <term>Sintaxis:</term>
    /// <description> Sintaxis sugerida, <c><paramref name="registro"/></c>: hace referencia al nombre, que usted colocó para instanciar ésta librería.</description>
    /// <list type="table">
    /// <item>
    /// <code><typeparamref name=" Console"/>.WriteLine(<paramref name="registro"/>.<typeparamref name="getDataValue_ExpandString"/>(<paramref name="path"/>, <paramref name="valueName"/>));</code>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="path">Ruta completa del la llave, procure usar un <paramref name="@"/> al momento de escribir la ruta.</param>
    /// <param name="valueName">Nombre del valor,  si en caso no se encuentré ningún valor con ese nombre, se retornará un código de error.(Verifique la lista de códigos en la documentación)</param>
    /// <returns>
    /// Retorna los datos del valor, en caso de error devolverá un mensaje de [<c><paramref name="Error"/></c>].(Verifique la lista de códigos en la documentación)
    /// </returns>
    public String getDataValue_ExpandString(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {

            //llama a la función getValueString y obtiene los valores
            message = getDataValue_String(path, valueName);
     
            return message;
        }


        private String GetSubFiles(string path) {
            //Verifica si la ruta ingresada tiene un formato aceptado
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);


            // Tipo de R
            // int inin = .Length;    // Obtiene el número de longuitud de la cadena de caracteres de GetTypeRegistry
            int inin = GetTypeRegistry(path).Length;

            int ifin = path.Length - inin;                    // Obtiene el número de longuituc de caracteres de la ruta completa

            //Verifica si encontró typeRegistry
            int ver = path.LastIndexOf(GetTypeRegistry(path)); //    Busca el typo de registro en la ruta ingresada, 

            if (ver == 0) {
                if (path.Substring(inin, ifin) == @"\") {   //Verifica si la ruta lleva un \ , estó podria causar problemas, por ende se decidió eliminarlo
                    return "";
                } else {
                     inin = GetTypeRegistry(path).Length+1;
                     ifin = path.Length - inin;

                    if (ifin == -1) {
                        return "";
                    } else {
                        return path.Substring(inin, ifin);          // Verificar esto , fue con Computer\HKEY_CURRENT_USER
                    }
                }
            } else {
                return path = "E#R002"; // Ruta invalida
            }


        }
        private String GetSubFilesSinKeyName(string path) {
            //Verifica posibles mensajes de fallos 
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }


            // Evita posible Errores 
            if (GetkeyName(path) == "") {
                return "";
            }



            // Numero completo subruta - el nombre del key
            int final = GetSubFiles(path).Length - GetkeyName(path).Length;

            //Convierte la ruta completa a ruta reducida
            // Solo obtiene las subRutas y no la ruta completa 
            path = GetSubFiles(path);
            if (final <= 0 ) {
                return "";  // Significa que no existe SubFiles, la llave está creada directamente en el directorio 
            }

               message =  path.Substring(0, final-1);

            return message;
        }
        private String GetkeyName(string path) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            path = GetSubFiles(path);

            /* Ésta función busca retornar el "CONTENEDOR" de la variable °path°
             * 
             * =Ejemplo:
             * [Antes]    path = @"HKEY_CURRENT_USER\Contenedor1\Contenedor2\Contenedor3"
             * [Despues]  path =  "Contenedor3"
             * 
             */
            if (path == "") {
                //Verifica si La Ruta ingresada no esté vacío
                return message = "E#R001";
            }

            try {
                /* Utiliza la variable para obtener el ultimo contendor 
                 * =Ejemplo:
                 * [Antes]    path = @"Contenedor1\Contenedor2\Contenedor3" 
                 * [Despues]  path =  "Contenedor3"                                                     */
                int palabraClave = path.LastIndexOf(@"\");
                path = path.Substring(palabraClave + 1);
                if (path == @"\") {
                    return path = "";
                } else {
                    return path;
                }

                
            } catch  {
                
                message = ""; //Retornará vacío ya que no se encuentra 
            }

            return message;
        }
        private String GetTypeRegistry(string path) {
            /* 
             * Ésta función recorrerá toda la variable °path°
             * y retornará solo uno de los siguientes textos:
             *                                        =>        HKEY_CLASSES_ROOT
             *                                        =>        HKEY_CURRENT_USER
             *                                        =>        HKEY_LOCAL_MACHINE
             *                                        =>        HKEY_USERS
             *                                        =>        HKEY_CURRENT_CONFIG                                            
             * VARIABLES:
             *            - String: palabra_inicial     // Desde esta palabra Clave se empieza a obtener el texto
             *            - String: palabra_fin         // Desde esta palabra Clave se termina de obtener el texto
             */


            // Verifica si el camino de ruta lleva Computer\ o computadora
            // bool containsSearchResult = factMessage.Contains("Extension");
            // Console.WriteLine($"Starts with \"extension\"? {containsSearchResult}");

            // verifica si camino lleva computer , pero esta devuelve un valor contrario que el de arriba
            //bool ignoreCaseSearchResult = factMessage.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            //Console.WriteLine($"Starts with \"extension\"? {ignoreCaseSearchResult} (ignoring case)");


            // Obtiene la Ruta Limpia
            path = RoutePath(path);
            // Verifica si la ruta está vacía
            if (path == "E#R001") {
                return path;    //Se termina el proceso y Retorna mensaje de Error
            }


            // Proceso de Obtención de  del tipo de registro

            int ifin;
            int inin;


            inin = path.IndexOf("HKEY_");
            if (inin == -1) {
                return "E#R002";  //Mensaje de error - ruta invalidad
            }


            int root = path.IndexOf(@"HKEY_CLASSES_ROOT") - inin; //Ingles UK
            
            if (root != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_CLASSES_ROOT".Length;
                
                return path.Substring(inin, ifin);
            }
            int user = path.IndexOf(@"HKEY_CURRENT_USER") - inin; //Ingles UK
            if (user != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_CURRENT_USER".Length;
                
                return path.Substring(inin, ifin);
            }
            int machine = path.IndexOf(@"HKEY_LOCAL_MACHINE") - inin; //Ingles UK
            if (machine != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_LOCAL_MACHINE".Length;
                
                return path.Substring(inin, ifin);
            }
            int users = path.IndexOf(@"HKEY_USERS") - inin; //Ingles UK
            if (users != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_USERS".Length;
                
                return path.Substring(inin, ifin);
            }
            int config = path.IndexOf(@"HKEY_CURRENT_CONFIG") - inin; //Ingles UK
            if (config != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_CURRENT_CONFIG".Length;
                
                return path.Substring(inin, ifin);
            }

            if (root == -1 && user == -1 && machine == -1 && users == -1 && config == -1) {
                return "E#R002";   // Manda mensaje de error de ruta no valida
            }


            return "E#R002";   // Manda mensaje de error de ruta no valida

            }   // Funcional sin bugs
        private String RoutePath(string path) {
            // Ésta función solo devuelve la ruta sin las palabras  Equipo\ && Computer\
            // Y solo detectará si la ruta ingresada está vacía

            if (path == "") {
                //Verifica si La Ruta ingresada no esté vacío
                return message = "E#R001";  // Error la ruta ingresada está vacía
            }


            int nini;              // Número de caracter de Inicio
            int nfin = path.Length; // Número de caracter Final

            //Si no existe la palabra - int ver  = -1
            int ver1 = path.IndexOf(@"Computer\"); //Ingles UK

            //Si no existe la palabra - int ver  = -1
            int ver2 = path.IndexOf(@"Equipo\");   //Español

            if (ver2 != -1) {
                // Significa que si se encontró ésta palabra
                nini = @"Equipo\".Length;
                nfin = nfin - nini;
                return path = path.Substring(nini, nfin);
            }
            if (ver1 != -1) {
                // Significa que si se encontró ésta palabra
                nini = @"Computer\".Length;
                nfin = nfin - nini;
                return path = path.Substring(nini, nfin);
            }
            //if (ver == -1 && ver2 == -2) {
            //    return "";
            //}
            return path;

           
            

        }         // Funcional sin bugs 
    }
