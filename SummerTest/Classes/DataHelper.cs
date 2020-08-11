using SummerTest.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTest.Classes
{
    public class DataHelper
    {
        private static MarathonEntities _context = new MarathonEntities();

        public static MarathonEntities GetContext()
        {
            return _context;
        }
    }
}
