using SummerTest.Repeat;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private DispatcherTimer _unTimer = new DispatcherTimer();

        private int _time = 20;
        private int _unTime = 0;

        public StartPage()
        {
            InitializeComponent();

            UnTimerSetting();
            //TimerSetting();

            if (CheckTimerFile() != 0)
            {
                _unTime = CheckTimerFile();
                MessageBox.Show("Закрытие программы не спасет тебя!", "Казнь!!!", MessageBoxButton.OK, MessageBoxImage.Error);

                this.IsEnabled = false;
                _unTimer.Start();
            }
            else
            {
                _timer.Start();
            }

        }

        /// <summary>
        /// Настройки таймера разблокировки
        /// </summary>
        private void UnTimerSetting()
        {
            _unTimer.Interval = new TimeSpan(0, 0, 1);
            _unTimer.Tick += (s, e) =>
            {
                _unTime--;
                ExecTimeLabel.Content = _unTime;

                if (_unTime <= 0)
                {
                    _unTimer.Stop();
                    this.IsEnabled = true;

                    using (StreamWriter streamWriter = new StreamWriter(@"..\..\SupportFiles\ExecTime.txt"))
                    {
                        streamWriter.Write("0");
                    }
                    _timer.Start();
                }
            };
        }

        /// <summary>
        /// Настройки таймера для блокирования окна
        /// </summary>
        private void TimerSetting()
        {
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += (s, e) =>
            {
                _time--;
                ExecTimeLabel.Content = _time;

                if (_time <= 0)
                {
                    this.IsEnabled = false;
                    MessageBox.Show("Казнь!!!", "Казнь!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    using (FileStream fs = new FileStream(@"..\..\SupportFiles\ExecTime.txt", FileMode.OpenOrCreate))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fs))
                        {
                            streamWriter.Write("");
                        }
                    }
                    _timer.Stop();

                    _unTime = 20;
                    _unTimer.Start();
                }
            };
        }

        /// <summary>
        /// Проверка блокировки с последнего выхода
        /// </summary>
        /// <returns></returns>
        private int CheckTimerFile()
        {
            using (FileStream fs = new FileStream(@"..\..\SupportFiles\ExecTime.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader streamReader = new StreamReader(fs))
                {
                    var time = streamReader.ReadToEnd();

                    if (time != "")
                        return int.Parse(time);

                    return 0;
                }
            }

        }

        /// <summary>
        /// Типова авторизация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        /// <summary>
        /// Перехват закрытия окна и сохранение данных блокировки в файле
        /// </summary>
        public void PageClosed()
        {
            using (FileStream fs = new FileStream(@"..\..\SupportFiles\ExecTime.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fs))
                {
                    streamWriter.Write(_unTime);
                }
            }
        }

        /// <summary>
        /// Продление времени таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _time += 10;
            MessageBox.Show("Ты продлил время казни на 10 секунд!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DragAndDropPage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreningButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ImageRotation());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DragAndDopRep());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPagr());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityDragDrop_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharityDragDropPage());
        }

        private void RotateImageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharityImageRotatePage());
        }
    }
}