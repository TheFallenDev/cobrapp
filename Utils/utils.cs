using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Utils
{
    public static class MyUtils
    {
        public static string DateFixer(string date)
        {
            string[] array = date.Split('/');
            string[] newArray = new string[array.Length];
            int counter = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                newArray[counter] = array[i];
                counter++;
            }
            string newDate = string.Join("/", newArray);
            return newDate;
        }
    }

    
}
