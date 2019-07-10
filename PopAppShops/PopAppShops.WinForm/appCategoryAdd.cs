using DTOs = PopAppShop.Backend.DTOs.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAppShops.WinForm
{
    public partial class appCategoryAdd : Form
    {
        API.API.Category categoryAPI;
        public appCategoryAdd(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
            categoryAPI = new API.API.Category((data) =>
            {
                MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }, Logger);
        }
    }
}
