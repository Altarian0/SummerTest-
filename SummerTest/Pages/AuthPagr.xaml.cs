using SummerTest.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for AuthPagr.xaml
    /// </summary>
    public partial class AuthPagr : Page
    {
        public AuthPagr()
        {
            InitializeComponent();



        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var user = DataHelper.GetContext().User.Where(n=>n.Email == LoginBox.Text && n.Password == PasswordBox.Text).Single();
                MessageBox.Show("Успешный вход");
            }
            catch
            {
                MessageBox.Show("Неправильные логин или пароль");
            }


        }
    }
}
