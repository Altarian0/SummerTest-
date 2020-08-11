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
    /// Interaction logic for PhoneMask.xaml
    /// </summary>
    public partial class PhoneMask : UserControl
    {
        public string CountryCode
        {
            get
            {
                return FirstText.MainTextBox.Text;
            }
        }

        public string RegionCode
        {
            get
            {
                return SecondText.MainTextBox.Text;
            }
        }

        public string FirstNum
        {
            get
            {
                return ThirdText.MainTextBox.Text;
            }
        }
        public string SecondNum
        {
            get
            {
                return FourthText.MainTextBox.Text;
            }
        }
        public string ThirdNum
        {
            get
            {
                return FifthText.MainTextBox.Text;
            }
        }

        public string PhoneNum
        {
            get
            {
                return $"+{ FirstText.MainTextBox.Text} ({ SecondText.MainTextBox.Text}) { ThirdText.MainTextBox.Text}-{ FourthText.MainTextBox.Text}-{ FifthText.MainTextBox.Text}";
            }
        }

        public PhoneMask()
        {
            InitializeComponent();

            FirstText.MaxCountNum = 1;
            SecondText.MaxCountNum = 3;
            ThirdText.MaxCountNum = 3;
            FourthText.MaxCountNum = 2;
            FifthText.MaxCountNum = 2;

            FirstText.NextTextBox = SecondText.MainTextBox;
            SecondText.NextTextBox = ThirdText.MainTextBox;
            ThirdText.NextTextBox = FourthText.MainTextBox;
            FourthText.NextTextBox = FifthText.MainTextBox;

            SecondText.PrevTextBox = FirstText.MainTextBox;
            ThirdText.PrevTextBox = SecondText.MainTextBox;
            FourthText.PrevTextBox = ThirdText.MainTextBox;
            FifthText.PrevTextBox = FourthText.MainTextBox;
        }

        

    }
}
