using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Negocios
    {
        Acceso obj = new Acceso();

        public string crear_Material(Material material)
        {
            return obj.InsertaMaterial(material);
        }
        public SqlDataReader ObtenerTablas(string tabla)
        {
            return obj.Select(tabla);
        }

        public SqlDataReader MaterialIdTipo(int idTipo)
        {
            return obj.MaterialesCons(idTipo);
        }

        public string crear_Obra(Obra obra)
        {
            return obj.InsertaObra(obra);
        }
    }
}
