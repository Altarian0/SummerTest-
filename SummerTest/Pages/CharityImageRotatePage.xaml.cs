using Microsoft.Win32;
using SummerTest.Classes;
using SummerTest.Database;
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
using System.Threading;

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for CharityImageRotatePage.xaml
    /// </summary>
    public partial class CharityImageRotatePage : Page
    {
        private TransformedBitmap _transformedBitmap = new TransformedBitmap();
        private Charity _selectedCharity = new Charity();
        private int _rotate = 0;
        public CharityImageRotatePage()
        {
            InitializeComponent();

            RefreshPage();
        }

        private void RefreshPage()
        {
            DataHelper.GetContext().ChangeTracker.Entries().ToList().ForEach(n => n.Reload());

            CharityList.ItemsSource = null;
            CharityList.ItemsSource = DataHelper.GetContext().Charity.ToList();
        }

        /// <summary>
        /// Поворот пикчи вправо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RigthButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharityList.SelectedItem == null)
                return;

            _transformedBitmap = new TransformedBitmap();

            _transformedBitmap.BeginInit();

            if (_selectedCharity.CharityImage is TransformedBitmap)
            {
                _transformedBitmap.Source = _selectedCharity.CharityImage as TransformedBitmap;
            }
            else
            {
                _transformedBitmap.Source = _selectedCharity.CharityImage as BitmapImage;
            }

            if ((sender as Button).Name == "RigthButton")
            {
                _rotate += 90;
               
            }
            else if((sender as Button).Name == "LeftButton")
            {
                _rotate -= 90;
            }

            Console.WriteLine(_rotate);
            RotateTransform transform = new RotateTransform(_rotate);

            _transformedBitmap.Transform = transform;
            _transformedBitmap.EndInit();

            CharityImage.Source = _transformedBitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(_transformedBitmap));

            using (FileStream fs = new FileStream(@"..\..\Resource\" + _selectedCharity.CharityLogo, FileMode.Create))
            {
                bitmapEncoder.Save(fs);
            }

            _selectedCharity.CharityImage = _transformedBitmap;
            CharityList.Items.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Charity)CharityList.SelectedItem == null)
                return;

            _selectedCharity = (Charity)CharityList.SelectedItem;

            CharityImage.Source = _selectedCharity.CharityImage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private BitmapImage GetImageFromPath(string path)
        {
            BitmapImage bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }
    }
}
