using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs = PopAppShop.Backend.DTOs;

namespace PopAppShops.WinForm
{
    public class PopulateListView<T>
    {
        public PopulateListView()
        {

        }

        public void DisplayList(ListView lv, List<T> data)
        {
            lv.GridLines = true;
            lv.View = View.Details;
            lv.FullRowSelect = true;
            data = data == null ? new List<T>() : data;
            lv.Columns.Clear();
            lv.Items.Clear();
            if (data.Count > 0)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    lv.Columns.Add(prop.Name);
                }

                foreach (var item in data)
                {
                    ListViewItem lvItem = new ListViewItem("");
                    foreach (var details in item.GetType().GetProperties())
                    {
                        var value = details.GetValue(item);
                        string valueStr = value == null ? "" : value.ToString();
                        if (lvItem.Text == "")
                            lvItem.Text = valueStr == "" ? "_" : valueStr;
                        else
                            lvItem.SubItems.Add(valueStr);
                    }
                    lv.Items.Add(lvItem);
                }
            }
        }
    }
}
