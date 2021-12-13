using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace XamarinSysAdmin.Models
{
    class Storage
    {
        public int IdMaterial { get; set; }
        public string MaterialName { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Img { get; set; }
        [JsonIgnore]
        public ImageSource Img1
        {
            get
            {if(Img == null)
                {
                    return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Photo.Img)));
                }
                return ImageSource.FromStream(()=> new MemoryStream(Convert.FromBase64String(Img)));
            }
        }
    }
}
