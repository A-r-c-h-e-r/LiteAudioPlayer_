using System;
using System.Data.SQLite;

namespace LiteAudioPlayer
{
    class UsersDataBaseInteraction
    {
        // -- -- -- -- -- -- -- -- -- -- >
        // [Класс взаимодействия с SQLite]
        // < -- -- -- -- -- -- -- -- -- --

        static public int FindNumberLines(SQLiteConnection UsersDataBase)   // [Найти количество строк в таблице] --> 
        {
            SQLiteCommand SQLcmd = UsersDataBase.CreateCommand();
            SQLcmd.CommandText = "SELECT COUNT(ID) FROM users_table";
            SQLcmd.ExecuteNonQuery();
            string number = SQLcmd.ExecuteScalar().ToString();
            return Convert.ToInt32(number);
        }

        static public void Add(SQLiteConnection UsersDataBase, string USERNAME, string PASSWORD) // [Добавить в таблицу] --> 
        {
            SQLiteCommand SQLcmd = UsersDataBase.CreateCommand();
            UsersDataBase.Open();
            SQLcmd.CommandText = "insert into users_table(ID, name, password) values(@ID, @USERNAME, @PASSWORD)";
            SQLcmd.Parameters.Add("@ID", System.Data.DbType.String).Value = FindNumberLines(UsersDataBase) + 1;
            SQLcmd.Parameters.Add("@USERNAME", System.Data.DbType.String).Value = USERNAME;
            SQLcmd.Parameters.Add("@PASSWORD", System.Data.DbType.String).Value = PASSWORD;
            SQLcmd.ExecuteNonQuery();
            UsersDataBase.Close();
        }

        static public bool UniquenessCheckUsername(SQLiteConnection UsersDataBase, string USERNAME) // [Проверка на уникальность имя пользователя] --> 
        {
            UsersDataBase.Open();
            int quantity = FindNumberLines(UsersDataBase);
            UsersDataBase.Close();

            if (quantity != 0)
            {
                for (int i = 1; i <= quantity; i++)
                {
                    SQLiteCommand SQLcmd = UsersDataBase.CreateCommand();
                    UsersDataBase.Open();
                    SQLcmd.CommandText = "select * from users_table where ID like '%' || @WHERE || '%'";
                    SQLcmd.Parameters.Add("@WHERE", System.Data.DbType.String).Value = i;
                    SQLiteDataReader GetStringSQL = SQLcmd.ExecuteReader();
                    string username = "";
                    if (GetStringSQL.HasRows)
                        while (GetStringSQL.Read())
                            username = GetStringSQL["name"].ToString();
                    UsersDataBase.Close();
                    if (username == USERNAME) return false;
                }
            }
            else return false;

            return true;
        }
    }
}