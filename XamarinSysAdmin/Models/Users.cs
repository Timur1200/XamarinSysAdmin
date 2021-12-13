using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSysAdmin.Models
{
    class Users : Personal
    {
        public int IdUser { get; set; }
        public Nullable<int> Rol_Id { get; set; }
        public string Fio { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public int Access { get; set; }
        public string Role { get; set; }
    }
}
