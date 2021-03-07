using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Controls;
using LiteAudioPlayer.PageMainWindow;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace LiteAudioPlayer
{
    public partial class MainWindow : Window
    {
        public PageGridHome PageGridHome_;
        public PageGridList PageGridList_;
        public PageGridSettings PageGridSettings_;
        public PageGridOther PageGridOther_;
        private Button ActiveButton;
        private DispatcherTimer timer;
        private bool CheckAnimationCoverWork = false;

        private void InitializationPage()
        {
            PageGridHome_ = new PageGridHome(this);
            PageGridList_ = new PageGridList(this);
            PageGridSettings_ = new PageGridSettings(this);
            PageGridOther_ = new PageGridOther(this);
        }

        private void AnimationMaximizedWindow(double toLeft, double toTop)
        {
            double distance, valL = 0, valT = 0, left = this.Left, top = this.Top;
            if (toLeft < left) valL = 16;
            if (toTop < top) valT = 8;
            do
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Restart();
                distance = Math.Sqrt((toLeft - valL - this.Left) * (toLeft - valL - this.Left) + (toTop - valT - this.Top) * (toTop - valT - this.Top));
                left += ((0.1 * (toLeft - valL - this.Left) * distance / 2000)) * (Convert.ToDouble(stopwatch.ElapsedTicks) / 2.3);
                top += ((0.1 * (toTop - valT - this.Top) * distance / 2000)) * (Convert.ToDouble(stopwatch.ElapsedTicks) / 2.3);
                this.Left = left; this.Top = top;
            } while (distance > 10);
        }

        private void SetToActiveButton(Button NameButton)  // [Закрасить кнопку активной страницы] -->  /
        {
            var convert = new BrushConverter();
            NameButton.Style = (Style)this.FindResource("ActiveButtonStyleNavigation");
            if (ActiveButton != null) ActiveButton.Style = (Style)this.FindResource("ButtonStyleNavigation");
        }

        private void OpenPage(Button button) // [] -->   
        {
            if (ActiveButton != button)
            {
                if (button == this.Home) this.Main.Content = PageGridHome_;
                else if (button == this.List) this.Main.Content = PageGridList_;
                else if (button == this.Settings) this.Main.Content = PageGridSettings_;
                else if (button == this.Other) this.Main.Content = PageGridOther_;
                SetToActiveButton(button);
                if (CheckAnimationCoverWork == false) SetOpacityCover();
                ActiveButton = button;
            }
        }

        private void AnumationOpacityCover_timer(object sender, EventArgs e)
        {
            ImageAudioMain.Opacity = (ActiveButton == this.Home) ? ImageAudioMain.Opacity - 0.11 : ImageAudioMain.Opacity + 0.11;
            if (ImageAudioMain.Opacity <= 0 || ImageAudioMain.Opacity >= 1)
            {
                ImageAudioMain.Opacity = (ActiveButton == this.Home) ? 0 : 1;
                CheckAnimationCoverWork = false;
                timer.Stop();
            }
        }

        private void SetOpacityCover()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += AnumationOpacityCover_timer;
            CheckAnimationCoverWork = true;
            timer.Start();
        }

        private void VolumeSliderAnimation(double to)
        {
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = VolumeSlider.Width; anim.To = to;
            anim.Duration = TimeSpan.FromSeconds(0.25);
            anim.EasingFunction = new QuadraticEase();
            VolumeSlider.BeginAnimation(WidthProperty, anim);
        }
    }
}
