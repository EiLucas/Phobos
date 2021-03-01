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
            pnl1.Visible = false;
            pnl2.Enabled = false;
            btnConfirmar.Visible = false;
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            pnl1.Visible = true;
            pnl2.Enabled = true;
            lblTituloSumir.Visible = false;
            txtTipoUsuario.Visible = false;
            btnConfirmar.Visible = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioDTO objModelo = new UsuarioDTO();//modelo
            UsuarioBLL objEditaBLL = new UsuarioBLL();//metodo
            objModelo.NomeUsuario = txtNome.Text;
            objModelo.CpfUsuario = txtCpf.Text;
            objModelo.SenhaUsuario = txtSenha.Text;
            objModelo.DataNascUsuario = txtData.Text;
            objModelo.DescricaoTipoUsuario = rbl1.SelectedValue;
            objModelo.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            objEditaBLL.EditarUsuario(objModelo);
            lblMessagem.Text = "Usuário atualizado com secesso!";
        }
    }
}