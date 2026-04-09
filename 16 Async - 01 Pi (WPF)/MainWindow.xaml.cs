using System.Windows;
using System.Windows.Input;

namespace _17._01___Pi__WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        private Progress<double> progressReporter;

        public MainWindow()
        {
            InitializeComponent();
            AbbrechenButton.IsEnabled = false;
            progressReporter = new Progress<double>(value =>
            {
                Bar.Value = value;
            });

        }

        private async void BerechnungStarten(object sender, RoutedEventArgs e)
        {
            BerechnenButton.IsEnabled = false;
            AbbrechenButton.IsEnabled = true;
            Bar.Visibility = Visibility.Visible;
            Bar.Value = 0;
            this.Cursor = Cursors.Wait;
            ErgebnisLabel.Content = "Berechnung wird ausgeführt";
            double ergebnis = await Task.Run(() => ComputePi(cts.Token, progressReporter), cts.Token);
            if (ergebnis == -1) ErgebnisLabel.Content = "Abgebrochen";
            else ErgebnisLabel.Content = ergebnis;
            this.Cursor = Cursors.Arrow;
            Bar.Visibility = Visibility.Collapsed;
            AbbrechenButton.IsEnabled = false;
            BerechnenButton.IsEnabled = true;

        }

        double ComputePi(CancellationToken token, IProgress<double> progress)
        {
            double sum = 0.0;
            const double step = 1e-9;
            const long totalIterations = 1_000_000_000;
            for (int i = 0; i < totalIterations; i++)
            {
                if (token.IsCancellationRequested) { return -1; }
                if (i % (totalIterations / 100) == 0)
                {
                    progress.Report((double)i / totalIterations * 100);
                }
                double x = (i + 0.5) * step;
                sum += 4.0 / (1.0 + x * x);
            }
            return sum * step;
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            AbbrechenButton.IsEnabled = false;
            cts.Cancel();
            cts = new CancellationTokenSource();
        }
    }
}