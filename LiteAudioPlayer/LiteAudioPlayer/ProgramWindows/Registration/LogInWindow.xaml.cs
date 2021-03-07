using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SQLite;

namespace LiteAudioPlayer
{
    public partial class LogInWindow : Window
    {
        // -- -- -- -- -- -- >
        // [Класс окна log in]
        // < -- -- -- -- -- -- 

        MainWindow MainWindow_;
        private string Username_ = "";
        private string Password_ = "";

        public LogInWindow(double left, double top, MainWindow MainWindow_) 
        {
            InitializeComponent();

            this.Left = left;
            this.Top = top;

            this.MainWindow_ = MainWindow_;
            this.MainWindow_.IsHitTestVisible = false; // заблокировать окно 
            this.MainWindow_.Opacity = 0.9;            // задать прозрачность окна 
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e) // [Перетаскивание окна] -->
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void MinimizeButtonLogInWindow_MouseDown(object sender, MouseButtonEventArgs e) // [Скрыть окно] -->
        {
            this.WindowState = WindowState.Minimized;
        }

        private void UnblockAndClose() // [Разблокировать LiteAudioPlayer и закрыть log in] -->
        {
            this.MainWindow_.IsHitTestVisible = true;
            this.MainWindow_.Opacity = 1;
            this.Close();
        }

        private void CloseButtonLogInWindow_MouseDown(object sender, MouseButtonEventArgs e) // [Закрыть окно] -->
        {
            UnblockAndClose();
        }

        private void Window_Closed(object sender, EventArgs e) // [Отслеживание закрытия окна в принципе (например через диспечер задачь)] -->
        {
            UnblockAndClose();
        }
       
        private void username_TextChanged(object sender, TextChangedEventArgs e) // [Форма ввода имени пользователя] -->
        {
            TextBlockUsername.Visibility = Visibility.Visible;
            if (username.Text.Length > 0)
                TextBlockUsername.Visibility = Visibility.Hidden;
            Username_ = username.Text;
        }
    
        private void password_PasswordChanged(object sender, RoutedEventArgs e) // [Форма ввода пароля] -->
        {
            TextBlockPassword.Visibility = Visibility.Visible;
            if (password.Password.Length > 0)
                TextBlockPassword.Visibility = Visibility.Hidden;
            Password_ = password.Password;
        }
       
        bool CheckingCorrect(string InitialString)  // [Проверка коректности ведённых данных] -->
        {
            // -- -- -- -- -- >
            // [a-z, A-Z, 0-9]
            // < -- -- -- -- --
            for (int i = 0; i < InitialString.Length; i++)
            {
                int KCU = Convert.ToInt32(InitialString[i]);
                if (KCU >= 48 && KCU <= 57 ||
                    KCU >= 65 && KCU <= 90 ||
                    KCU >= 97 && KCU <= 122) { }
                else return false;
            }
            return true;
        }

      
        private void button_Click(object sender, RoutedEventArgs e)  // [Проверка и подтверждение регистрации] -->
        {
            if (Username_.Length >= 3 && Password_.Length >= 4)
            {
                bool CorrectUsername = CheckingCorrect(Username_);
                bool CorrectPassword = CheckingCorrect(Password_);

                if (CorrectUsername && CorrectPassword)
                {
                    try
                    {
                        SQLiteConnection UsersDataBase = new SQLiteConnection("Data Source = UsersDataBase.db");
                        if (UsersDataBaseInteraction.UniquenessCheckUsername(UsersDataBase, Username_))
                        {
                            UsersDataBaseInteraction.Add(UsersDataBase, Username_, Password_);
                            this.MainWindow_.IsHitTestVisible = true;
                            this.MainWindow_.Opacity = 1;
                            this.Close();
                        }
                        else MessageLabel.Content = "Error: such username already exists";
                    }
                    catch { MessageLabel.Content = "Error: connection"; }
                }
                else
                {
                    if (!CorrectUsername) MessageLabel.Content = "Error: Unacceptable symbols username";
                    else MessageLabel.Content = "Error: Unacceptable symbols password";
                }
            }
            else { MessageLabel.Content = "Error: too short username or password"; }
        }
    }
}
