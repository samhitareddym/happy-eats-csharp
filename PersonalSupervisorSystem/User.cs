using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSupervisorSystem
{
    public abstract class User
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        protected User(string id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }
        public abstract void ShowMenu();
    }

}

