using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Homefit.Interfaces
{
    public interface IPhotoPickerService
    {
        string GetUriAsync();
        Task<Stream> GetImageStreamAsync();
        void SavePicture(string name, Stream data, string location = "temp");
    }
}
