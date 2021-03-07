using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class PageGridHome : Page
    {
        MainWindow MainWindow_;
        public PageGridHome(MainWindow MainWindow_)
        {
            InitializeComponent();
            this.MainWindow_ = MainWindow_;

           SetCorrectSizeLabel();
        }

        public void SetCorrectSizeLabel()
        {
            LabelNameAudio.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            if (LabelNameAudio != null && MainWindow_.Width <= LabelNameAudio.DesiredSize.Width) LabelDots.Content = "...";
            else LabelDots.Content = "";
        }
    }
}
