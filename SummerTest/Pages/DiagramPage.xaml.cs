using SummerTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SummerTest.Pages
{
    /// <summary>
    /// Interaction logic for DiagramPage.xaml
    /// </summary>
    public partial class DiagramPage : Page
    {
        public DiagramPage()
        {
            InitializeComponent();

            MainDiagram.ChartAreas.Add(new ChartArea("Main"));

            Series series = new Series("MainSeries")
            {
                IsValueShownAsLabel = true
            };

            MainDiagram.Series.Add(series);

            List.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem == null)
                return;
            var chartType = (SeriesChartType)List.SelectedItem;

            Series series = MainDiagram.Series.FirstOrDefault();
            series.ChartType = chartType;
            series.Points.Clear();

            foreach (var country in DataHelper.GetContext().Country)
            {
                series.Points.AddXY(country.CountryCode, DataHelper.GetContext().Runner.Where(n=>n.CountryCode == country.CountryCode).Count());
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(DiagramGrid, "Диаграммы");
            printDialog.ShowDialog();
        }
    }
}
