using DALSmartVideoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSmartVideoDB
{
    public class BLLSmartVideo
    {
        public String Login(string E, string pass)
        {
            return DalSingletonSmartVideoDB.Singleton().Login(E, pass);
        }
    }
}
