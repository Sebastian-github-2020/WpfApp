using _48.plane.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace _48.plane.UserControls {
    /// <summary>
    /// LotteryTabControl.xaml 的交互逻辑
    /// </summary>
    public partial class LotteryTabControl : UserControl {




        public ObservableCollection<DataHistory> DataList {
            get { return (ObservableCollection<DataHistory>)GetValue(DataListProperty); }
            set { SetValue(DataListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataListProperty =
            DependencyProperty.Register("DataList", typeof(ObservableCollection<DataHistory>), typeof(LotteryTabControl), new PropertyMetadata(null));




        public LotteryTabControl() {
            InitializeComponent();

            //this.DataContext = this;
            //Debug.WriteLine(this.Title);
        }
    }



}
