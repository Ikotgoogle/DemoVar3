using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar3.Model {
    public class BooksInOrder {
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public Book BookId { get; set; }
    }
}
