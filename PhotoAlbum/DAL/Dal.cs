using DAL.Models;
using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class Dal
    {
        private static string connectionString;

        public Dal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlbumContex"].ConnectionString;
        }

        public static string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        public static List<byte[]> GetAllImage(int id = 0) 
        {

            List<byte[]> iScreen = new List<byte[]>(); 
            List<string> iScreen_format = new List<string>();
            List<System.Drawing.Image> images = new List<System.Drawing.Image>();
            string commandString = String.Empty;
            if (id == 0)
            {
                commandString = @"SELECT [file] FROM [Photos]";
            }
            else
            {
                commandString = @"SELECT [file] FROM [Photos] WHERE IdUser = @id";
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = commandString;
                if (id != 0)
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                }
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                byte[] iTrimByte = null;
                while (sqlReader.Read()) 
                {
                    iTrimByte = (byte[])sqlReader["file"]; 
                    iScreen.Add(iTrimByte);
                }
                sqlConnection.Close();
            }

            return iScreen;
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] inputArray)
        {
            var memoryStream = new MemoryStream(inputArray);
            return System.Drawing.Image.FromStream(memoryStream);
        }

        public void PutImageBinaryInDb(string iFile, int idUser)
        {
            // конвертация изображения в байты
            byte[] imageData = null;
            FileInfo fInfo = new FileInfo(iFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);

            // получение расширения файла изображения не забыв удалить точку перед расширением
            string iImageExtension = (Path.GetExtension(iFile)).Replace(".", "").ToLower();

            // запись изображения в БД
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "INSERT INTO Photos VALUES(@idUser,@file,@extension)"; // запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@idUser", idUser);
                command.Parameters.AddWithValue("@file", (object)imageData);
                command.Parameters.AddWithValue("@extension", iImageExtension);
                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Photo> GetAllPhotos(int? id = 0)
        {
            string commandString = String.Empty;
            if (id == 0)
            {
                 commandString = @"Select * FROM Photos";
            }
            else
            {
                commandString = @"Select * FROM Photos WHERE IdUser = @id";
            }
            var allPhotos = new List<Photo>();
            //var allPhotos = new List<Image>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;
                if (id != 0)
                {
                    command.Parameters.AddWithValue("@id", id);
                }

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int photoId = reader.GetInt32(0);
                        int userId = reader.GetInt32(1);
                        byte[] file = (byte[])reader["file"];

                        Photo ph = new Photo
                        {
                            IdPhoto = photoId,
                            IdUser = userId,
                            File = file
                        };

                        allPhotos.Add(ph);
                    }
                }
            }

            return allPhotos;
        }

        public List<string> GetAllTags()
        {
            List<string> tags = new List<string>();
            string commandString = @"Select Distinct Tags.NameTag FROM Tags";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tag = reader.GetString(0);

                        tags.Add(tag);
                    }
                   
                }
            }

            return tags;
        }

        public List<string> GetAllTagsUser(int? idUser)
        {

            List<string> tags = new List<string>();
            string commandString = @"Select Tags.NameTag 
                                    from (Users join Photos on Users.IdUser = Photos.IdUser) 
                                    join Tags ON Photos.IdPhoto = Tags.IdPhoto 
                                    where Users.IdUser = @idUser;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@idUser", idUser); 
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tag = reader.GetString(0);

                        tags.Add(tag);
                    }

                }
            }

            return tags;
        }

        public void CreateUser(UserViewModel user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string pass = Dal.GetHashString(user.Pass);
                string commandText = "INSERT INTO Users VALUES(@login,@pass,@userName,@role)"; // запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@userName", user.UserName);
                command.Parameters.AddWithValue("@role", 2);
                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public int? Authorization(Authorization auth)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string pass = Dal.GetHashString(auth.Pass);
                string commandText = "Select IdUser from Users where (Users.Login = @login) and (Users.Pass) = @pass"; // запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@login", auth.Login);
                command.Parameters.AddWithValue("@pass", pass);
                sqlConnection.Open();
                var reader = command.ExecuteScalar();
                sqlConnection.Close();

                if (reader != null)
                {
                    return (int?)reader;
                }
                else
                {
                    return 0;
                }
            }
        }

        public User GetUser(int? id)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "Select * from Users where Users.IdUser = @idUser";
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@idUser", id);
                User user = new User();
                byte[] iTrimByte = null;

                sqlConnection.Open();//IDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idUser = reader.GetInt32(0);
                        string userName = reader.GetString(3);
                        iTrimByte = (byte[])reader["Avatar"];
                        user.IdUser = idUser;
                        user.UserName = userName;
                        user.Avatar = iTrimByte;
                    }

                    sqlConnection.Close();

                    return user;
                }
            }
        }
    }
}
