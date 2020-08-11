using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for ImageRotation.xaml
    /// </summary>
    public partial class ImageRotation : Page
    {
        public ImageRotation()
        {
            InitializeComponent();
        }
        string path = "";
        int rotate = 0;
        BitmapImage saveImage = new BitmapImage();
        TransformedBitmap saveTransformed = new TransformedBitmap();
        private BitmapImage GetImageFromPath(string path)
        {
            BitmapImage bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            return bitmapImage;
        }

        /// <summary>
        /// Открыть изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg files (*.jpg)|*.jpg";

            openFileDialog.ShowDialog();

            if (openFileDialog.FileName == "")
            {
                return;
            }

            path = openFileDialog.FileName;
            TestImage.Source = GetImageFromPath(path);

            saveTransformed.BeginInit();
            saveTransformed.Source = GetImageFromPath(path);
            saveTransformed.EndInit();

        }

        private void RigthButton_Click(object sender, RoutedEventArgs e)
        {


        }

        /// <summary>
        /// Поворот изображения направо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RigthButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                TransformedBitmap transformedBitmap = new TransformedBitmap();
                transformedBitmap.BeginInit();
                transformedBitmap.Source = GetImageFromPath(path);
                rotate += 90;
                RotateTransform rotateTransform = new RotateTransform(rotate);
                transformedBitmap.Transform = rotateTransform;
                transformedBitmap.EndInit();

                TestImage.Source = transformedBitmap;
                saveTransformed = transformedBitmap;

            }
            catch
            {
                MessageBox.Show("Image is not found!");
            }
        }

        /// <summary>
        /// Поворот изображения налево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TransformedBitmap transformedBitmap = new TransformedBitmap();
                transformedBitmap.BeginInit();
                transformedBitmap.Source = GetImageFromPath(path);
                rotate -= 90;
                RotateTransform rotateTransform = new RotateTransform(rotate);
                transformedBitmap.Transform = rotateTransform;
                transformedBitmap.EndInit();

                TestImage.Source = transformedBitmap;

                saveTransformed = transformedBitmap;

            }
            catch
            {
                MessageBox.Show("Image is not found!");
            }
        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePicButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "jpg files (*.jpg)|*.jpg";

                string name = saveFileDialog.FileName;

                var encoder = new JpegBitmapEncoder();

                encoder.Frames.Add(BitmapFrame.Create(saveTransformed));

                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName == "")
                {
                    MessageBox.Show("Вы не выбрали путь сохранения!");
                    return;
                }

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    encoder.Save(fs);
                }

            }
            catch
            {
                MessageBox.Show("Вы не выбрали файл!");
            }
           
        }

        /// <summary>
        /// Вывод на печать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            var encoder = new JpegBitmapEncoder();

            printDialog.ShowDialog();
            printDialog.PrintVisual(TestImage, "123");
        }
    }
}
