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

        public SqlDataReader Select(string table)
        {
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlDataReader reader;
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.CommandText = "select * from " + table;
            reader = com.ExecuteReader();
            return reader;
        }

        public SqlDataReader MaterialesCons(int id_Tipo)
        {
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlDataReader reader;
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.CommandText = @"SELECT
            ID_Material,
            Descripcion_Mat,
            Marca,
            Presentacion,
            ID_Tipo
            FROM Material
            WHERE ID_Tipo = @idTipo";
            com.Parameters.AddWithValue("@idTipo", id_Tipo);
            reader = com.ExecuteReader();
            return reader;
        }

        public string InsertaObra(Obra obra)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.Parameters.AddWithValue("@NomObra", obra.Nom_Obra);
            com.Parameters.AddWithValue("@Direccion", obra.Direccion);
            com.Parameters.AddWithValue("@FechaIni", obra.FechaInicio);
            com.Parameters.AddWithValue("@FechaFin", obra.FechaFin);
            com.Parameters.AddWithValue("@IDdueno", obra.Id_Dueno);
            com.Parameters.AddWithValue("@IDEnca", obra.Id_Encargado);
            com.CommandText = "INSERT INTO Obra VALUES (@NomObra, @Direccion, @FechaIni, @FechaFin, @IDdueno, @IDEnca);";
            com.ExecuteNonQuery();
            respuesta = "Se creó una nueva obra";
            return respuesta;
        }

        public SqlDataReader ConsultaObra()
        {
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlDataReader reader;
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.CommandText = @"SELECT
            Nom_Obra AS 'Nombre de la obra',
            Direccion,
            Fecha_Inicio,
            Fecha_Termino,
            EncargadoObra.Nom_Encargado AS 'Nombre del encargado',
            Dueno.Nombre_Dueno AS 'Nombre del dueño'
            FROM Obra
            INNER JOIN EncargadoObra on (Obra.ID_Encargado = EncargadoObra.ID_Encargado)
            INNER JOIN Dueno on (Obra.ID_Dueno = Dueno.ID_Dueno)";
            reader = com.ExecuteReader();
            return reader;
        }
        public string DeleteObras(int id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.Parameters.AddWithValue("@id", id);
            com.CommandText = "delete from Obra where ID_Obra = @id";
            com.ExecuteNonQuery();
            respuesta = "Se eliminó un registro";
            conexion.Close();
            return respuesta;
        }


    }
}
