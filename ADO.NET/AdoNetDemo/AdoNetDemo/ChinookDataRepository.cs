using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetDemo
{
    public class ChinookDataRepository
    {
        const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True;MultipleActiveResultSets=true;";

        /// <summary>
        /// This method will create an artist in the database using 
        /// a stored procedure, and will return the id for the new artist using an output parameter.
        /// -----------------------------------
        /// CREATE PROCEDURE usp_CreateArtist (
        ///     @ArtistName NVARCHAR(255), 
        ///     @ArtistId int OUTPUT
        /// )
        /// AS
        /// BEGIN
        /// 	INSERT Artist (
        /// 		[Name]
        /// 	) 
        /// 	VALUES (
        /// 		@ArtistName
        /// 	)
        /// 		
        /// SET @ArtistId = @@IDENTITY
        /// 
        /// END
        /// GO
        /// -----------------------------------
        /// </summary>
        /// <param name="artistName">The name of the new artist.</param>
        /// <returns>The id of the new artist.</returns>
        public int CreateArtist(Artist artist)
        {
            SqlParameter idParameter = new SqlParameter("@ArtistId", System.Data.DbType.Int32);
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                string sqlString = "usp_CreateArtist @ArtistName, @ArtistId";

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@ArtistName", artist.ArtistName));

                idParameter.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(idParameter);
                    
                sqlCommand.ExecuteNonQuery();
            }
            return (int)idParameter.Value;
        }

        public List<Artist> GetAllArtist(bool loadAllData)
        {
            List<Artist> artists = new List<Artist>();

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                string sqlString = "SELECT * FROM Artist";
                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                using (var readerArtists = sqlCommand.ExecuteReader())
                {
                    while (readerArtists.Read())
                    {
                        Artist artist = new Artist
                        {
                            ArtistId = readerArtists.GetInt32(0),
                            ArtistName = readerArtists.GetString(1),
                        };

                        // Lägg till alla album för artisten om parametern listAlbums är true.
                        if (loadAllData)
                        {
                            SqlCommand sqlCommandAlbums =
                                new SqlCommand("SELECT * FROM Album WHERE ArtistId = @ArtistId", sqlConnection);
                            sqlCommandAlbums.Parameters.Add(new SqlParameter("@ArtistId", artist.ArtistId));
                            using (var readerAlbums = sqlCommandAlbums.ExecuteReader())
                            {
                                while (readerAlbums.Read())
                                {
                                    Album album = new Album
                                    {
                                        AlbumId = readerAlbums.GetInt32(0),
                                        AlbumTitle = readerAlbums.GetString(1)
                                    };
                                    SqlCommand sqlCommandTracks =
                                        new SqlCommand("SELECT * FROM Track WHERE AlbumId = @AlbumId", sqlConnection);
                                    sqlCommandTracks.Parameters.Add(new SqlParameter("@AlbumId", album.AlbumId));
                                    using (var readerTracks = sqlCommandTracks.ExecuteReader())
                                    {
                                        while (readerTracks.Read())
                                        {
                                            var track = new Track
                                            {
                                                TrackId = readerTracks.GetInt32(0),
                                                TrackName = readerTracks.GetString(1)
                                            };
                                            album.Tracks.Add(track);
                                        }
                                    }
                                    artist.Albums.Add(album);
                                }
                            }
                        }
                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        public Artist GetArtist(int artistId)
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

        public string DeleteArtist(int artistId)
        {
            string returnMessage = string.Empty;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();

                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                try
                {
                    SqlCommand sqlCommandDeletePlaylistTrack = new SqlCommand(
                        $"DELETE PlaylistTrack WHERE TrackId IN (" +
                        $"  SELECT t.TrackId FROM Track t " +
                        $"      INNER JOIN Album a ON a.AlbumId = t.AlbumId " +
                        $"  WHERE a.ArtistId = @ArtistId" +
                        $")", sqlConnection);
                    sqlCommandDeletePlaylistTrack.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                    sqlCommandDeletePlaylistTrack.Transaction = sqlTransaction;
                    sqlCommandDeletePlaylistTrack.ExecuteNonQuery();

                    SqlCommand sqlCommandDeleteInvoiceLine = new SqlCommand(
                        $"DELETE InvoiceLine WHERE TrackId IN (" +
                        $"  SELECT t.TrackId FROM Track t " +
                        $"      INNER JOIN Album a ON a.AlbumId = t.AlbumId " +
                        $"      INNER JOIN InvoiceLine i ON i.TrackId = t.TrackId " +
                        $"  WHERE a.ArtistId = @ArtistId" +
                        $")", sqlConnection);
                    sqlCommandDeleteInvoiceLine.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                    sqlCommandDeleteInvoiceLine.Transaction = sqlTransaction;
                    sqlCommandDeleteInvoiceLine.ExecuteNonQuery();

                    SqlCommand sqlCommandDeleteTracks = new SqlCommand(
                        $"DELETE Track WHERE TrackId IN (" +
                        $"  SELECT t.TrackId FROM Track t " +
                        $"      INNER JOIN Album a ON a.AlbumId = t.AlbumId " +
                        $"  WHERE a.ArtistId = @ArtistId" +
                        $")", sqlConnection);
                    sqlCommandDeleteTracks.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                    sqlCommandDeleteTracks.Transaction = sqlTransaction;
                    sqlCommandDeleteTracks.ExecuteNonQuery();

                    SqlCommand sqlCommandDeleteAlbums = new SqlCommand("DELETE Album WHERE ArtistId = @ArtistId", sqlConnection);
                    sqlCommandDeleteAlbums.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                    sqlCommandDeleteAlbums.Transaction = sqlTransaction;
                    sqlCommandDeleteAlbums.ExecuteNonQuery();

                    SqlCommand sqlCommandDeleteArtist = new SqlCommand("DELETE Artist WHERE ArtistId = @ArtistId", sqlConnection);
                    sqlCommandDeleteArtist.Parameters.Add(new SqlParameter("@ArtistId", artistId));
                    sqlCommandDeleteArtist.Transaction = sqlTransaction;
                    sqlCommandDeleteArtist.ExecuteNonQuery();

                    sqlTransaction.Commit();
                    returnMessage = "Artisten togs bort ur databasen.";

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    returnMessage = $"Ett fel uppstod: {ex.Message}";
                }
            }
            return returnMessage;
        }

        public List<Album> GetArtistAlbums(int artistId)
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
