using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Phobos.BLL;
using Phobos.DTO;
namespace Phobos.UI.Pages
{
    public partial class CadastraUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetFocus(txtUsuario);
        }

        protected void Limpar()
        {
            txtUsuario.Text =
            txtCpfUsuario.Text =
            txtSenhaUsuario.Text =
            txtDataNascUsuario.Text = string.Empty;
            rbl1.ClearSelection();
            SetFocus(txtUsuario);
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            UsuarioDTO objCad = new UsuarioDTO();
            objCad.NomeUsuario = txtUsuario.Text;
            objCad.CpfUsuario = txtCpfUsuario.Text;
            objCad.SenhaUsuario = txtSenhaUsuario.Text;
            objCad.DataNascUsuario = txtDataNascUsuario.Text;
            objCad.DescricaoTipoUsuario = rbl1.SelectedValue;

            UsuarioBLL objCadastrar = new UsuarioBLL();
            objCadastrar.CadastrarUsuario(objCad);
            Limpar();

            lblMensagem.Text = "Usuário " + objCad.NomeUsuario + " cadastrado com sucesso!!";
        }
    }
}