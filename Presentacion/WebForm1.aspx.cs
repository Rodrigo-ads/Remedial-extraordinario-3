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
            if (!IsPostBack)
            {
                dropIdTipo.AutoPostBack = true;
                DropDownListObra.AutoPostBack = true;
                DropDownListProveObra.AutoPostBack = true;
                dropIdTipo.Items.Add("Seleccione un ID_TIPO");
                DropDownListProveMaterial.Items.Add("Seleccione el Material");
                SqlDataReader idTipo = objNeg.ObtenerTablas("Material");
                SqlDataReader idMate = objNeg.ObtenerTablas("Material");
                //dropIdTipo.Items.Clear();
                while (idTipo.Read())
                {
                    dropIdTipo.Items.Add(new ListItem()
                    {
                        Text = idTipo[4].ToString(),
                        Value = idTipo[0].ToString()
                    });
                }
                while (idMate.Read())
                {
                    DropDownListProveMaterial.Items.Add(new ListItem()
                    {
                        Text = idMate[1].ToString(),
                        Value = idMate[0].ToString()
                    });
                };

                DropDownListDueno.Items.Add("Seleccione el Dueño");
                DropDownListEncargado.Items.Add("Seleeccione el Encargado");
                ListBox1.Items.Add("Seleccione el Dueño");
                SqlDataReader idDueno = objNeg.ObtenerTablas("Dueno");
                while (idDueno.Read())
                {
                    DropDownListDueno.Items.Add(new ListItem()
                    {
                        Text = idDueno[1].ToString(),
                        Value = idDueno[0].ToString()
                    });
                    ListBox1.Items.Add(new ListItem()
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

                DropDownListObra.Items.Add("Seleccione la obra");
                DropDownListProveObra.Items.Add("Seleccione la obra");
                SqlDataReader idObra = objNeg.ObtenerTablas("Obra");
                while (idObra.Read())
                {
                    DropDownListObra.Items.Add(new ListItem()
                    {
                        Text = idObra[1].ToString(),
                        Value = idObra[0].ToString()
                    });
                    DropDownListProveObra.Items.Add(new ListItem()
                    {
                        Text = idObra[1].ToString(),
                        Value = idObra[0].ToString()
                    });
                }

                DropDownListProveProveedor.Items.Add("Seleccione el Proveedor");
                SqlDataReader idProve = objNeg.ObtenerTablas("Proveedor");
                while (idProve.Read())
                {
                    DropDownListProveProveedor.Items.Add(new ListItem()
                    {
                        Text = idProve[1].ToString(),
                        Value = idProve[0].ToString()
                    });
                }

                GridView3.DataSource = objNeg.ConsultarProveeObra();
                GridView3.DataBind();

                
                

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

        protected void btnInsertaObra_Click(object sender, EventArgs e)
        {
            try
            {
                LabelRespuesta2.Text = objNeg.crear_Obra(new Obra()
                {
                    Nom_Obra = TextBoxNombreObra.Text,
                    Direccion = TextBoxObraDireccion.Text,
                    FechaInicio = TextBoxObraInicio.Text,
                    FechaFin = TextBoxObraFinal.Text,
                    Id_Dueno = Convert.ToInt32(DropDownListDueno.SelectedValue),
                    Id_Encargado = Convert.ToInt32(DropDownListEncargado.SelectedValue)
                }) ;
                Response.Redirect("WebForm1.aspx");
            }
            catch(Exception ex)
            {
                LabelRespuesta2.Text = ex.Message;
            }
        }

        protected void btnMostrarObra_Click(object sender, EventArgs e)
        {
            GridView2.DataSource = objNeg.ConsultarObra();
            GridView2.DataBind();
            
        }

        protected void DropDownListObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            Respuesta3.Text = objNeg.BorrarObras(Convert.ToInt32(DropDownListObra.SelectedValue));
            GridView2.DataSource = objNeg.ConsultarObra();
            GridView2.DataBind();
        }

        protected void btnInsertaProveeDeMateria_Click(object sender, EventArgs e)
        {
            try
            {
                LabelRespueta4.Text = objNeg.InsertaProveMaterial(new ProveeMaterial()
                {
                    Recibido = TextBoxProveRecibido.Text,
                    Entrega = TextBoxProveEntrega.Text,
                    Cantidad = Convert.ToInt32(TextBoxProveCantidad.Text),
                    Fecha_Entre = TextBoxProveFechaEntre.Text,
                    precio = Convert.ToInt32(TextBoxProvePrecio.Text),
                    ID_Obra = Convert.ToInt32(DropDownListProveObra.SelectedValue),
                    ID_Materia = Convert.ToInt32(DropDownListProveMaterial.SelectedValue),
                    ID_Proveedor = Convert.ToInt32(DropDownListProveProveedor.SelectedValue)
                });
                Response.Redirect("WebForm1.aspx");
            }
            catch(Exception ex)
            {
                LabelRespueta4.Text = ex.Message;
            }
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnObrasSelect_Click(object sender, EventArgs e)
        {
            int valorDueno = Convert.ToInt32(ListBox1.SelectedValue);
            GridView4.DataSource = objNeg.ConsultarObraDueno(valorDueno);
            GridView4.DataBind();
        }
    }
}