using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.Core
{
    public static class Helpers
    {
        public static void ParameterLoad<T>(this SqlCommand cmd, T entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                cmd.Parameters.Add(new SqlParameter("@" + property.Name, property.GetValue(entity)));
            }
        }
    }
}
