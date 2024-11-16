﻿using DemoVar3.Model;
using DemoVar3.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace DemoVar3 {
    public partial class MainWindow : Window {
        MyContext db = new MyContext();
        ObservableCollection<User> Users { get; set; }
        List<string> roles = new List<string>() { "Администратор", "Пользователь", "Гость" };
        public MainWindow() {
            InitializeComponent();
            db.Database.EnsureCreated();

            //User a = new User() { Name = "Ivan", TelNum = "123", DeliveryAddress = "Home", Login = "IvanLE", Password = "123", Role = "Администратор" };
            //db.Users.Add(a);
            //db.SaveChanges();

            db.Users.Load();

            Users = db.Users.Local.ToObservableCollection();
        }

        User? FindUser(string login, string password) {
            return Users.FirstOrDefault(u => u.Password == password && u.Login == login);
        }

        private void Enter_Click(object sender, RoutedEventArgs e) {
            if(String.IsNullOrEmpty(LoginTxtBox.Text) && String.IsNullOrEmpty(PswdTxtBox.Text)) {
                MessageBox.Show("Вы не ввели данные!", "Error");
                return;
            }
            string login = LoginTxtBox.Text, password = PswdTxtBox.Text;
                        
            User user = FindUser(login, password);
            
            if(user == null) {
                MessageBox.Show("Пользователь не найден!", "Error");
            }

            if(user.Role == roles[0]) {
                WorkWindow workWindow = new WorkWindow();
                workWindow.Show();
                this.Close();
            }
        }

        private void VisitorEnter_Click(object sender, RoutedEventArgs e) {
            WorkWindow workWindow = new WorkWindow();
            workWindow.Show();
            this.Close();
        }
    }
}