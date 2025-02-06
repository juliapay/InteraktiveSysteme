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
using System.Windows.Shapes;

namespace MyCampus02WPFApp
{
    /// <summary>
    /// Interaction logic for MyProductWindow.xaml
    /// </summary>
    public partial class MyProductWindow : Window
    {
        public MyProductWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CheckBox myNewCheckBox = new CheckBox();
            myNewCheckBox.Content = "Dummy";
            myNewCheckBox.IsChecked= true;
            myNewCheckBox.Background = new SolidColorBrush(Color.FromArgb(255, 255, 100, 0));
            MyLastStackPanel.Children.Add(myNewCheckBox);

        }
    }
}
