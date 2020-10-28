using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Help_CLASS
{
    /// <summary>
    /// PropertyChanged监听变化反映到控件上
    /// 用这个类做绑定
    /// </summary>
    public class Stu_Blind : INotifyPropertyChanged
    {
        //先定义
        private string _date = "绑定测试";
        //再封装
        public string Date {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                if (PropertyChanged!=null)
                {
                    //对Date属性监听
                    PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                   
                }
            }
        }

        //界面中要对button的DataContext绑定

        //利用重构函数让date变化
        public Stu_Blind()
        {
            Task.Run
                (
                async () =>
                {
                    int i = 0;
                    while (true)
                    {
                        await Task.Delay(1000);
                        i++;
                        Date = i.ToString();
                    }
                } 
                );
            ;
                      
        }


        /// <summary>
        /// 实现接口
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
