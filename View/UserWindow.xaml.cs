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
        public ObservableCollection<Book> PagedBooks { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Book> Bucket { get; set; } = new ObservableCollection<Book>();

        public List<string> FilterList = new List<string>() { "Еда", "Игрушки", "Груминг", "Аптека", "Гигиена", "Дрессировка", "Предметы обихода", "Аксессуары" };
        public UserWindow(User user) {
            InitializeComponent();
            db.Database.EnsureCreated();

            db.Books.Load();
            db.Users.Load();

            CurrentUser = user;
            UserName.Text = CurrentUser.Name;
            Books = db.Books.Local.ToObservableCollection();
            BookDG.ItemsSource = PagedBooks.OrderByDescending(b => b.IsFavourite).ToList();
            maxPage = Books.Count / amount + 1;
            CurrentPage.Text = _CurrentPage.ToString();
            Filter.ItemsSource = FilterList;
            BucketView.ItemsSource = Bucket.ToList();

            #region books
            Books.Clear();
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
            db.SaveChanges();
            #endregion

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

            for(int i = startId - 1; i < amount * _CurrentPage; i++) {
                PagedBooks.Add(filteredBooks[i]);
            }
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

                BookDG.ItemsSource = PagedBooks.ToList();
                BookDG.Items.Refresh();
            }
            else {
                book.IsFavourite = false;
                BookDG.ItemsSource = PagedBooks.ToList();
                BookDG.Items.Refresh();
            }
        }
    }
}
