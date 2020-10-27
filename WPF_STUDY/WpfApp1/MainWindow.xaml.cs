using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp1.Help_CLASS;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ONE_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.study_dis_text.Text);
        }

        private void button_test_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("点击事件");
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            this.one_text.Text += (string)((CheckBox)sender).Content;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.one_text.Text = combobox.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "");
        }

        /// <summary>
        /// 下面是给treeview绑定数据模型的方法一
        /// name--本级菜单名称
        /// list--本级后面的列表形式
        /// </summary>
        public class Location
        {
            private string name;
            private List<Location> children;

            public List<Location> Children { get => children; set => children = value; }
            public string Name { get => name; set => name = value; }
        }
        /// <summary>
        /// 用button驱动显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TWO_button_Click(object sender, RoutedEventArgs e)
        {
            Location loc_1 = new Location()
            {
                Name = "1级",
                Children = new List<Location>()
                {
                    new Location()
                    {
                        Name="2级",
                        Children=new List<Location>()
                        {
                            new Location ()
                            {
                                Name="3级",
                                Children=new List<Location>()
                                {
                                    new Location()
                                    {
                                        Name="4级",
                                        Children=new List<Location>()
                                        {
                                            new Location()
                                            { Name="5级"}
                                        }
                                    }
                                }
                            },
                            new Location (){ Name="3级"}
                         }

                    },
                    new Location()
                    {
                        Name="2级"
                    }

                }
            };
            Location loc_2 = new Location()
            {
                Name = "1级",
            };

            List<Location> list_lo = new List<Location>();
            list_lo.Add(loc_1);
            list_lo.Add(loc_2);

            //绑定
            this.treeview.ItemsSource = list_lo;
        }


        /// <summary>
        /// 下面是用load方式驱动的treeview方法二
        /// 详细方法：
        /// 1、由xaml中的TreeViewItem实例化一级标签item
        /// 2、对item的属性赋值，该值将绑定到xaml中的text
        /// 3、将item添加到上级X.Items，显示
        /// 4、如果有下级，就用本级.Items.Add(null)方式打开下级，用expanded方式建立打开事件，在事件中实现
        /// 5、以此类推
        /// 注意：所有级别的item都是用TreeViewItem实例化的，这样显示Style就保持一致
        /// FolderView
        ///           |--item1
        ///                  |--Second_item1
        ///                  |--Second_item2
        ///           |--item2
        ///                  |--Second_item1
        ///                  |--Second_item2
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //取硬盘name
            foreach (var driver in Directory.GetLogicalDrives())
            {
                //实例化一个item，就是一个项目，一个标签，有几个项目就实例化几个
                var item = new TreeViewItem();

                //给item中的属性赋值，绑定到text
                item.Header = driver;
                item.Tag = driver;

                //新建下级item
                item.Items.Add(null);

                //类似一个展开事件
                item.Expanded += Folder_Expand;
                //将item添加到树
                FolderView.Items.Add(item);
            }
        }
        /// <summary>
        /// 展开操作后的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expand(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            var fullpath = (string)item.Tag;

            foreach (var DirectoryPath in Directory.GetDirectories(fullpath))
            {
                //用同样的Style实例化
                var Second_item = new TreeViewItem();
                
                Second_item.Header = DirectoryPath;
                Second_item.Tag = DirectoryPath;
                //本级Second_item添加到上级item的项目
                item.Items.Add(Second_item);
            }
        }

        /// <summary>
        /// 练习使用MVVM方式写代码
        /// </summary>
        Stru stru = new Stru();
        private void commmon_use()
        {
            string c = stru.Comm_str; 
        }

        /// <summary>
        /// PropertyChanged监听变化反映到控件上
        /// 后台将可视化控件和监听类绑起来
        /// </summary>
        Stu_Blind stu_Blind = new Stu_Blind();

        private void THREE_button_Click(object sender, RoutedEventArgs e)
        {
            this.THREE_button.DataContext = stu_Blind;
           
        }
        #region 用regin来隐藏一段代码
        
        #endregion
    }
}
