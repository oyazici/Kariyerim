using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.Base
{
    public interface IGetAll<T>
    {
        List<T> GetAll();
    }
}
