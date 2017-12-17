using DALSmartVideoDB;
using SmartVideoDBDTO;
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
        public UtilisateursDTO findUser(string E)
        {
            return DalSingletonSmartVideoDB.Singleton().findUser(E);
        }
        public void Update(UtilisateursDTO user)
        {
            DalSingletonSmartVideoDB.Singleton().Update(user);
        }
    }
}
