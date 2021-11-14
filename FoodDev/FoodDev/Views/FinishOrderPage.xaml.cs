using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;
using System.Net;
using System.Windows;
using FoodDev.Interfaces;
using PdfSharp.Fonts;
using FoodDev.Models;
using PdfSharp.Charting;
using Syncfusion.Drawing;
using System.IO;
using RandomSolutions;
using FoodDev.ViewModels;

namespace FoodDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinishOrderPage : ContentPage
    {
        CartViewModel cvm = new CartViewModel();
        /// <summary>
        /// Code to send Email and generate PDF
        /// </summary>
        public FinishOrderPage() 
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// PDF Generator
        /// </summary>
        private void ButtonPdfClicked(object sender, EventArgs e)
        {
            // PDF Generation
            // --------------
            string fileName = "TestPDF.pdf";
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            GlobalFontSettings.FontResolver.ResolveTypeface("Arial", true, true);
            XGraphics gfx = XGraphics.FromPdfPage(page);
            document.Save(fileName);
            Directory.GetFiles(fileName).Select(f => new FileInfo(f)).Where(f => f.LastAccessTime < DateTime.Now.AddMonths(-3)).ToList().ForEach(f => f.Delete());

            // Email in HTML format with pdf as attachment
            // -------------------------------------------
            string myHtmlMessage = "<html><body><h1>PDF Test</h1><p>My first pdf attachment.</p></body></html>";
            SmtpClient smtpClient = new SmtpClient();
            var basicCredential = new NetworkCredential("rabekofooddev", "Gent1234");
            using (MailMessage message = new MailMessage())
            {
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
                message.Attachments.Add(new Attachment(fileName));
                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception  ex)
                {
                    //Error, could not send the message
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}