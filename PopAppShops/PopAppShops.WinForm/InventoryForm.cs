using Core.Cryptography;
using Newtonsoft.Json;
using PopAppShops.API;
using PopAppShops.API.API;
using PopAppShops.API.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAppShops.WinForm
{
    public partial class InventoryForm : Form
    {
        List<API.DTO.InventoryUniqueId> ListOfSerials = new List<InventoryUniqueId>();

        List<KeyValuePair<int, string>> ListOfSKU = new List<KeyValuePair<int, string>>();
        private string GlobalSku = "PEPSI-PINAS";
        public InventoryForm()
        {
            InitializeComponent();
            ListOfSKU.Add(new KeyValuePair<int, string>(0, "WMGN66DL-CPN00-L"));
            ListOfSKU.Add(new KeyValuePair<int, string>(1, "WMGB20DB-CPN00-LX"));
            ListOfSKU.Add(new KeyValuePair<int, string>(2, "WTGL26EL-CPNTY-LX"));
            ListOfSKU.Add(new KeyValuePair<int, string>(3, "WMGL23DL-CPNMB-L"));
            ListOfSKU.Add(new KeyValuePair<int, string>(4, "WMGD31EL-CPNM0-L"));

        }








        public async void LoadStocks()
        {
            ListOfSerials.Clear();
            listView2.Items.Clear();
            var api = new API.API.Inventory();

            List<Task<KeyValuePair<string, string>>> loadStocksTask = new List<Task<KeyValuePair<string, string>>>();

            Parallel.ForEach(ListOfSKU, item =>
            {
                loadStocksTask.Add(api.GetBranchInventory(item.Value));
            });



            await System.Threading.Tasks.Task.WhenAll(loadStocksTask);


            foreach (var item in loadStocksTask)
            {
                ListViewItem viewItem = new ListViewItem(item.Result.Key);
                var filter = JsonConvert.DeserializeObject<List<API.DTO.InventoryUniqueId>>(item.Result.Value);
                if (!filter.Count.Equals(0))
                {
                    var stocks = filter.Where(w => w.Status == SerialNumberStatus.In).OrderBy(o => o.ID).ToList();
                    ListOfSerials.AddRange(stocks);
                    viewItem.SubItems.Add(stocks.Count.ToString());
                    listView2.Items.Add(viewItem);
                }
                else
                {

                    viewItem.SubItems.Add("0");
                    listView2.Items.Add(viewItem);
                }

            }
        }

        public async Task<Transactions> InventoryIn(Restock restock)
        {


            var inv = new API.API.Inventory();
            var logic = await inv.Restock(restock);
            return new API.DTO.Transactions
            {
                Message = logic,
                Item = new InventoryUniqueId(restock),
                Action = SerialNumberStatus.In
            };
        }

        public async Task<Transactions> InventoryOut(Restock uniqueId)
        {
            var inv = new Inventory();

            uniqueId.ProductId = 3869;
            uniqueId.BranchId = 10;
            uniqueId.Quantity = -1;

            var logic = await inv.UpdateUnique(uniqueId);

            return new API.DTO.Transactions
            {
                Message = logic,
                Item = new InventoryUniqueId(uniqueId),
                Action = SerialNumberStatus.Out
            };
        }

        public InventoryUniqueId SelectSerialFromList()
        {
            if (ListOfSerials.Count.Equals(0))
            {
                throw new Exception("Please load list of serials.");
            }
            else
            {


                var entity = new API.DTO.InventoryUniqueId();



                while (entity.ID.Equals(0))
                {
                    var serials = ListOfSerials.OrderBy(o => o.ID);
                    var getInitial = serials.FirstOrDefault();
                    var getLast = serials.LastOrDefault();

                    int generatedId = GetRandom((int)getInitial.ID, (int)getLast.ID);
                    var findIdFromList = ListOfSerials.FirstOrDefault(f => f.ID == generatedId);

                    if (findIdFromList != null)
                    {
                        entity.Sku = findIdFromList.ProductSKU;
                        entity = findIdFromList;
                        ListOfSerials.Remove(findIdFromList);
                    }


                }
                return entity;
            }

        }

        public InventoryUniqueId SelectSerialFromList(string sku)
        {
            var filterBySku = ListOfSerials.Where(w => w.ProductSKU == sku).ToList();


            if (filterBySku.Count.Equals(0))
            {
                throw new Exception("Please load list of serials.");
            }
            else
            {

                var getInitial = filterBySku.FirstOrDefault();
                var getLast = filterBySku.LastOrDefault();
                var entity = new API.DTO.InventoryUniqueId();



                while (entity.ID.Equals(0))
                {
                    int generatedId = GetRandom((int)getInitial.ID, (int)getLast.ID);
                    var findIdFromList = filterBySku.FirstOrDefault(f => f.ID == generatedId);

                    if (findIdFromList != null)
                    {
                        entity.Sku = findIdFromList.ProductSKU;
                        entity = findIdFromList;
                        ListOfSerials.Remove(findIdFromList);
                    }


                }
                return entity;
            }

        }

        public int GetRandom(int start, int end)
        {
            Random rnd = new Random();

            return rnd.Next(start, end);
        }

        public async Task<Transactions> Sell(InventoryUniqueId uniqueId)
        {
            var c = new Checkout();
            var res = await c.ExpressCheckoutOrder(CreateSellBody(uniqueId.ProductSKU, uniqueId.SerialNumber));

            return new API.DTO.Transactions
            {
                Message = res,
                Action = SerialNumberStatus.Sell,
                Item = uniqueId
            };
        }

        public API.DTO.DTOs.Checkout CreateSellBody(string sku, string serialNumber)
        {
            var c = new Checkout();
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();


            var dto = new API.DTO.DTOs.Checkout
            {
                CheckoutSessionID = null,
                IsCredicard = API.DTO.DTOs.PaymentMethod.Cash,
                AddressID = 0,
                ShippingMethod = "PickUp",
                SuccessUrl = ServiceConfig.SuccessUrl,
                FailUrl = ServiceConfig.FailUrl,
                CancelUrl = ServiceConfig.CancelUrl,
                PaymentMethod = API.DTO.DTOs.PaymentMethod.Cash,
                MeetUpDetailID = 1,
                MeetUpDate = DateTime.Now,
                Sku = sku,
                SerialNumber = serialNumber,
                CustomerId = 13,
                Quantity = 1,
                TransactionNumber = Guid.NewGuid().ToString("N"),
                TransactionNo = Guid.NewGuid().ToString("N"),
                Warranty = new API.DTO.DTOs.NewWarranty
                {
                    warranty_class = "Private",
                    plate_number = $"{this.GenerateName(2)}14{rnd1.Next(9)}{rnd2.Next(9)}{rnd3.Next(9)}",
                    date_expire = DateTime.UtcNow.AddYears(2),
                    date_purchase = DateTime.UtcNow,
                    sku = sku,
                    first_name = this.GenerateName(5),
                    last_name = this.GenerateName(5),
                    InvoiceNumber = DateTime.UtcNow.Ticks.ToString(),
                    mobile_number = $"0945586162{rnd1.Next(9)}",
                    serial = serialNumber
                }

            };


            return dto;
        }

        public string GenerateName(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }


            return builder.ToString().ToLower();
        }

        List<API.DTO.Transactions> Transactions = new List<Transactions>();
        List<Task<Transactions>> Task = new List<Task<Transactions>>();
        List<Transactions> GenTransactions = new List<Transactions>();
        private void BtnGenerateTransactions_Click(object sender, EventArgs e)
        {
            GenTransactions.Clear();
            listView1.Items.Clear();

            GenerateTransaction();

            foreach (var item in GenTransactions.OrderBy(o => o.Item.ProductSKU).ToList())
            {
                ListViewItem viewItem = new ListViewItem(item.Action.ToString());
                viewItem.SubItems.Add(item.Item.ProductSKU);
                viewItem.SubItems.Add(item.Item.SerialNumber);

                listView1.Items.Add(viewItem);
            }

            GetExpectedResult();
        }

        public async void ExecuteTransaction()
        {
            foreach (var item in GenTransactions)
            {
                switch (item.Action)
                {
                    case SerialNumberStatus.In:

                        Task.Add(InventoryIn(new Restock(new InventoryUniqueId()
                        {
                            ProductId = 3869,
                            SerialNumber = item.Item.SerialNumber,
                            Sku = item.Item.ProductSKU,
                            Quantity = 1,
                            InvoiceNumber = Guid.NewGuid().ToString("N"),
                            TransactionNumber = Guid.NewGuid().ToString("N"),
                            TransactionNo = Guid.NewGuid().ToString("N")
                        })));
                        break;
                    case SerialNumberStatus.Out:

                        var outSerial = item.Item;
                        outSerial.Quantity = -1;
                        outSerial.InvoiceNumber = Guid.NewGuid().ToString("N");
                        Task.Add(InventoryOut(new Restock(outSerial)));
                        break;
                    case SerialNumberStatus.Sell:

                        var sellSerial = item.Item;
                        Task.Add(Sell(sellSerial));
                        break;
                    default:
                        break;
                }
            }

            await System.Threading.Tasks.Task.WhenAll(Task);
        }

        public void GenerateTransaction()
        {
            //try
            //{
            Random rnd = new Random();
            for (int i = 0; i < Convert.ToUInt32(txttransCount.Text); i++)
            {
                var action = rnd.Next(2);

                var selectSerial = SelectSerialFromList();


                if (action == 0)
                {
                    string serialIn = Guid.NewGuid().ToString("N");
                    selectSerial.SerialNumber = serialIn;
                    ListOfSerials.Add(selectSerial);


                }


                GenTransactions.Add(new API.DTO.Transactions
                {
                    Action = (SerialNumberStatus)action,
                    Item = selectSerial
                });


                lblN.Text = $"In: {GenTransactions.Count(c => c.Action == SerialNumberStatus.In)}";
                lblout.Text = $"Out: {GenTransactions.Count(c => c.Action == SerialNumberStatus.Out)}";
                lblsell.Text = $"Sell: {GenTransactions.Count(c => c.Action == SerialNumberStatus.Sell)}";
            }


            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var res = await InventoryIn(new API.DTO.Restock
            {
                ProductId = 3869,
                SerialNumber = txtSerial.Text,
                Sku = txtsku.Text,
                Quantity = 1,
                InvoiceNumber = Guid.NewGuid().ToString("N")

            });

            MessageBox.Show(res.Message);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await InventoryOut(new Restock
            {
                Sku = txtsku.Text,
                ProductId = 3869,
                BranchId = 10,
                Quantity = -1,
                SerialNumber = txtSerial.Text,
                InvoiceNumber = Guid.NewGuid().ToString("N")
            });
            MessageBox.Show("Inventory Out successfully done.");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var checkoutData = CreateSellBody(txtsku.Text, txtSerial.Text);
            var api = new API.API.Checkout();
            var raw = await api.ExpressCheckoutOrder(checkoutData);
            MessageBox.Show(raw);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var item = SelectSerialFromList();
                txtSerial.Text = item.SerialNumber;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lblCurrentStock_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ListOfSerials.Count().Equals(0))
            {
                MessageBox.Show("Please reload sku stock first.");
            }
            else
            {
                ResetStocks();


            }
        }

        public async void ResetStocks()
        {
            try
            {
                var groupStocks = ListOfSerials.GroupBy(g => g.ProductSKU).Select(s => new { ProductSku = s.Key, Stocks = s.Count() });

                foreach (var item in ListOfSKU)
                {
                    int current = 0;
                    var getCurrentStocks = groupStocks.FirstOrDefault(s => s.ProductSku == item.Value);
                    if (getCurrentStocks == null)
                    {
                        current = 0;
                    }
                    else
                    { current = getCurrentStocks.Stocks; }

                    int @base = Convert.ToInt32(txtbasestocks.Text);

                    if (current > @base)
                    {
                        List<Task<Transactions>> TaskOut = new List<Task<Transactions>>();
                        int stockToDeduct = current - @base;
                        for (int i = 0; i < stockToDeduct; i++)
                        {
                            var outSerial = SelectSerialFromList(item.Value);
                            outSerial.Quantity = -1;
                            outSerial.InvoiceNumber = Guid.NewGuid().ToString("N");
                            outSerial.TransactionNo = Guid.NewGuid().ToString("N");
                            outSerial.TransactionNumber = Guid.NewGuid().ToString("N");
                            TaskOut.Add(InventoryOut(new Restock(outSerial)));
                        }
                        await System.Threading.Tasks.Task.WhenAll(TaskOut);
                    }
                    else
                    {
                        List<Task<Transactions>> TaskIn = new List<Task<Transactions>>();
                        int stockToDeduct = @base - current;
                        for (int i = 0; i < stockToDeduct; i++)
                        {
                            TaskIn.Add(InventoryIn(new API.DTO.Restock
                            {
                                ProductId = 3869,
                                SerialNumber = Guid.NewGuid().ToString("N"),
                                Sku = item.Value,
                                Quantity = 1,
                                InvoiceNumber = Guid.NewGuid().ToString("N"),
                                TransactionNo = Guid.NewGuid().ToString("N"),
                                TransactionNumber = Guid.NewGuid().ToString("N")
                            }));
                        }
                        await System.Threading.Tasks.Task.WhenAll(TaskIn);
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ExecuteTransaction();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadStocks();
        }

        List<SkuStocks> SkuStocks = new List<SkuStocks>();
        public void GetExpectedResult()
        {
            listView2.Items.Clear();
            SkuStocks.Clear();

           var stocks = ListOfSerials.GroupBy(s => s.ProductSKU).Select(s => new SkuStocks
            {
                SKU = s.Key,
                Stocks = s.Count()
            }).ToList();


            foreach (var item in stocks)
            {
                int baseStocks = Convert.ToInt32(txtbasestocks.Text);
                ListViewItem lst = new ListViewItem(item.SKU);
                lst.SubItems.Add(txtbasestocks.Text);

                var filterTransaction = GenTransactions.Where(w => w.Item.ProductSKU == item.SKU);
                int getOutAndSell = filterTransaction.Count(c => c.Action != SerialNumberStatus.In);
                int getIn = filterTransaction.Count(c => c.Action == SerialNumberStatus.In);

                baseStocks = baseStocks + getIn;
                baseStocks = baseStocks - getOutAndSell;
                
                SkuStocks.Add(item);
                lst.SubItems.Add(baseStocks.ToString());

                listView2.Items.Add(lst);
            }

           
        }

        private void txtsku_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class SkuStocks
    {
        public string SKU { get; set; }

        public int Stocks { get; set; }

        public int StocksToDeduct { get; set; }


    }


}


