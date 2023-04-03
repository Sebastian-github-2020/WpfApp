﻿using System;
using System.Collections.Generic;
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

namespace _48.plane.UserControls
{
    /// <summary>
    /// LotteryTabControl.xaml 的交互逻辑
    /// </summary>
    public partial class LotteryTabControl : UserControl
    {

        public string Title {
            get {
                return (string)GetValue(TitleProperty);
            }
            set {
                Debug.WriteLine(value);
                SetValue(TitleProperty, value);
            }
        }
        private static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LotteryTabControl), new PropertyMetadata(null));
        public LotteryTabControl() {
            InitializeComponent();

            this.DataContext = this;
            //Debug.WriteLine(this.Title);
        }
    }
}
