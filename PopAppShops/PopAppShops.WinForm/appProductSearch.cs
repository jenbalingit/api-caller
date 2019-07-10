using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopAppShops.API.API;
using DTOs = PopAppShop.Backend.DTOs;
using System.Net.Http;

namespace PopAppShops.WinForm
{
    public partial class appProductSearch : Form
    {
        Product productAPI;
        public appProductSearch(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
           
        }

        private  void button1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
