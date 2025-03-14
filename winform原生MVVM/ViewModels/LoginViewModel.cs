using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using winform原生MVVM;
using winform原生MVVM登录界面Demo.Commands;
using winform原生MVVM登录界面Demo.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace winform原生MVVM登录界面Demo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            var user = _userService.GetUserByUsername(Username);
            if (user != null && user.Password == Password)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                // 显示登录失败的消息
            }
        }
    }
    
}


//private string _username;
//private string _password;
//private string _errorMessage;
//public string Username
//{
//    get => _username;
//    set
//    {
//        _username = value;
//        OnPropertyChanged(nameof(Username));
//    }
//}
//public string Password
//{
//    get => _password;
//    set
//    {
//        _password = value;
//        OnPropertyChanged(nameof(Password));
//    }
//}
//public string ErrorMessage
//{
//    get => _errorMessage;
//    set
//    {
//        _errorMessage = value;
//        OnPropertyChanged(nameof(ErrorMessage));
//    }
//}
//public event PropertyChangedEventHandler PropertyChanged;
//protected virtual void OnPropertyChanged(string propertyName)
//{
//    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//}