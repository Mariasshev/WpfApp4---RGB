using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Brush> Colors { get; set; } = new ObservableCollection<Brush>();

        public MainWindow()
        {
            InitializeComponent();
            ColorsList.ItemsSource = Colors;
            UpdatePreview();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var color = GetColor();
            if (!Colors.Contains(color))
            {
                Colors.Add(color);
            }
            AddButton.IsEnabled = false; // Делает кнопку неактивной, если цвет уже добавлен
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.Tag is Brush color)
            {
                Colors.Remove(color);
            }
        }

        private Brush GetColor()
        {
            byte alpha = (byte)(AlphaCheckBox.IsChecked == true ? AlphaSlider.Value : 255);
            byte red = (byte)(RedCheckBox.IsChecked == true ? RedSlider.Value : 0);
            byte green = (byte)(GreenCheckBox.IsChecked == true ? GreenSlider.Value : 0);
            byte blue = (byte)(BlueCheckBox.IsChecked == true ? BlueSlider.Value : 0);
            return new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
        }

        private void UpdatePreview()
        {
            AddButton.IsEnabled = true;
        }
    }
}