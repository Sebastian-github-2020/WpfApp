using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _48.plane.ViewModel {
    /// <summary>
    /// TabContrlViewModel 
    /// </summary>
    public class TabContrlViewModel : ViewModelBase {
        /// <summary>
        /// tab、标题
        /// </summary>
        private string title;

        public string Title {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 对应的菜种代码
        /// </summary>
        public string LotteryCode { get; set; }

        /// <summary>
        /// 对应的历史数据
        /// </summary>
        private ObservableCollection<DataHistory> history;

        public ObservableCollection<DataHistory> History {
            get { return history; }
            set { history = value; OnPropertyChanged(); }
        }
        // 本期 期数
        private string currentExpect;
        public string CurrentExpect { get { return currentExpect; } set { currentExpect = value; OnPropertyChanged(); } }
        //上一期 期数
        private string previousExpect;

        public string PreviousExpect {
            get { return previousExpect; }
            set { previousExpect = value; OnPropertyChanged(); }
        }


        //剩余时间
        private string leaveTime;

        public string LeaveTime {
            get { return leaveTime; }
            set { leaveTime = value; OnPropertyChanged(); }
        }


        // 本期开奖号码
        private string currentResut;

        public string CurrentResut {
            get { return currentResut; }
            set { currentResut = value; OnPropertyChanged(); }
        }
        //图标
        public BitmapImage Icon { get; set; }


        /// <summary>
        /// 初始化tab数据
        /// </summary>
        /// <param name="icon">图标</param>
        /// <param name="title">tab标题</param>
        /// <param name="lotteryCode">菜种代码</param>
        /// <param name="currentExpect">本期期数</param>
        /// <param name="previousExpect">上一期期数</param>
        /// <param name="leaveTime">剩余时间</param>
        /// <param name="currentResut">上一期开奖结果</param>
        /// <param name="history">历史数据</param>
        public TabContrlViewModel(BitmapImage icon, string title, string lotteryCode, string currentExpect, string previousExpect, string leaveTime, string currentResut, ObservableCollection<DataHistory> history) {
            this.Title = title;
            this.LotteryCode = lotteryCode;
            this.CurrentExpect = currentExpect;
            this.PreviousExpect = previousExpect;
            this.LeaveTime = FormateLeaveTime(leaveTime);
            this.History = history;
            this.CurrentResut = currentResut;
            this.Icon = icon;
        }

        /// <summary>
        /// 将剩余时间转换成倒计时模式
        /// </summary>
        /// <param name="leavetime"></param>
        /// <returns></returns>
        public static string FormateLeaveTime(string time) {
            //1. 转成数字
            int num = Convert.ToInt32(time);
            string seconds = num % 60 > 9 ? Convert.ToString(num % 60) : $"0{num % 60}";
            string minuts = (num % 3600 / 60) > 9 ? Convert.ToString(num % 3600 / 60) : $"0{(num % 3600 / 60)}";
            string hour = (num / 3600) > 9 ? Convert.ToString(num / 3600) : $"0{(num / 3600)}";
            return $"{hour}:{minuts}:{seconds}";
        }

        /// <summary>
        /// 倒计时
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string TimeIntevel(string time) {
            int num = Convert.ToInt32(time);
            num--;
            if(num <= 0) return "0";
            return num.ToString();
        }
    }
}
