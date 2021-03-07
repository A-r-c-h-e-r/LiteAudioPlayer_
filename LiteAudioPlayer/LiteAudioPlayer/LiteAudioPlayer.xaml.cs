using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Windows.Media.Animation;
using LiteAudioPlayer.PageMainWindow;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;

namespace LiteAudioPlayer
{
    public partial class MainWindow : Window
    {
        // -- -- -- -- -- -- -- >
        // [Клас главного окна]
        // < -- -- -- -- -- -- -- 
        public string search;
       
        public MainWindow()
        {
            InitializeComponent();
            InitializationPage();

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            Loaded += delegate { MinWidth = 455; MinHeight = 250; };

            Main.Content = PageGridHome_;
            SetToActiveButton(Home);
            ActiveButton = Home;

            ImageAudioMain.Opacity = 0;
            SetOpacityCover();

            GridCurrentFolderList.Opacity = 0;
            GridCurrentFolderList.Height = this.Height / 2;
            GridCurrentFolderList.Width = WidthColumn2.ActualWidth;
            GridCurrentFolderList.Margin = new Thickness(10, GridCurrentFolderList.Height * -1, 10, 5);
          
            ChekAudioAvailability();
        }

     
        private bool AllowDragMove = true; // разрешает перетаскивание
        private void MinimizeButton_MouseDown(object sender, MouseButtonEventArgs e) { AllowDragMove = false; }
        private void MinimizeButton_MouseUp(object sender, MouseButtonEventArgs e) // [Свернуть окно] --> 
        {
            this.WindowState = WindowState.Minimized;
            AllowDragMove = true;
        }

        // запоминает позицию окна при сворачивании
        private double PosLeft = 0, PosTop = 0;
        private void MaximizedButton_MouseDown(object sender, MouseButtonEventArgs e) => AllowDragMove = false; 
        private void MaximizedButton_MouseUp(object sender, MouseButtonEventArgs e) // [Развернуть окно] --> 
        {
            if (this.WindowState == WindowState.Normal) // Развернуть на весь экран
            {
                PosLeft = this.Left; PosTop = this.Top;
                try { AnimationMaximizedWindow(0, 0); } catch { }

                this.WindowState = WindowState.Maximized;
            }
            else // Нормализовать
            {
                this.WindowState = WindowState.Normal;
                try { AnimationMaximizedWindow(PosLeft, PosTop); } catch { }

            }
            AllowDragMove = true;
        }
        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e) => AllowDragMove = false; 
        private void CloseButton_MouseUp(object sender, MouseButtonEventArgs e) // [Закрыть окно] --> 
        {
            var windows = Application.Current.Windows;
            foreach (var item in windows)
            {
                if ((item as Window).Title.ToLower() == "MainWindow") continue;
                (item as Window).Close();
            }

        }

        private bool moving = false;
        private void ToolBar_MouseUp(object sender, MouseButtonEventArgs e) => moving = false; 
        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e) // [Перетаскивание окна] --> 
        {
            if (e.ChangedButton == MouseButton.Left && AllowDragMove)
            {
                if (this.WindowState == WindowState.Maximized)
                    moving = true;
                this.DragMove();
            }
        }

        private void ToolBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Point point = e.GetPosition(this);
                
                this.WindowState = WindowState.Normal;
                double PositionX = point.X - (this.Width / ((SystemParameters.WorkArea.Width / point.X)));
                if (PositionX < point.X) PositionX -= 10;
                else if (PositionX > point.X + this.Width) PositionX += 10;

                this.Top = point.Y - 12; this.Left = PositionX;
                this.DragMove();

            }
            moving = false;
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string NameGridButton = button.Content.ToString();
            OpenPage(button);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PageGridHome_.SetCorrectSizeLabel();
            SetSizeCurrentFolderList();  
        }



        private void VolumeSlider_MouseEnter(object sender, MouseEventArgs e) => VolumeSliderAnimation(80);
        private void VolumeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            VolumeSlider.Width = 0; VolumeSliderAnimation(80);
        }

        private void VolumeSlider_MouseLeave(object sender, MouseEventArgs e) => VolumeSliderAnimation(0);
        private void VolumeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            VolumeSlider.Width = 80; VolumeSliderAnimation(0);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CheckFileFormat(FileLink))
            {
                VolumeSlider.Minimum = 0;
                VolumeSlider.Maximum = 1;
                Player.Volume = VolumeSlider.Value;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Search.IsReadOnly = true; Search.IsEnabled = false; Search.IsEnabled = true;
            if (Search.Text.Length == 0) LabelSearch.Visibility = Visibility.Visible;
        }
    }
}
