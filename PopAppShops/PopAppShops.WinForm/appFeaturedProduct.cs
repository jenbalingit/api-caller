using PopAppShops.API.API;
using PopAppsShops.Api.DTOs.Marketing;
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
    public partial class appFeaturedProduct : Form
    {
        Marketing marketingAPI;
        public appFeaturedProduct(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
            //marketingAPI = new Marketing((data) =>
            //{
            //    MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}, Logger);
        }

        private async void appFeaturedProduct_Load(object sender, EventArgs e)
        {
            //var lvSet = new PopulateListView<FeaturedProduct>();
            //var list = await marketingAPI.GetFeatureProducts();
            
            //lvSet.DisplayList(listView1, list);
        }
    }
}
