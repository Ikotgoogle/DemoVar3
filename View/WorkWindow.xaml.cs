using DemoVar3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window {
        MyContext db = new MyContext();
        int _CurrentPage { get; set; } = 1;
        int startId = 1;
        int amount = 25, maxPage;
        string filter;
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Book> PagedBooks { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> Bucket { get; set; } = new ObservableCollection<Book>();

        public List<string> FilterList = new List<string>() { "Еда", "Игрушки", "Груминг", "Аптека", "Гигиена", "Дрессировка", "Предметы обихода", "Аксессуары"};
        public WorkWindow() {
            InitializeComponent();
            db.Database.EnsureCreated();

            db.Books.Load();
            db.Users.Load();

            Customer.ItemsSource = db.Users.Local.ToObservableCollection();
            Books = db.Books.Local.ToObservableCollection();
            BookDG.ItemsSource = PagedBooks.ToList();
            maxPage = Books.Count / amount + 1;
            CurrentPage.Text = _CurrentPage.ToString();
            Filter.ItemsSource = FilterList;
            BucketView.ItemsSource = Bucket.ToList();

            for(int i = startId - 1; i < amount; i++) { 
                PagedBooks.Add(Books[i]);
                BookDG.ItemsSource = PagedBooks.ToList();
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
                        BookDG.ItemsSource = PagedBooks.ToList();
                        BookDG.Items.Refresh();
                    }
                    catch { return; }
                }
            } else if(filter != null) {
                List<Book> filteredBooks = Books.Where(x => x.Category == filter).ToList();
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    try {
                        PagedBooks.Add(filteredBooks[i]);
                        BookDG.ItemsSource = PagedBooks.ToList();
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
            
            List<Book> filteredBooks = Books.Where(b=> b.Category == filter).ToList();
            maxPage = filteredBooks.Count / amount + 1;
            try {
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    PagedBooks.Add(filteredBooks[i]);
            }} catch { }

            BookDG.ItemsSource = PagedBooks.ToList();
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
            BookDG.ItemsSource = PagedBooks.ToList();
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
            if(Customer.SelectedValue == null) { MessageBox.Show("Укажите, кому будет создан заказ!"); return; }
            Order order = new Order();
            order.User = Customer.SelectedValue as User;
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
            Bucket.Clear();
            BucketView.ItemsSource = new ObservableCollection<Book>();
            BucketView.Items.Refresh();
            MessageBox.Show("Заказ успешно оформлен! \n Доставим в течение 7 дней.", "Ура", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void NewUser_Click(object sender, RoutedEventArgs e) {
            User u = new User();
            try {
                NewUser newUser = new NewUser(u);
                newUser.ShowDialog();
                db.Users.Add(u);
                db.SaveChanges();
            }
            catch {
                MessageBox.Show("Похоже, Вы ввели не все данные или введенные данные некорректны!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
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
                        BookDG.ItemsSource = PagedBooks.ToList();
                        BookDG.Items.Refresh();
                    }
                    catch { return; }
                }
            } else if(filter != null) {
                List<Book> filteredBooks = Books.Where(x => x.Category == filter).ToList();
                for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                    try {
                        PagedBooks.Add(filteredBooks[i]);
                        BookDG.ItemsSource = PagedBooks.ToList();
                        BookDG.Items.Refresh();
                    } catch {  return; }
                }
            }
        }
    }
}
