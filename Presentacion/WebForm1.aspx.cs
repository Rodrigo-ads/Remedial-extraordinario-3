using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Entidades;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Negocios objNeg = new Negocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dropIdTipo.AutoPostBack = true;
                dropIdTipo.Items.Add("Seleccione un ID_TIPO");
                SqlDataReader idTipo = objNeg.ObtenerTablas("Material");
                //dropIdTipo.Items.Clear();
                while (idTipo.Read())
                {
                    dropIdTipo.Items.Add(new ListItem()
                    {
                        Text = idTipo[4].ToString(),
                        Value = idTipo[0].ToString()
                    });
                }

                DropDownListDueno.Items.Add("Seleccione el Dueño");
                DropDownListEncargado.Items.Add("Seleeccione el Encargado");
                SqlDataReader idDueno = objNeg.ObtenerTablas("Dueno");
                while (idDueno.Read())
                {
                    DropDownListDueno.Items.Add(new ListItem()
                    {
                        Text = idDueno[1].ToString(),
                        Value = idDueno[0].ToString()
                    });
                }

                SqlDataReader idEncargado = objNeg.ObtenerTablas("EncargadoObra");
                while (idEncargado.Read())
                {
                    DropDownListEncargado.Items.Add(new ListItem()
                    {
                        Text = idEncargado[1].ToString(),
                        Value = idEncargado[0].ToString()
                    });
                }
            }
        }

        protected void btnInsertarMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                LabelRespuesta1.Text = objNeg.crear_Material(new Material()
                {
                    Descripcion_Mat = TextBoxMaterialDesc.Text,
                    Marca = TextBoxMarca.Text,
                    Presentacion = TextBoxPresentacion.Text,
                    Id_Tipo = Convert.ToInt32(TextBoxIdTipo.Text)
                });
            }
            catch(Exception ex)
            {
                LabelRespuesta1.Text = ex.Message;
            }
        }

        protected void dropIdTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = objNeg.MaterialIdTipo(Convert.ToInt32(dropIdTipo.SelectedValue));
            GridView1.DataBind();
        }
    }
}