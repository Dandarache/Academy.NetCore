ALTER VIEW vw_ArtistsWithAlbums
AS
SELECT a.ArtistId, 
       a.Name AS ArtistName, 
	   al.AlbumId, 
	   al.Title AS AlbumTitle, 
	   t.Name AS TrackTitle
  FROM Artist a
 INNER JOIN Album al
    ON al.ArtistId = a.ArtistId
 INNER JOIN Track t
    ON t.AlbumId = al.AlbumId
GO

---------------------

SELECT *
  FROM vw_ArtistsWithAlbums
 WHERE ArtistName = 'AC/DC'
 ORDER BY ArtistName

---------------------
 
DROP VIEW vw_GenreStatistics
GO

CREATE VIEW vw_GenreStatistics
AS
SELECT Genre.[Name] AS Genre, 
       COUNT(*) AS NumberOfTracks, 
	   MIN(Milliseconds) AS ShortestTrack,
       MAX(Milliseconds) AS LongestTrack, 
	   AVG(Milliseconds) AS AverageTrackLength
  FROM Track 
 INNER JOIN Genre 
    ON Genre.GenreId = Track.GenreId
 GROUP BY Genre.[Name]

---------------------

SELECT *
  INTO #MyTempTable
  FROM vw_GenreStatistics
 WHERE NumberOfTracks > 50
  
---------------------

SELECT * 
  FROM #MyTempTable


