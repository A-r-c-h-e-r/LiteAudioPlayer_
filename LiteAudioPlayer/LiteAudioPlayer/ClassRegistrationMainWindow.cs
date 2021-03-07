using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LiteAudioPlayer
{
    public partial class MainWindow : Window
    {
        private void EntryButton_MouseDown(object sender, RoutedEventArgs e) // [Кнопка регистрации] --> 
        {
            LogInWindow LogInWindowSize = new LogInWindow(0, 0, this);

            double left = (this.Left + (this.Width / 2)) - LogInWindowSize.Width / 2;
            double top = (this.Top + (this.Height / 2)) - LogInWindowSize.Height / 2;
            LogInWindowSize = null;

            LogInWindow LogInWindow_ = new LogInWindow(left, top, this);
            LogInWindow_.Show();
        }
    }
}
