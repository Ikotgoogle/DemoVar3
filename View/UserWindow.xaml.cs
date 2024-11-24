using DemoVar3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoVar3.View {
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window {
        MyContext db = new MyContext();
        int _CurrentPage { get; set; } = 1;
        int startId = 1;
        int amount = 25, maxPage;
        string filter;
        public User CurrentUser { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public List<Book> PagedBooks { get; set; } = new List<Book>();
        public ObservableCollection<Book> Bucket { get; set; } = new ObservableCollection<Book>();

        public List<string> FilterList = new List<string>() { "Еда", "Игрушки", "Груминг", "Аптека", "Гигиена", "Дрессировка", "Предметы обихода", "Аксессуары" };
        List<string> roles = new List<string>() { "Администратор", "Пользователь", "Гость" };
        public UserWindow(string login, string pswrd) {
            InitializeComponent();
            db.Database.EnsureCreated();

            db.Books.Load();
            db.Users.Load();

            Users = db.Users.Local.ToObservableCollection();
            Books = db.Books.Local.ToObservableCollection();

            User cur = Users.FirstOrDefault(u => u.Login == login && u.Password == pswrd);
            if(cur != null) {
                CurrentUser = cur;
                UserName.Text = CurrentUser.Name;
            }
            else {
                UserName.Text = "Гость";
            }
            BookDG.ItemsSource = PagedBooks.OrderByDescending(b => b.IsFavourite).ToList();
            maxPage = Books.Count / amount;
            maxPage++;
            CurrentPage.Text = _CurrentPage.ToString();
            Filter.ItemsSource = FilterList;
            BucketView.ItemsSource = Bucket.ToList();


            for(int i = startId - 1; i < amount; i++) {
                PagedBooks.Add(Books[i]);
            }
            PagedBooks.OrderByDescending(x => x.IsFavourite);
            BookDG.ItemsSource = PagedBooks.ToList();
        }

        private void Next_Click(object sender, RoutedEventArgs e) {
            if(_CurrentPage == maxPage) { return; }
            PagedBooks.Clear();
            _CurrentPage++;
            startId += amount;
            CurrentPage.Text = _CurrentPage.ToString();

            if(filter == null) {
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    try {
                        PagedBooks.Add(Books[i]);
                        PagedBooks = PagedBooks.OrderByDescending(_ => _.IsFavourite).ToList();
                        BookDG.ItemsSource = PagedBooks;
                        BookDG.Items.Refresh();
                    }
                    catch { return; }
                }
            } else if(filter != null) {
                List<Book> filteredBooks = Books.Where(x => x.Category == filter).ToList();
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    try {
                        PagedBooks.Add(filteredBooks[i]);
                        PagedBooks = PagedBooks.OrderByDescending(_ => _.IsFavourite).ToList();
                        BookDG.ItemsSource = PagedBooks;
                        BookDG.Items.Refresh();
                    }
                    catch { return; }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            if(_CurrentPage == 1) { return; }
            PagedBooks.Clear();
            _CurrentPage--;
            startId -= amount;
            CurrentPage.Text = _CurrentPage.ToString();

            if(filter == null) {
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    try {
                        PagedBooks.Add(Books[i]);
                        PagedBooks = PagedBooks.OrderByDescending(_ => _.IsFavourite).ToList();
                        BookDG.ItemsSource = PagedBooks;
                        BookDG.Items.Refresh();
                    }
                    catch { return; }
                }
            } else if(filter != null) {
                List<Book> filteredBooks = Books.Where(x => x.Category == filter).ToList();
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    try {
                        PagedBooks.Add(filteredBooks[i]);
                        PagedBooks = PagedBooks.OrderByDescending(_ => _.IsFavourite).ToList();
                        BookDG.ItemsSource = PagedBooks;
                        BookDG.Items.Refresh();
                    }
                    catch { return; }
                }
            }
        }        

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(Filter.SelectedValue != null) {
                filter = Filter.SelectedValue.ToString();
            }
            PagedBooks.Clear();
            _CurrentPage = 1;
            CurrentPage.Text = _CurrentPage.ToString();
            startId = 1;

            List<Book> filteredBooks = Books.Where(b => b.Category == filter).ToList();
            maxPage = filteredBooks.Count / amount + 1;

            try { for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                PagedBooks.Add(filteredBooks[i]);
            }}catch { }

            
            PagedBooks = PagedBooks.OrderByDescending(_ => _.IsFavourite).ToList();
            BookDG.ItemsSource = PagedBooks;
            BookDG.Items.Refresh();
        }

        private void ClearFinter_Click(object sender, RoutedEventArgs e) {
            filter = null;
            Filter.SelectedValue = null;
            _CurrentPage = 1;
            CurrentPage.Text = _CurrentPage.ToString();
            startId = 1;
            maxPage = Books.Count / amount + 1;
            PagedBooks.Clear();
            for(int i = startId - 1; i < amount; i++) {
                PagedBooks.Add(Books[i]);
            }
            PagedBooks = PagedBooks.OrderByDescending(_ => _.IsFavourite).ToList();
            BookDG.ItemsSource = PagedBooks;
            BookDG.Items.Refresh();
        }

        private void AddToBucketBtn_Click(object sender, RoutedEventArgs e) {
            Book b = (Book)((Button)sender).DataContext;
            Bucket.Add(b);
            BucketView.ItemsSource = Bucket.ToList();
        }

        private void DeleteFromBucket_Click(object sender, RoutedEventArgs e) {
            Book b = (Book)((Button)sender).DataContext;
            Bucket.Remove(b);
            BucketView.ItemsSource = Bucket.ToList();
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e) {
            if(Bucket.Count == 0) {
                MessageBox.Show("Корзина пуста!");
                return;
            }
            if(CurrentUser != null) {
                Order order = new Order();
                order.User = CurrentUser;
                order.OrderDate = DateOnly.FromDateTime(DateTime.Today);
                order.DeliveryDate = order.OrderDate.AddDays(7);

                ObservableCollection<BooksInOrder> localBuscket = new ObservableCollection<BooksInOrder>();

                foreach(Book book in Bucket) {
                    BooksInOrder booksInOrder = new BooksInOrder {
                        OrderId = order,
                        BookId = book
                    };
                    localBuscket.Add(booksInOrder);
                    db.BooksInOrders.Add(booksInOrder);
                }
                order.BooksInOrder = localBuscket;
                db.Orders.Add(order);
                db.SaveChanges();
                BucketView.ItemsSource = new ObservableCollection<BooksInOrder>();
                BucketView.Items.Refresh();
                MessageBox.Show("Заказ успешно оформлен! \n Доставим в течение 7 дней.", "Ура", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else {
                try {
                    CurrentUser = new User();
                    GuesRegistration guesRegistration = new GuesRegistration(CurrentUser);
                    guesRegistration.ShowDialog();
                    CurrentUser.Role = roles[1];
                    UserName.Text = CurrentUser.Name;
                    db.Users.Add(CurrentUser);

                    Order order = new Order();
                    order.User = CurrentUser;
                    order.OrderDate = DateOnly.FromDateTime(DateTime.Today);
                    order.DeliveryDate = order.OrderDate.AddDays(7);

                    ObservableCollection<BooksInOrder> localBuscket = new ObservableCollection<BooksInOrder>();

                    foreach(Book book in Bucket) {
                        BooksInOrder booksInOrder = new BooksInOrder {
                            OrderId = order,
                            BookId = book
                        };
                        localBuscket.Add(booksInOrder);
                        db.BooksInOrders.Add(booksInOrder);
                    }
                    order.BooksInOrder = localBuscket;
                    db.Orders.Add(order);
                    db.SaveChanges();
                    BucketView.ItemsSource = new ObservableCollection<BooksInOrder>();
                    BucketView.Items.Refresh();

                    MessageBox.Show("Заказ успешно оформлен! \n Доставим в течение 7 дней.", "Ура", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch {
                    MessageBox.Show("Похоже, Вы ввели не все данные или введенные данные некорректны!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void FavouriteChkBx_Checked(object sender, RoutedEventArgs e) {
            Book book = (Book)((CheckBox)sender).DataContext;

            if((bool)!book.IsFavourite) {
                
                book.IsFavourite = true;
                FavouriteList favouriteList = new FavouriteList {
                    UserID = CurrentUser,
                    BookID = book
                };
                CurrentUser.FavouriteList.Add(favouriteList);

                PagedBooks = PagedBooks.OrderByDescending(b => b.IsFavourite).ToList();
                BookDG.ItemsSource = PagedBooks;
                BookDG.Items.Refresh();
            }
            else {
                book.IsFavourite = false;
                PagedBooks.OrderByDescending(b => b.IsFavourite).ToList();
                BookDG.ItemsSource = PagedBooks;
                BookDG.Items.Refresh();
            }
        }
    }
}
