﻿using Newtonsoft.Json;
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
        private string GlobalSku = "PEPSI-PINAS";
        public InventoryForm()
        {
            InitializeComponent();
        }






        private async void button3_Click(object sender, EventArgs e)
        {
            var api = new API.API.Inventory();
            var result = await api.GetBranchInventory(txtSku.Text);
            var filter = JsonConvert.DeserializeObject<List<API.DTO.InventoryUniqueId>>(result);
            ListOfSerials = filter.Where(w => w.Status == SerialNumberStatus.In).OrderBy(o => o.ID).ToList();
            MessageBox.Show($"{ListOfSerials.Count()} Serial number loaded.");

        }


        public async Task Process(SerialNumberStatus serialNumberStatus)
        {
            switch (serialNumberStatus)
            {
                case SerialNumberStatus.In:

                    break;
                case SerialNumberStatus.Out:
                    break;
                case SerialNumberStatus.Sell:
                    break;
                default:
                    break;
            }

        }

        public async Task<Transactions> InventoryIn(Restock restock)
        {

            
            var inv = new API.API.Inventory();
            var logic = await inv.Restock(restock);
            return new API.DTO.Transactions {
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
                var getInitial = ListOfSerials.FirstOrDefault();
                var getLast = ListOfSerials.LastOrDefault();
                var entity = new API.DTO.InventoryUniqueId();



                while (entity.ID.Equals(0))
                {
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

        public int GetRandom(int start, int end)
        {
            Random rnd = new Random();

            return rnd.Next(start, end);
        }

        public async Task<Transactions> Sell(InventoryUniqueId uniqueId)
        {
            var c = new Checkout();
            var res = await c.ExpressCheckoutOrder(CreateSellBody(txtSku.Text, uniqueId.SerialNumber));

            return new API.DTO.Transactions {
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
                Warranty = new API.DTO.DTOs.NewWarranty
                {
                    warranty_class = "Private",
                    plate_number = $"{this.GenerateName(2)}14{rnd1.Next(9)}{rnd2.Next(9)}{rnd3.Next(9)}",
                    date_expire = DateTime.UtcNow.AddYears(2),
                    date_purchase = DateTime.UtcNow,
                    sku = txtSku.Text,
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
        private async void BtnGenerateTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Clear();
                Transactions.Clear();
                listView1.Items.Clear();
                Random rnd = new Random();
                for (int i = 0; i < Convert.ToInt32(txttransCount.Text); i++)
                {
                    
                    var trans = (SerialNumberStatus)rnd.Next(0, 3);
                    
                    switch (trans)
                    {
                        case SerialNumberStatus.In:
                            var serial = Guid.NewGuid().ToString("N");
                            Task.Add(InventoryIn(new Restock(new InventoryUniqueId()
                            {
                                ProductId = 3869,
                                SerialNumber = serial,
                                Sku = txtSku.Text,
                                Quantity = 1

                            })));
                            break;
                        case SerialNumberStatus.Out:
                            
                            var outSerial = SelectSerialFromList();
                            outSerial.Quantity = -1;
                            Task.Add(InventoryOut(new Restock(outSerial)));
                            break;
                        case SerialNumberStatus.Sell:
                            
                            var sellSerial = SelectSerialFromList();
                           
                            Task.Add(Sell(sellSerial));
                            break;
                        default:
                            break;
                    }
                  
                }

                var finalresult = await System.Threading.Tasks.Task.WhenAll(Task);
                foreach (var item in finalresult)
                {
                    ListViewItem lvi = new ListViewItem(item.Action.ToString());
                    lvi.SubItems.Add(item.Item.SerialNumber);
                    lvi.SubItems.Add(item.Message);

                    listView1.Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

       

        private async void button1_Click(object sender, EventArgs e)
        {
            var res = await InventoryIn(new API.DTO.Restock
            {
                ProductId = 3869,
                SerialNumber = txtSerial.Text,
                Sku = txtSku.Text,
                Quantity = 1,
                InvoiceNumber = Guid.NewGuid().ToString("N")

            });

            MessageBox.Show(res.Message);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await InventoryOut(new Restock
            {
                Sku = txtSku.Text,
                ProductId = 3869,
                BranchId = 10,
                Quantity = -1,
                SerialNumber = txtSerial.Text
                , InvoiceNumber = Guid.NewGuid().ToString("N")
            });
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var checkoutData = CreateSellBody(txtSku.Text, txtSerial.Text);
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
    }
}