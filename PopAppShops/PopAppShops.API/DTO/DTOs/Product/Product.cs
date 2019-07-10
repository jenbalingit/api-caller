using PopAppShop.Backend.DTOs.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.Product
{
    public class Product : ResponseCallback, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string prodName;
        int price;
        string status;
        DateTime date;

        public string ProductName
        {
            get
            {
                return prodName;
            }
            set
            {
                prodName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("ProductName"));
                }
            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Price"));
                }
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Status"));
                }
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Date"));
                }
            }
        }
        public long? ParentID { get; set; }
        public string CompanyID { get; set; }
        public long ClassificationID { get; set; }
    }
}
