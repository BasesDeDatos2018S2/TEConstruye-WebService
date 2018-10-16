using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Newtonsoft.Json;






/// <summary>
/// Descripción breve de TecContruyeWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class TecContruyeWebService : System.Web.Services.WebService
{

    public SecuredTokenWebservice SoapHeader;
        
    private Conexion conexion = new Conexion();

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string AuthenticationUser()
    {
        if (SoapHeader == null)
            return "Please provide Username and Password";
        if (string.IsNullOrEmpty(SoapHeader.UserName) || string.IsNullOrEmpty(SoapHeader.Password))
            return "Please provide Username and Password";

        //Check is User credentials Valid
        if (!SoapHeader.IsUserCredentialsValid(SoapHeader.UserName, SoapHeader.Password))
            return "Invalid Username or Password";

        // Create and store the AuthenticatedToken before returning it
        string token = Guid.NewGuid().ToString();
        HttpRuntime.Cache.Add(
            token,
            SoapHeader.UserName,
            null,
            System.Web.Caching.Cache.NoAbsoluteExpiration,
            TimeSpan.FromMinutes(30),
            System.Web.Caching.CacheItemPriority.NotRemovable,
            null
            );

        return token;
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string HelloWorld()
    {
        if (SoapHeader == null)
            return "Please call AuthenticationMethod() first.";

        if (!SoapHeader.IsUserCredentialsValid(SoapHeader))
            return "Please call AuthenticationMethod() first.";

        return "Hello " + HttpRuntime.Cache[SoapHeader.AuthenticationToken];
    }

        
    /*Por el momento no necesitan autenticacion, eso lo implemento luego/
    /*Funciones web*/

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void INSERT(string tabla, string atributos, string tuplas)
    {
        bool flag = insertar(tabla, atributos, tuplas);
        if (flag)
        {
            Context.Response.Write("true");
        }
        else
        {
            Context.Response.Write("false");
        }
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SELECT(string table)
    {
        Context.Response.Write(consultarTabla(table));
    }


    //Funciones locales
    private string consultarTabla(string table)
    {
        DataTable tabla = conexion.consultarTabla(table);
        string cadena = Newtonsoft.Json.JsonConvert.SerializeObject(tabla);
        Console.WriteLine(cadena);
        return cadena;
    }

    private bool insertar(string tabla, string atributos, string tuplas)
    {
        return conexion.insertar(tabla, atributos, tuplas);

    }
}

