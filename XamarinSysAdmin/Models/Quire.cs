using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSysAdmin.Models
{
   public class Quire
    {
        public int IdQuire { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SpecId { get; set; }
        public Nullable<System.DateTime> Date1 { get; set; }
        public string Theme { get; set; }
        public string Desc { get; set; }
        public Nullable<int> Status { get; set; }
        public string Answer { get; set; }
        public Nullable<System.DateTime> Date2 { get; set; }

        [JsonIgnore]
        public string StatusText
        {
            get
            {
                if (Status == 0) return "Отправлен";
                else if (Status == 1) return  "На рассмотрение";
                else return  "Завершен";
            }
        }
        [JsonIgnore]
        public string Date1D
        {
            get
            {
                return Date1.Value.ToString("D");
            }
        }
        [JsonIgnore]
        public string Date2D
        {
            get
            {
                if (Date2 == null)
                {
                    return "Ответ еще не дан";
                }
                else
                {
                    return Date2.Value.ToString("D");
                }
                
            }
        }

       
    }
}
