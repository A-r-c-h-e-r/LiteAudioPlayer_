using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace LiteAudioPlayer
{
    public partial class MainWindow : Window
    {
        DispatcherTimer TimerList;
        public bool ActiveMouseList = false, CheckAnimationListWork = false;
        public double GridCurrentFolderListHeight, AnimationHeight = 0;

        private void SetSizeCurrentFolderList()
        {
            GridCurrentFolderList.Height = GridCurrentFolderListHeight = this.ActualHeight / Math.Sqrt(this.ActualHeight) * Math.Sqrt(this.ActualHeight / 13) + 100;
            GridCurrentFolderList.Width = WidthColumn2.ActualWidth - 25;
            GridCurrentFolderList.Margin = new Thickness(10, GridCurrentFolderList.Height * -1, 15, 5);
        }

        public void ShowListFileCurrentFolder()
        {
            for (int i = 0; i < ListNameCurrentFolder.Count; i++)
            {
                Label printTextBlock = new Label();
                printTextBlock.Content = System.IO.Path.GetFileName(ListNameCurrentFolder[i]);
                printTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BBBBBB"));
                printTextBlock.Background = (i % 2 == 0) ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#20FFFFFF")) :
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
                StackPanelCurrentFolderList.Children.Add(printTextBlock);

                //Rectangle rec = new Rectangle()
                //{
                //    Width = 20,
                //    Height = 20,
                //    RadiusX = 5, 
                //    RadiusY = 5,
                //    Opacity = 0.65
                //};
                //ImageBrush imgBrush = new ImageBrush();
                //imgBrush.ImageSource = new BitmapImage(new Uri(@"source/images/player/cover.png", UriKind.Relative));
                //// Fill rectangle with an ImageBrush  
                //rec.Fill = imgBrush;
                //// rec Rectangle to the Grid.  
                //StackPanelCoverList.Children.Add(rec);
            }
        }

        private void AnumationList_timer(object sender, EventArgs e)
        {
            GridCurrentFolderList.Opacity = (ActiveMouseList) ? GridCurrentFolderList.Opacity + 0.11 : GridCurrentFolderList.Opacity - 0.11;
            if (GridCurrentFolderList.Opacity <= 0 || GridCurrentFolderList.Opacity >= 1)
            {
                GridCurrentFolderList.Opacity = (ActiveMouseList) ? 1 : 0;
                CheckAnimationListWork = false;
                TimerList.Stop();
            }
        }

        private void SetOpacityList()
        {
            TimerList = new DispatcherTimer();
            TimerList.Interval = TimeSpan.FromSeconds(0.01);
            TimerList.Tick += AnumationList_timer;
            CheckAnimationListWork = true;
            TimerList.Start();
        }


        private void ListButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListButton.Source = (ActiveMouseList == false) ? new BitmapImage(new Uri("source/images/player/list_active.png", UriKind.Relative)) :
            new BitmapImage(new Uri("source/images/player/list.png", UriKind.Relative));
            if (CheckAnimationListWork == false)
            {
                ActiveMouseList = (ActiveMouseList == true) ? false : true;
                GridCurrentFolderList.IsEnabled = (ActiveMouseList == true) ? true : false;
                SetOpacityList();
            }
        }

        private void ListButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ActiveMouseList == false) ListButton.Source = new BitmapImage(new Uri("source/images/player/list_active.png", UriKind.Relative));
        }

        private void ListButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ActiveMouseList == false) ListButton.Source = new BitmapImage(new Uri("source/images/player/list.png", UriKind.Relative));
        }
    }
}
