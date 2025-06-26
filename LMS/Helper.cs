using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
   public static class Helper
    {
        public static string GetPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\BookList.json");
        }

    }
}
