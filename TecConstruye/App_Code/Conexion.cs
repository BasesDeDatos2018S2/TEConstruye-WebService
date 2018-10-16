using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;



public class Conexion
{
    private string cadenaConexion = "Data Source=CRISPTOFER\\SQLEXPRESS;Initial Catalog=PRUEBA;Integrated Security=True";
    public SqlConnection cn;
    SqlCommand comando;
    //SqlDataReader dr;
    private SqlCommandBuilder cmb;
    public DataSet ds = new DataSet();
    public SqlDataAdapter da;


    public void conectar()
    {
        cn = new SqlConnection(cadenaConexion);
    }

    public Conexion()
    {
        conectar();
    }

    //consultar datos
    public void consultTable(string tabla)
    {
        string sql = "SELECT* FROM " + tabla + ";";
        ds.Tables.Clear();                         //Limpiar tablas el data set
        da = new SqlDataAdapter(sql, cn);          //declarar objeto data adapter
        cmb = new SqlCommandBuilder(da);           //declarar objeto command bulider
        da.Fill(ds, tabla);                        //Llenar el data adapter con la tabla y dataset
    }

    public bool eliminar(string tabla, string condicion)
    {
        cn.Open();
        string sql = "DELETE FROM " + tabla + " WHERE " + condicion + ";";
        comando = new SqlCommand(sql, cn);
        int i = comando.ExecuteNonQuery();
        cn.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool actualizar(string tabla, string campos, string condicion)
    {
        cn.Open();
        string sql = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion + ";";
        comando = new SqlCommand(sql, cn);
        int i = comando.ExecuteNonQuery();
        cn.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
                
        }
    }

    public DataTable consultarTabla(string tabla)
    {
        string sql = "SELECT* FROM " + tabla + ";";
        da = new SqlDataAdapter(sql, cn);
        DataSet dts = new DataSet();
        da.Fill(dts, tabla);
        DataTable dt = new DataTable();
        dt = dts.Tables[tabla];
        return dt;
    }

    public bool insertar(string tabla, string atributos, string tuplas)
    {
        cn.Open();
        string sql = "INSERT INTO " + tabla + " (" + atributos + ") " + "VALUES " + tuplas + ";";
        comando = new SqlCommand(sql, cn);
        int i = comando.ExecuteNonQuery();
        cn.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 
}
