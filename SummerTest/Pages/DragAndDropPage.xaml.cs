using SummerTest.Classes;
using SummerTest.Database;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DragAndDropPage.xaml
    /// </summary>
    public partial class DragAndDropPage : Page
    {
        private Charity _selectedCharity = new Charity();
        public DragAndDropPage()
        {
            InitializeComponent();

            FirstList.ItemsSource = DataHelper.GetContext().Charity.ToList();
        }

        private void FirstList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCharity = (Charity)FirstList.SelectedItem;
            DragDrop.DoDragDrop(FirstList, _selectedCharity.CharityName, DragDropEffects.Copy);
        }

        private void SecondList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void SecondList_Drop(object sender, DragEventArgs e)
        {
            SecondList.Items.Add(_selectedCharity);
     
        }

        private void FirstList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
