using Kariyerim.Core;
using Kariyerim.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.BLL
{
    public class IocDal
    {
        public static void RegisterDal()
        {
            Ioc.Register<IIsIlaniDal, IsIlaniDal>();
        }
    }
}
