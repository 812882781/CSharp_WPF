using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Help_CLASS
{
    class Bind_Test : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string name;
        public string Name
        {
            get 
            {
                return name;
            }
            set
            {
                name = value;
                if (this.PropertyChanged!=null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }


    }
}
