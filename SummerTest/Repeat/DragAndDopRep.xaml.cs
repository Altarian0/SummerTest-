using SummerTest.Classes;
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

namespace SummerTest.Repeat
{
    /// <summary>
    /// Interaction logic for DragAndDopRep.xaml
    /// </summary>
    public partial class DragAndDopRep : Page
    {
        public DragAndDopRep()
        {
            InitializeComponent();
        }

        private void List1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void List1_Drop(object sender, DragEventArgs e)
        {
            string[] dropData = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var path in dropData)
            {
                List1.Items.Add(new DropImage { Path = path });
            }
        }
    }
}
