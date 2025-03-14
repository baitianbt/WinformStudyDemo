using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform原生MVVM登录界面Demo.ViewModels;

namespace winform原生MVVM登录界面Demo.Views
{
    public partial class LoginForm : Form
    {
        private readonly LoginViewModel _viewModel;

        public LoginForm(LoginViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _viewModel.Username = tb_user.Text.Trim();
            _viewModel.Password = tb_password.Text.Trim();

            _viewModel.LoginCommand.Execute(null);
            this.Hide();
        }
    }
}
