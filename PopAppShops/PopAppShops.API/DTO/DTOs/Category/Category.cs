using PopAppShop.Backend.DTOs.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Category
{
    public class Category : ResponseCallback, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string name;
        public int ID { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public long? ParentID { get; set; }
        public string CompanyID { get; set; }
        public long ClassificationID { get; set; }
    }
}
