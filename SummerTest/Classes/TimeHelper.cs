using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SummerTest.Classes
{
    public class TimeHelper
    {
        /// <summary>
        /// Метод для установки времени под окном
        /// </summary>
        /// <param name="label"></param>
        public  static void SetTime(Label label)
        {
            label.Content = GetTime();
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("m") + " " + DateTime.Now.ToString("yyyy") + " " + DateTime.Now.ToString("t");
        }
    }
}
