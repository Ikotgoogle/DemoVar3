using DemoVar3.Model;
using DemoVar3.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace DemoVar3 {
    public partial class MainWindow : Window {
        MyContext db = new MyContext();
        ObservableCollection<User> Users { get; set; }
        List<string> roles = new List<string>() { "Администратор", "Пользователь", "Гость" };

        public List<string> FilterList = new List<string>() { "Еда", "Игрушки", "Груминг", "Аптека", "Гигиена", "Дрессировка", "Предметы обихода", "Аксессуары" };


        public MainWindow() {
            InitializeComponent();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            #region add
            User a = new User() { Name = "Ivan", TelNum = "123", DeliveryAddress = "Home", Login = "IvanLE", Password = "123", Role = "Администратор" };
            User a1 = new User() { Name = "User", TelNum = "123", DeliveryAddress = "Test", Login = "User", Password = "123", Role = "Пользователь" };

            Book book1 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book2 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book3 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book4 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book5 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book6 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book7 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book8 = new Book() { Name = "test", Category = FilterList[0], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book9 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book10 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book11 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book12 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book13 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book14 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book15 = new Book() { Name = "test", Category = FilterList[2], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book16 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book17 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book18 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book19 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book20 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book21 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book22 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book23 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book24 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book25 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book26 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book27 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book28 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book29 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book30 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book31 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book32 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book33 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book34 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book35 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book36 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book37 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book38 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book39 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book40 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book41 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book42 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            Book book43 = new Book() { Name = "test", Category = FilterList[3], Description = "test", BrandName = "test", Animal = "test", Composition = "Test", MeasuaringValue = "test", Cost = 1000 };
            db.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10,
                                book11, book12, book13, book14, book15, book16, book17, book18, book19, book20,
                                book21, book22, book23, book24, book25, book26, book27, book28, book29, book30,
                                book31, book32, book33, book34, book35, book36, book37, book38, book39, book40, book41, book42, book43);
            db.Users.Add(a);
            db.Users.Add(a1);
            db.SaveChanges();
            #endregion
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
                MessageBox.Show("Пользователь не найден!", "Error"); return;
            }

            if(user.Role == roles[0]) {
                WorkWindow workWindow = new WorkWindow();
                workWindow.Show();
                this.Close();
            } else if (user.Role == roles[1]) {
                UserWindow userWindow = new UserWindow(user.Login, user.Password);
                userWindow.Show();
                this.Close();
            }
        }

        private void VisitorEnter_Click(object sender, RoutedEventArgs e) {
            User guest = new() { Role = roles[2], Name = "Гость" };
            UserWindow workWindow = new UserWindow("", "");
            workWindow.Show();
            this.Close();
        }
    }
}