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

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for CharityDragDropPage.xaml
    /// </summary>
    public partial class CharityDragDropPage : Page
    {
        private Charity _changeChar = new Charity();
        public CharityDragDropPage()
        {
            InitializeComponent();

            RefreshPage();
        }

        /// <summary>
        /// Обновление списков с организациями
        /// </summary>
        private void RefreshPage()
        {
            FirstList.ItemsSource = DataHelper.GetContext().Charity.Where(n => n.IsActive == true).ToList();
            SecondList.ItemsSource = DataHelper.GetContext().Charity.Where(n => n.IsActive == false).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _changeChar = (Charity)FirstList.SelectedItem;

            if (_changeChar == null)
                return;

            DragDrop.DoDragDrop(this, _changeChar, DragDropEffects.Move);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondList_Drop(object sender, DragEventArgs e)
        {
            if (_changeChar == null)
                return;

            _changeChar.IsActive = false;
            DataHelper.GetContext().SaveChanges();
            RefreshPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _changeChar = (Charity)SecondList.SelectedItem;

            if (_changeChar == null)
                return;

            DragDrop.DoDragDrop(this, _changeChar, DragDropEffects.Move);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void FirstList_Drop(object sender, DragEventArgs e)
        {
            if (_changeChar == null)
                return;

            _changeChar.IsActive = true;
            DataHelper.GetContext().SaveChanges();
            RefreshPage();
        }
    }
}
