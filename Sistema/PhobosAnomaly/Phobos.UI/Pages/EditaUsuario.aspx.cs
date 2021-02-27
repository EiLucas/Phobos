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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Limpar()
        {
            txtIdUsuario.Text =
            txtNome.Text =
            txtCpf.Text =
            txtSenha.Text =
            txtData.Text = 
            txtTipoUsuario.Text = string.Empty;
            rbl1.ClearSelection();
            SetFocus(txtNome);
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtIdUsuario.Text);
            UsuarioDTO objPesquisa = new UsuarioDTO();//modelo
            UsuarioBLL objPesqBLL = new UsuarioBLL();//metodo

            objPesquisa = objPesqBLL.BuscarUsuario(codigo);

            if (objPesquisa != null)
            {
                txtNome.Text = objPesquisa.NomeUsuario;
                txtCpf.Text = objPesquisa.CpfUsuario;
                txtSenha.Text = objPesquisa.SenhaUsuario;
                txtData.Text = objPesquisa.DataNascUsuario;
                txtTipoUsuario.Text = objPesquisa.DescricaoTipoUsuario;
            }
            else
            {
                lblMessagem.Text = "Não encontrado!!";
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtIdUsuario.Text);
            UsuarioDTO objExcluir = new UsuarioDTO();//modelo
            UsuarioBLL objExclirBLL = new UsuarioBLL();//metodo

            objExclirBLL.ExcluirUsuario(codigo);
            Limpar();
            lblMessagem.Text = "Registro excluído com sucesso!";
        }
    }
}