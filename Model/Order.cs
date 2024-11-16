using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar3.Model {
    public class Order {
        public int Id { get; set; }
        public User User { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public ObservableCollection<BooksInOrder> BooksInOrder { get; set; }
    }
}
