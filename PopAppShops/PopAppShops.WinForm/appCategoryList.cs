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
    public partial class appCategoryList : Form
    {
        Category categoryAPI;
        public appCategoryList(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
            categoryAPI = new Category((data) =>
            {
                MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }, Logger);
        }

        private async void appCategoryList_Load(object sender, EventArgs e)
        {
            var categories = await categoryAPI.GetCategories();
            new PopulateListView<DTOs.Category.Category>().DisplayList(listView1, categories);

        }
    }
}
