﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True";

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



            // SQL INJECTION
            string myId = "125; CREATE TABLE Foo ( Id int IDENTITY NOT NULL PRIMARY KEY )";
            //string myId = "125 OR 1=1";
            //string myId = "125";
            // ' OR 1=1;


            GetArtist(connectionString, myId);

            // SELECT * FROM Artist WHERE ArtistId = 125 OR 1=1


        }

        private static void GetArtist(string connectionString, string myId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string sqlString = "SELECT * FROM Artist WHERE ArtistId = " + myId;

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Artist: {reader[1]}");
                }

            } // sqlConnection.Dispose();
        }
    }
}
