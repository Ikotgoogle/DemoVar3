using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar3.Model {
    public class Book {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }   
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string Animal { get; set; }
        public string Composition { get; set; } // состав продукта
        public string MeasuaringValue { get; set; }
        public int Cost { get; set; }
        public bool? IsFavourite { get; set; }
        public ObservableCollection<FavouriteList>? FavouriteList { get; set; }
        public ObservableCollection<BooksInOrder>? BooksInOrders { get; set; }
    }
}
