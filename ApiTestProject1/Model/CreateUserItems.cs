using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject1.Model
{

    public class CreateUserItems
    {
        public long id { get; set; }
        public String username { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String phone { get; set; }
        public int userStatus { get; set; }
    }

}
