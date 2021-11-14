using FoodDev.Models;
using FoodDev.Services;
using FoodDev.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using RandomSolutions;
using System.Net.Mail;
using System.Net;
using Spire.Xls;

namespace FoodDev.ViewModels
{
    public class CartViewModel: BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }

        private int _TotalCost;

        public int TotalCost
        {
            set
            {
                _TotalCost = value;
            }
            get
            {
                return _TotalCost;
            }
        }

        public Command PlaceOrdersCommand { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItems();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
            ToPdf();
        }

        private async Task PlaceOrdersAsync()
        {
            var id = await new OrderService().PlaceOrderAsync() as string;
            RemoveItemsFromCart();
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersView(id));
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
        }



        private void LoadItems()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach(var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Message = item.Message,
                    Client = item.Client
                }) ;
            }
        }

        //DATA UIT DE OBERSAVBLE COLLECTION IN PDF


        //GENEREER RANDOM PDF NAAM

        //VERSTUUR DEZE 



        public void ToPdf() {
            ToCsv(CartItems);
            for (int i = 0; i < CartItems.Count; i++) {
                UserCartItem uci = CartItems[i];
                Workbook wb = new Workbook();
                wb.LoadFromFile("SampleCSVFile.csv", ",", 1, 1);
                wb.ConverterSetting.SheetFitToPage = true;
                Worksheet sheet = wb.Worksheets[0];
                for (int k = 1; k < sheet.Columns.Length; k++) {
                    sheet.AutoFitColumn(k);
                }
                sheet.SaveToPdf("toPDF.pdf");
                System.Diagnostics.Process.Start("toPDF.pdf");
            }

            // Email in HTML format with pdf as attachment
            // -------------------------------------------
            string myHtmlMessage = "<html><body><h1>PDF Test</h1><p>My first pdf attachment.</p></body></html>";
            SmtpClient smtpClient = new SmtpClient();
            var basicCredential = new NetworkCredential("rabekofooddev", "Gent1234");
            using (MailMessage message = new MailMessage()) {
                MailAddress fromAddress = new MailAddress("rabekofooddev@gmail.com");

                smtpClient.Host = "Smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = basicCredential;

                message.From = fromAddress;
                message.Subject = "Bestelling PDF";
                // Set IsBodyHtml to true means you can send HTML email.
                message.IsBodyHtml = true;

                message.Body = myHtmlMessage;
                message.To.Add("info@rabeko.be");
                //message.Attachments.Add(new Attachment());
                try {
                    smtpClient.Send(message);
                }
                catch (Exception ex) {
                    //Error, could not send the message
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> list) {
            var fields = typeof(T).GetFields();
            var properties = typeof(T).GetProperties();

            foreach (var @object in list) {
                yield return string.Join(",",
                                         fields.Select(x => (x.GetValue(@object) ?? string.Empty).ToString())
                                               .Concat(properties.Select(p => (p.GetValue(@object, null) ?? string.Empty).ToString()))
                                               .ToArray());
            }
        }
    }
}
