using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDemo
{
    class Program
    {
        const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True";

        static void Main(string[] args)
        {
            //string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True";
            //SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            //sqlConnection.Open();


            // ------------------------------------------------------------------

            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = connectionString;


            //Console.WriteLine(sqlConnection.State);

            //sqlConnection.Open();

            //Console.WriteLine(sqlConnection.State);


            //sqlConnection.Close();

            //Console.WriteLine(sqlConnection.State);

            // ------------------------------------------------------------------

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();

            //    Console.WriteLine(sqlConnection.State);

            //    string sqlString = "SELECT * FROM Artist";

            //    SqlCommand sqlCommand = new SqlCommand();
            //    sqlCommand.Connection = sqlConnection;
            //    sqlCommand.CommandText = sqlString;

            //    var reader = sqlCommand.ExecuteReader();

            //    //reader.Read();

            //    //Console.WriteLine(reader[0]);
            //    //Console.WriteLine(reader[1]);

            //    int rowCount = 1;
            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"Row: {rowCount}, ID: {reader[0]}, Artist: {reader[1]}");
            //        rowCount++;
            //    }
            //} // sqlConnection.Dispose();

            // ------------------------------------------------------------------

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();

            //    string sqlString = "SELECT COUNT(*) FROM Artist";

            //    SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            //    int numberOfArtists = (int)sqlCommand.ExecuteScalar();
            //    //int numberOfArtists = int.Parse(sqlCommand.ExecuteScalar().ToString());

            //    Console.WriteLine($"Number of artists: {numberOfArtists}");


            //} // sqlConnection.Dispose();

            // ------------------------------------------------------------------

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();

            //    string sqlString = "INSERT INTO Artist (Name) VALUES ('Toppo')";

            //    SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);

            //    int rowsAffected = sqlCommand.ExecuteNonQuery();

            //    Console.WriteLine($"Rows affected: {rowsAffected}");

            //} // sqlConnection.Dispose();

            // ------------------------------------------------------------------

            //// SQL INJECTION
            ////string myId = "125; CREATE TABLE Foo ( Id int IDENTITY NOT NULL PRIMARY KEY )";
            ////string myId = "125 OR 1=1";
            //string myId = "125";
            //// ' OR 1=1;


            ////GetArtist(sqlConnection, myId);
            ////GetArtist(sqlConnection, myId);

            ////GetArtist(connectionstring, myId);


            //GetArtist(myId);
            //GetArtist(myId);

            //// SELECT * FROM Artist WHERE ArtistId = 125 OR 1=1


            // ------------------------------------------------------------------

            //Artist artist = GetArtist("124");

            //Console.WriteLine($"{artist.ArtistName}");

            // ------------------------------------------------------------------

            DisplayMenu();


        }

        private static void DisplayMenu()
        {
            while (true)
            {
                char pressedChar = Console.ReadKey().KeyChar;
                switch (pressedChar)
                {
                    case '1':
                        DisplayAllArtists();
                        break;
                    case '2':
                    case '3':
                    case '4':
                    case 'q':
                        break;
                }
            }
        }

        private static void DisplayAllArtists()
        {
            List<Artist> artists = GetAllArtist();

            foreach (var artist in artists)
            {
                Console.WriteLine($"ID: {artist.ArtistId}, Artist Name: {artist.ArtistName}");
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine($"\t{album.AlbumTitle}");
                }
            }
        }

        ////private static void GetArtist(string connectionString, string myId)
        ////private static void GetArtist(SqlConnection sqlConnection, string myId)
        //private static void GetArtist(string myId)
        //{
        //    //using (sqlConnection)
        //    using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
        //    {
        //        sqlConnection.Open();

        //        string sqlString = "SELECT * FROM Artist WHERE ArtistId = @ArtistId";
        //        //string sqlString = "SELECT * FROM Artist WHERE ArtistId = " + myId;

        //        SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
        //        sqlCommand.Parameters.Add(new SqlParameter("@ArtistId", myId));

        //        var reader = sqlCommand.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"Artist: {reader[1]}");
        //        }

        //    } // sqlConnection.Dispose();
        //}

        // ------------------------------------------------------------------


        public static int CreateArtist(string artistName)
        {
            int artistId;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string sqlString = "INSERT Artist ([Name]) VALUES @ArtistName; SELECT @@IDENTITY";

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@ArtistName", artistName));
                artistId = (int)sqlCommand.ExecuteScalar();
            }
            return artistId;
        }

        public static List<Artist> GetAllArtist()
        {
            List<Artist> artists = new List<Artist>();

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string sqlString = "SELECT * FROM Artist";

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Artist artist = new Artist
                    {
                        ArtistId = reader.GetInt32(0),
                        ArtistName = reader.GetString(1)
                    };

                    artist.Albums = GetArtistAlbums(artist.ArtistId);

                    artists.Add(artist);
                }
            }

            return artists;
        }

        public static Artist GetArtist(int artistId)
        {
            Artist artist;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string sqlString = "SELECT * FROM Artist WHERE ArtistId = @ArtistId";

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@ArtistId", artistId));

                var reader = sqlCommand.ExecuteReader();
                reader.Read();

                artist = new Artist
                {
                    ArtistId = int.Parse(reader[0].ToString()),
                    ArtistName = reader[1].ToString()
                };

            } // sqlConnection.Dispose();
            return artist;
        }

        public void UpdateArtist(int artistId, string artistName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string sqlString = "UPDATE Artist SET [Name] = @ArtistName WHERE ArtistId = @ArtistId";

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                sqlCommand.Parameters.Add(new SqlParameter("@ArtistName", artistName));
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteArtist(int artistId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DELETE Artist WHERE ArtistId = @ArtistId", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                sqlCommand.ExecuteNonQuery();
            }
        }


        public static List<Album> GetArtistAlbums(int artistId)
        {
            List<Album> albums = new List<Album>();

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string sqlString = "SELECT * FROM Album WHERE ArtistId = @ArtistId";

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Album album = new Album
                    {
                        AlbumId = reader.GetInt32(0),
                        AlbumTitle = reader.GetString(1)

                    };
                    albums.Add(album);
                }
            }

            return albums;
        }



    }
}
