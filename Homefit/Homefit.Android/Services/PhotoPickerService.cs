using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Homefit.Droid.Services;
using Homefit.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]
namespace Homefit.Droid.Services
{

    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Stream> GetImageStreamAsync()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Choisir une image"),
                MainActivity.PickImageId);

            

            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
        public string GetUriAsync()
        {
            return MainActivity.Instance.PickUriTaskCompletionSource;
        }
        public void SavePicture(string name, Stream data, string location = "temp")
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Profils", location);
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (data)
                {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);
            }
        }
    }
}