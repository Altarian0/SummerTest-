using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SummerTest.Classes
{
    public class DropImage
    {
        public string Path { get; set; }
        public string ImageName
        {
            get
            {
                string[] name = Path.Split(new char[] { '\\' });
                return name[name.Length-1];
            }
        }
        public BitmapImage ImagePath
        {
            get
            {
                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(Path, UriKind.RelativeOrAbsolute);
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        /// <summary>
        /// Получает имя файла из пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetNameFromPath(string path)
        {
            string[] name = path.Split(new char[] { '\\' });
            return name[name.Length - 1];
        }
    }
}
