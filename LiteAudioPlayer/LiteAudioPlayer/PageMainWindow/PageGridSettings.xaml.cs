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

namespace LiteAudioPlayer.PageMainWindow
{
    public partial class PageGridSettings : Page
    {
        MainWindow MainWindow_;
        public PageGridSettings(MainWindow MainWindow_)
        {
            InitializeComponent();
            this.MainWindow_ = MainWindow_;
        }

        private void SetColor(params string[] hex)
        {

            this.Resources["ColorMain"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[0]));
            this.Resources["ColorForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[2]));

            MainWindow_.Resources["ColorMain"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[0]));
            MainWindow_.Resources["ColorToolBar"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[1]));
            MainWindow_.Resources["ColorForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[3]));

            MainWindow_.PageGridHome_.Resources["ColorMain"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[0]));
            MainWindow_.PageGridHome_.Resources["ColorForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[2]));

            MainWindow_.PageGridList_.Resources["ColorMain"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[0]));
            MainWindow_.PageGridList_.Resources["ColorForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[2]));

            MainWindow_.PageGridOther_.Resources["ColorMain"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[0]));
            MainWindow_.PageGridOther_.Resources["ColorForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex[2]));

        }
        

        private void Button_Click(object sender, RoutedEventArgs e) => SetColor("#CCCCCC", "#303030", "#000000", "#ffffff");

        private void Button_Click_1(object sender, RoutedEventArgs e) => SetColor("#252424", "#131213", "#CCCCCC", "#CCCCCC");
        
    }
}
