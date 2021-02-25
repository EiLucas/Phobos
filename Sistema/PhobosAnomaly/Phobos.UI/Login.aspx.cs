using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Phobos.BLL;//Adicionado manualmente
using Phobos.DTO;//Adicionado manualmente

namespace Phobos.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Pegando informações do usuario
                string objUser = txtUsuario.Text;
                string objSenha = txtSenha.Text;

                //Instanciando objetos
                UsuarioDTO objModelo = new UsuarioDTO();
                UsuarioBLL objValida = new UsuarioBLL();

                objModelo = objValida.AutenticaUser(objUser, objSenha);
                if (objModelo != null)
                {
                    switch (objModelo.DescricaoTipoUsuario)
                    {
                        case "1":
                            Session["Usuario"] = txtUsuario.Text.Trim();
                            Response.Redirect("/Pages/IndexAdm.aspx");
                            break;
                        case "2":
                            Session["Usuario"] = txtUsuario.Text.Trim();
                            Response.Redirect("/Pages/IndexUser.aspx");
                            break;
                    }
                }
                else
                {
                    lblMesagem.Text = "Deu problema denovo!!";
                }
            }
            catch (Exception ex)
            {

                lblMesagem.Text = "Usuario não cadastrado!" + ex.Message;
            }
            
        }
    }
}