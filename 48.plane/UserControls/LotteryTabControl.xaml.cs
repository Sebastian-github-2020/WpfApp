using _48.plane.ViewModel;
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



        /// <summary>
        /// 历史数据
        /// </summary>
        public ObservableCollection<DataHistory> DataList {
            get { return (ObservableCollection<DataHistory>)GetValue(DataListProperty); }
            set { SetValue(DataListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataListProperty =
            DependencyProperty.Register("DataList", typeof(ObservableCollection<DataHistory>), typeof(LotteryTabControl), new PropertyMetadata(null));





        public BitmapImage Icon {
            get { return (BitmapImage)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(BitmapImage), typeof(LotteryTabControl), new PropertyMetadata(null));





        public TabContrlViewModel MyData {
            get { return (TabContrlViewModel)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDataProperty =
            DependencyProperty.Register("MyData", typeof(TabContrlViewModel), typeof(LotteryTabControl), new PropertyMetadata(null));




        public LotteryTabControl() {
            InitializeComponent();

            //this.DataContext = this;
            //Debug.WriteLine(this.Title);
        }
    }



}
