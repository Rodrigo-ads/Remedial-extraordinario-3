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
            Cadena = ConfigurationManager.ConnectionStrings["bdCovid"].ConnectionString;
        }

    }
}
