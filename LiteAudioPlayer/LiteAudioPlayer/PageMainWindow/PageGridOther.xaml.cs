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
    /// <summary>
    /// Логика взаимодействия для PageGridOther.xaml
    /// </summary>
    public partial class PageGridOther : Page
    {
        MainWindow MainWindow_;
        public PageGridOther(MainWindow MainWindow_)
        {
            InitializeComponent();
            this.MainWindow_ = MainWindow_;
        }
    }
}
