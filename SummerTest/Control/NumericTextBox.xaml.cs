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

namespace SummerTest.Control
{
    /// <summary>
    /// Interaction logic for NumericTextBox.xaml
    /// </summary>
    public partial class NumericTextBox : UserControl
    {
        public int MaxCountNum { get; set; }
        public TextBox NextTextBox { get; set; }
        public TextBox PrevTextBox { get; set; }
        public NumericTextBox()
        {
            InitializeComponent();
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == MaxCountNum)
            {
                if (NextTextBox == null)
                    return;

                NextTextBox.Focus();
            }
            else if (((TextBox)sender).Text.Length > MaxCountNum)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, MaxCountNum);
            }
            else if (((TextBox)sender).Text.Length == 0)
            {
                if (PrevTextBox == null)
                    return;

                PrevTextBox.Focus();
            }

        }

        private void MainTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (((TextBox)sender).Text.Length == 0)
                {
                    if (PrevTextBox == null)
                        return;

                    PrevTextBox.Focus();
                }
            }
        }

        private void MainTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
