using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.Generic;

namespace LiteAudioPlayer
{
    public partial class MainWindow : Window
    {
        public string FileLink = "";
        string FileLinkCurrentFolder = "";
        public string[] AvailableExtensions = { "mp3", "mp4" };
        public List<string> ListNameCurrentFolder = new List<string>();
        private MediaPlayer Player = new MediaPlayer();
        bool isPlay = false;

        public bool CheckFileFormat(string OtherFileLink)
        {
            for (int i = 0; i < AvailableExtensions.Length; i++)
            {
                string Extensions_ = AvailableExtensions[i];
                if (OtherFileLink.Substring(OtherFileLink.Length - Extensions_.Length, Extensions_.Length) == Extensions_) return true;
            }
            return false;
        }

        private BitmapImage GetCoverFile(TagLib.File file)
        {
            TagLib.IPicture ipicture = file.Tag.Pictures[0];
            MemoryStream memorystream = new MemoryStream(ipicture.Data.Data);

            memorystream.Seek(0, SeekOrigin.Begin);

            BitmapImage BitmapImage = new BitmapImage();
            BitmapImage.BeginInit();
            BitmapImage.StreamSource = memorystream;
            BitmapImage.EndInit();

            return BitmapImage;
        }

        private void ChekAudioAvailability()
        {
            foreach (string Arg in Environment.GetCommandLineArgs()) FileLink = Arg;

            if (CheckFileFormat(FileLink))
            {
                SetListFileCurrentFolder();

                if (TagLib.File.Create(FileLink).Tag.Pictures.Length > 0)
                    ImageAudioMain.ImageSource = PageGridHome_.ImageAudio.ImageSource = GetCoverFile(TagLib.File.Create(FileLink));

                Player.Open(new Uri(FileLink, UriKind.Relative));

                Player.Play(); isPlay = true;

                PageGridHome_.LabelNameAudio.Content = Path.GetFileName(FileLink);
                PageGridHome_.SetCorrectSizeLabel();

                StatePlayPauseButton("source/images/player/pause.png");
                LabelPlaerLeft.Content = TimeSpan.FromSeconds(slider.Value).ToString(@"mm\:ss");

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(0.4);
                timer.Tick += timer_Tick;
                timer.Start();
            }
        }

        public void SetListFileCurrentFolder()
        {
            FileLinkCurrentFolder = FileLink;
            int index = FileLinkCurrentFolder.Length - 1;

            while (FileLinkCurrentFolder[index--] != '\\')
                FileLinkCurrentFolder = FileLinkCurrentFolder.Remove(FileLinkCurrentFolder.Length - 1);

            foreach (FileInfo Files in new DirectoryInfo(FileLinkCurrentFolder).GetFiles())
                if (CheckFileFormat(Files.FullName.ToString())) ListNameCurrentFolder.Add(Files.FullName);
            ShowListFileCurrentFolder();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            slider.Minimum = 0;
            slider.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
            slider.Value = Player.Position.TotalSeconds;
            LabelPlaerLeft.Content = TimeSpan.FromSeconds(slider.Value).ToString(@"mm\:ss");

            if (slider.Value == Player.NaturalDuration.TimeSpan.TotalSeconds) { ChekAudioAvailability(); }
        }

        private void StatePlayPauseButton(string uri) => PlayPauseButton.Source = new BitmapImage(new Uri(uri, UriKind.Relative)); 

        private void PlayPauseButton_MouseEnter(object sender, MouseEventArgs e) =>
            StatePlayPauseButton((!isPlay) ? "source/images/player/play_active.png" : "source/images/player/pause_active.png");

        private void PlayPauseButton_MouseLeave(object sender, MouseEventArgs e) =>
           StatePlayPauseButton((!isPlay) ? "source/images/player/play.png" : "source/images/player/pause.png");

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CheckFileFormat(FileLink))
            {
                slider.Minimum = 0;
                slider.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
                Player.Position = TimeSpan.FromSeconds(slider.Value);

                LabelPlaerLeft.Content = TimeSpan.FromSeconds(slider.Value).ToString(@"mm\:ss");
                LabelPlaerRight.Content = TimeSpan.FromSeconds(Player.NaturalDuration.TimeSpan.TotalSeconds).ToString(@"mm\:ss");
            }
        }

        private void PlayPauseButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (CheckFileFormat(FileLink))
            {
                if (!isPlay) { StatePlayPauseButton("source/images/player/pause_active.png"); Player.Play(); isPlay = true; }
                else { StatePlayPauseButton("source/images/player/play_active.png"); Player.Pause(); isPlay = false; }
            }
        }
    }
}
