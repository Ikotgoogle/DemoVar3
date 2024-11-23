using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar3.Model {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }
        public string DeliveryAddress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public ObservableCollection<FavouriteList> FavouriteList { get; set; } = new ObservableCollection<FavouriteList>();
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
    }
}
