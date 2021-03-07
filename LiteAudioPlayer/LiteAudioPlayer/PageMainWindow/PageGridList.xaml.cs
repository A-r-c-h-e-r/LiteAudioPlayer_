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

namespace LiteAudioPlayer.PageMainWindow
{
    /// <summary>
    /// Логика взаимодействия для PageGridList.xaml
    /// </summary>
    public partial class PageGridList : Page
    {
        MainWindow MainWindow_;
        public PageGridList(MainWindow MainWindow_)
        {
            InitializeComponent();
            this.MainWindow_ = MainWindow_;

            //if (MainWindow_.FileLink.Length > 1)
            //{
            //    string FileLink_ = MainWindow_.FileLink;
            //    int index = FileLink_.Length - 1;

            //    do { FileLink_.Remove(FileLink_.Length - 1); } while (FileLink_[index--] != '\\');


            //    MainWindow_.label.Content = "1";
            //    //List<string> listName = new List<string>();
            //    //foreach (FileInfo Files in new DirectoryInfo(@MainWindow_.FileLink).GetFiles())
            //    //{
            //    //    listName.Add(Files.FullName);
            //    //}

            //    //for (int i = 0; i < listName.Count; i++)
            //    //{
            //    //    Label printTextBlock = new Label();
            //    //    printTextBlock.Content = listName[i];
            //    //    printTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BBBBBB"));
            //    //    printTextBlock.Background = (i % 2 == 0) ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#252424")) : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#181818"));
            //    //    StackPanelList.Children.Add(printTextBlock);
            //    //}
            //}
        }

    }
}
