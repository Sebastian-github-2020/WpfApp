using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace _13.作业_小盒子 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static GridData data = new GridData(row: 1, column: 0);
        public MainWindow() {
            InitializeComponent();
            this.DataContext = data;
        }

        /// <summary>
        /// 监听按键 上下左右，因为 2>row>0   2>column>0 这个限制在set中完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_KeyDown(object sender, KeyEventArgs e) {
            // row 最大值2 column 最大值2
            Console.WriteLine("键盘按下");
            if(e.Key.Equals(Key.Up)) {
                data.Row -= 1;
            } else if(e.Key.Equals(Key.Down)) {
                data.Row += 1;
            } else if(e.Key.Equals(Key.Left)) {
                data.Column -= 1;
            } else if(e.Key.Equals(Key.Right)) {
                data.Column += 1;
            }
        }
    }


    /// <summary>
    /// 为了使每次值改变 同时刷新界面内容 需要实现INotifyPropertyChanged接口
    /// </summary>
    public class GridData : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int row;
        public int Row {
            get { return row; }
            set {
                if(row > 2) {
                    row = 2;
                } else if(row < 0) {
                    row = 0;
                } else {
                    row = value;
                }
                this.OnPropertyChanged();
            }
        }

        private int column;
        public int Column {
            get { return column; }
            set {
                if(column > 2) {
                    column = 2;
                } else if(column < 0) {
                    column = 0;
                } else {
                    column = value;
                }
                this.OnPropertyChanged();
            }
        }

        public GridData(int row, int column) {
            Row = row;
            Column = column;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
