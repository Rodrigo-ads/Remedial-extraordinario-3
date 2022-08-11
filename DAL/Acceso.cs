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

        public SqlDataReader ConsultaObraParam(int id)
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
            INNER JOIN Dueno on (Obra.ID_Dueno = Dueno.ID_Dueno) WHERE Obra.ID_Dueno = @idDueno";
            com.Parameters.AddWithValue("@idDueno", id);
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

        public string InsertaProveDeMateriaObra(ProveeMaterial proveeMaterial)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.Parameters.AddWithValue("@Recibio", proveeMaterial.Recibido);
            com.Parameters.AddWithValue("@Entrega", proveeMaterial.Entrega);
            com.Parameters.AddWithValue("@Cantidad", proveeMaterial.Cantidad);
            com.Parameters.AddWithValue("@Fecha_Entre", proveeMaterial.Fecha_Entre);
            com.Parameters.AddWithValue("@Precio", proveeMaterial.precio);
            com.Parameters.AddWithValue("@IDObra", proveeMaterial.ID_Obra);
            com.Parameters.AddWithValue("@IDMaterial", proveeMaterial.ID_Materia);
            com.Parameters.AddWithValue("@IDProveedor", proveeMaterial.ID_Proveedor);
            com.CommandText = "INSERT INTO Provee_De_Materi_Obra VALUES(@Recibio, @Entrega, @Cantidad, @Fecha_Entre, @Precio, @IDObra, @IDMaterial, @IDProveedor);";
            com.ExecuteNonQuery();
            respuesta = "Se creó un nuevo Proveedor de Material de Obras";
            return respuesta;
        }

        public SqlDataReader ConsultaProveDeMaterial()
        {
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlDataReader reader;
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.CommandText = @"SELECT
            Recibio,
            Entrega,
            Cantidad,
            Fecha_Entre,
            Precio,
            Obra.Nom_Obra,
            Material.Descripcion_Mat,
            Proveedor.Razon
            FROM
            Provee_De_Materi_Obra
            INNER JOIN Proveedor on (Provee_De_Materi_Obra.ID_Proveedor = Proveedor.ID_Proveedor)
            INNER JOIN Obra on (Obra.ID_Obra = Provee_De_Materi_Obra.ID_Obra)
            INNER JOIN Material on (Material.ID_Material = Provee_De_Materi_Obra.ID_Material)";
            reader = com.ExecuteReader();
            return reader;
        }
    }
}
