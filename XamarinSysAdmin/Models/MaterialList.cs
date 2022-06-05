using System;
using System.Collections.Generic;
using System.Text;
using XamarinSysAdmin.Services;

namespace XamarinSysAdmin.Models
{
    public  class MaterialList
    {
        public int IdList { get; set; }
        public Nullable<int> ReqId { get; set; }
        public Nullable<int> MaterId { get; set; }
        public Nullable<int> AmountInList { get; set; }

        private static List<Storage> str = RequestsAPI.get().SelectStorage();
        public string Name
        {
            get
            {
               foreach(var a in str)
                {
                    if (a.IdMaterial == MaterId) return a.MaterialName;
                }
                return "неизвестно";
            }
        }
        
   
    }
}
