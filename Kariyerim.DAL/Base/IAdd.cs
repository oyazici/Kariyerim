using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.Base
{
    public interface IAdd<T>
    {
        int Add(T entity);
    }
}
