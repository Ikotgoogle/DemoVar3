using DemoVar3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoVar3.View {
    /// <summary>
    /// Логика взаимодействия для GuesRegistration.xaml
    /// </summary>
    public partial class GuesRegistration : Window {
        public User Guest { get; set; }        
        public GuesRegistration(User guest) {
            InitializeComponent();
            Guest = guest;
        }
        private void CreateUser_Click(object sender, RoutedEventArgs e) {
            Guest.Name = NewUserName.Text;
            Guest.TelNum = NewUserTelNum.Text;
            Guest.DeliveryAddress = NewUserDelAddress.Text;
            Guest.Login = NewUserLogin.Text;
            Guest.Password = NewUserPassword.Text;
            DialogResult = true;
        }
    }
}
