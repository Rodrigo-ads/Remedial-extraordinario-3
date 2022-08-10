using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;

namespace DAL
{
    public class Acceso
    {
        private string Cadena;
        public Acceso()
        {
            Cadena = ConfigurationManager.ConnectionStrings["mate"].ConnectionString;
        }

        public string InsertaMaterial(Material material)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.Parameters.AddWithValue("@Descripcion", material.Descripcion_Mat);
            com.Parameters.AddWithValue("@Marca", material.Marca);
            com.Parameters.AddWithValue("@Presentacion", material.Presentacion);
            com.Parameters.AddWithValue("@Id_tipo", material.Id_Tipo);
            com.CommandText = "INSERT INTO Material values(@Descripcion, @Marca, @Presentacion, @Id_tipo)";
            com.ExecuteNonQuery();
            respuesta = "Se creó un nuevo material";
            return respuesta;
        }

    }
}
