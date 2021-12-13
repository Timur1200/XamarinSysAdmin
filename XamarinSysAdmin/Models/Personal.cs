using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XamarinSysAdmin.ViewModels;

namespace XamarinSysAdmin.Models
{
    class Personal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            
            var tmp = PropertyChanged;
            if (tmp != null)
                tmp(this, new PropertyChangedEventArgs(propertyName));
        }


        private static Personal session; 
        public static Personal Session {
            get{ return session; } 
            set
            {
                if (session != value)
                {
                    session = value;
                   
                }
            } 
        }

        public static void Auth(Spec s)
        {
            Session = s;
            Session.Id = s.IdSpec;
            Session.Acc = s.Access;
            AppShell.Reload();
        }

        public static void Auth(Users u)
        {
            Session = u;
            Session.Id = u.IdUser;
            Session.Acc = u.Access;
             AppShell.Reload();
        }

        public int Acc = 0;
        public int Id;

       
        

      
    }
}
