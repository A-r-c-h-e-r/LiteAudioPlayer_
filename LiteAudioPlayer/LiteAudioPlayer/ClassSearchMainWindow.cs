using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LiteAudioPlayer
{
    public partial class MainWindow : Window
    {
        private void Search_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Search.IsReadOnly = false;
            LabelSearch.Visibility = Visibility.Hidden;
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                MessageBox.Show("!");
                Search.Text = "";
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length > 0) search = Search.Text;
        }
    }
}
