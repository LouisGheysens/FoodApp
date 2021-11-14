using System;
using System.IO;
using Android.Content;
using Java.IO;
using Xamarin.Forms;
using System.Threading.Tasks;
using Android;
using Android.Content.PM;
using FoodDev.Droid;
using Xamarin.Essentials;

namespace FoodDev.Droid
{
    public interface ISave
    {
        //Method to save document as a file and view the saved document
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
    }
}