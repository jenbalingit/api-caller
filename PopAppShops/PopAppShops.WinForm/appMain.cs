using PopAppShops.API;
using PopAppShops.API.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAppShops.WinForm
{
    public partial class appMain : Form
    {
        public appMain()
        {
            InitializeComponent();

            //int index = strParam.LastIndexOf("or");
            //strParam = strParam.Remove(index, 2);
        }

        private void userLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appuserlogin = new appUserLogin(LogRequest);
            appuserlogin.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var appUserRegister = new appUserRegister(LogRequest);
            appUserRegister.ShowDialog();
        }

        private void facebookLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appFbLogin = new appFbLogin(LogRequest);
            appFbLogin.ShowDialog();
        }

        private void displayCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appCategoryList = new appCategoryList(LogRequest);
            appCategoryList.ShowDialog();
        }

        public void LogRequest(string url, string parameters, HttpMethod method, bool hasHeader, string deviceHeader, string authToken, string result)
        {
            string template = new TextFileManager<string>(@"C:\popappsdata\logtmp.txt").RetreiveFilesAsString();
            template = template.Replace("##datelog##", DateTime.UtcNow.ToLongDateString());
            template = template.Replace("##timelog##", DateTime.UtcNow.ToLongTimeString());
            template = template.Replace("##url##", url);
            template = template.Replace("##parameters##", parameters);
            template = template.Replace("##method##", method.ToString());
            template = template.Replace("##hasheader##", hasHeader.ToString());
            template = template.Replace("##deviceheader##", deviceHeader);
            template = template.Replace("##authtoken##", authToken);
            template = template.Replace("##response##", result);
            txtlog.Text = txtlog.Text + "\n" + template;
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appCategoryAdd = new appCategoryAdd(LogRequest);
            appCategoryAdd.ShowDialog();
        }

        private async void featuredProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var marketingAPI = new API.API.Marketing();
            var res = await marketingAPI.GetFeatureProducts();
            LogText(res);
        }



        private async void productSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Product();
            var res = await l.Search(txtsearch.Text);
            LogText(res);
        }

        private void getCurrentTimeSpanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var now = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            MessageBox.Show(now.ToString());
        }

        private async void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            await GetCart(LogRequest);
        }

        private async Task GetCart(Action<string, string, HttpMethod, bool, string, string, string> logger)
        {
            var shoppingCartAPi = new API.API.ShoppingCart();

            LogText(await shoppingCartAPi.GetShoppingCart());
        }

        private async void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var shoppingCartAPi = new API.API.ShoppingCart();

            await shoppingCartAPi.AddToCart(new API.DTO.ShoppingCartItem { ProductSKU = txtcartID.Text, Quantity = 2 });

            LogText(await shoppingCartAPi.GetShoppingCart());

        }

        void LogText(string val)
        {
            txtlog.AppendText(Environment.NewLine + Environment.NewLine + val);
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var shoppingCartAPi = new API.API.ShoppingCart();
            await shoppingCartAPi.UpdateCart(new API.DTO.ShoppingCartItem { ID = 46, ProductSKU = "SKU011", Quantity = 4 });
        }

        private void chekckoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CheckoutForm().ShowDialog();
        }

        private void baseEcryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtlog.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes("BTI12345_9CO"));
        }

        private async void setAsPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resutl = await new API.API.Order().SetAsPaid("1-1485745913");
            MessageBox.Show(resutl.ToString());
        }

        private async void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            var dto = new API.DTO.Address();
            dto.AddressLine1 = "address line 1";
            dto.Subdivision = "subdivision";
            dto.City = "city";
            dto.Province = "provice";
            dto.Region = "region";
            dto.ZipCode = 123124;

            long result = await new API.API.Address().Add(dto);

            MessageBox.Show(result.ToString());


        }

        private async void getOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logic = new API.API.Order();
            string res = await logic.GetOrderByStatus(API.DTO.DTOs.OrdetStatus.New, 0, 10);
            LogText(res);
        }

        private async void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Order();
            txtlog.Text = await l.GetMyOrder(0, 3);
        }

        private async void addToWishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.ShoppingCart();
            txtlog.Text = await l.AddToWish("E95V2010");
        }

        private async void getWishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.ShoppingCart();
            txtlog.Text = await l.GetWish(0, 5);
        }

        private async void meetUpAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Company();
            txtlog.Text = await l.GetMeetUpAddress();
        }


        private void Parse()
        {
            string a = "0,1,3";

            List<DayOfWeek> @days = new List<DayOfWeek>();

            foreach (var item in a.Split(','))
            {
                @days.Add((DayOfWeek)Convert.ToInt32(item));
            }


        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parse();
        }

        private async void moveToCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.ShoppingCart();

            txtlog.Text = await l.MoveToCart(new API.DTO.DTOs.WishList { WishListID = Convert.ToInt64(txtwishID.Text), ProductSKU = "E95V2010", Quantity = 1 });
        }

        private async void moveCartToWishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.ShoppingCart();
            var move = await l.AddToWish("E95V2010");
            LogText(move);
            var delete = await l.Delete(Convert.ToInt64(txtcartID.Text));
            LogText(delete);

            var getwish = await l.GetWish(0, 5);
            LogText(getwish);




        }

        private async void confirmOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Order();
            var move = await l.UpdateStatus(new API.DTO.DTOs.Order
            {
                TransactionID = "1-1488954536",
                Status = API.DTO.DTOs.OrdetStatus.Inprogress
            });
            LogText(move);
        }

        private async void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Favorites();
            var res = await l.Get(0, 10);
            LogText(res);
        }

        private async void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Favorites();
            var res = await l.Insert(new API.DTO.DTOs.Favorite { ProductID = "QKQsVk6E9iOWrbvm8qKA3g==", ProductSKU = "PKMN007" });
            LogText(res);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Favorites();
            var res = await l.Delete(1);
            LogText(res);
        }

        private void generateGuidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtlog.Text = Guid.NewGuid().ToString("N");
        }

        private async void getStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Company();
            LogText(await l.GetByEmail());
        }

        private async void merchantDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = new API.API.Company();
            var res = await l.LoginDevice(new PopAppShop.Backend.DTOs.Device.UserDeviceLogin
            {
                Code = "Lenovo A369i Android 4.2.2",
                Description = "Lenovo A369i Android 4.2.2",
                DeviceKey = "EMsJNO+jZlYabZj9oUVvIKbq4APMtwatMBpfSZjtAA0=",
                UserId = 29,
                ApplicationID = "2df90a8db22e455aa80df1ee5b66c347",
                Token = textBox1.Text
            });
            LogText(res);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void loadByCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = new API.API.Product();
            LogText(await res.LoadByCategory(long.Parse(txtsearch.Text), 0, 50));
        }

        private void appMain_Load(object sender, EventArgs e)
        {

        }

        private async void cartCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = new API.API.ShoppingCart();
            LogText(await res.GetCartCount());
        }

        private async void getCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = new API.API.Category();
            LogText(await res.GetCate());
        }

        private async void topDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = new API.API.Marketing();



            var t = await res.GetTopDiscount();


            var f = await res.GetFeatureProducts();


        }

        private async void getDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var raw = new API.API.Order();
            LogText(await raw.GetDate(API.DTO.DTOs.OrdetStatus.New));

        }

        private async void getPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var raw = new API.API.Reward();
            LogText(await raw.GetRewardByBranch());
        }

        private async void getRedeemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var raw = new API.API.Reward();
            LogText(await raw.GetRedeemItem(Convert.ToInt32(textBox1.Text)));
        }

        private void InventoryMenuItem_Click(object sender, EventArgs e)
        {

            new InventoryForm().ShowDialog();


        }

        private void iNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = new List<API.DTO.Restock>();

            for (int i = 0; i < 500; i++)
            {
                items.Add(new API.DTO.Restock()
                {
                    ProductId = 3869,
                    SerialNumber = Guid.NewGuid().ToString("N"),
                    Sku = "PEPSI-PINAS",
                    Quantity = 1
                });
            }



            Parallel.ForEach(items, item =>
            {
                var inv = new API.API.Inventory();
                var logic = inv.Restock(item);
            });
        }

        private void rANDOMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void getSerialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var api = new API.API.Inventory();
            var logic = await api.GetBranchInventory(txtsearch.Text);
            LogText(logic);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }


            MessageBox.Show(builder.ToString().ToLower());
        }

        private async void getByIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logic = new API.API.Product();
            var res = await logic.GetProductById(txtsearch.Text);
            LogText(res);

        }
    }
}
