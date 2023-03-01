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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _32.控件DataGrid {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            List<Person> list = new List<Person>() {
                new Person(){Id=1,Name="zaks",Email="zaks@gmail.com",Phone="12312312" },
                new Person(){Id=2,Name="link",Email="link@gmail.com",Phone="17846546" },
            };

            this.DataContext = new { List = list };
        }
    }

    public class Person {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string email;

        public string Email {
            get { return email; }
            set { email = value; }
        }

        private string phone;

        public string Phone {
            get { return phone; }
            set { phone = value; }
        }

        //public Person(int id, string name, string email, string phone) {
        //    this.Id = id;
        //    this.Name = name;
        //    this.Email = email;
        //    this.Phone = phone;
        //}

    }
}
