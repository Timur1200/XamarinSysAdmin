using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSysAdmin.Models
{
    class Spec : Personal
    {
        public int IdSpec { get; set; }
        public Nullable<int> Rol_Id { get; set; }
        public string FIo { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public Nullable<bool> Status { get; set; }

        public int Access { get; set; }
        public string Role { get; set; }

        public string Fio { get
            {
                return FIo;
            } }
    }
}
