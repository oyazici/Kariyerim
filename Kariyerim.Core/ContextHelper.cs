using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.Core
{
    public class ContextHelper
    {
        private static int currentUser;

        public static void SetUser(int userId)
        {
            currentUser = userId;
        }

        public static int CurrentUser { get { return currentUser; } }

    }
}
