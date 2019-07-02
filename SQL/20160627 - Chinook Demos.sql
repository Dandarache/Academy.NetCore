--SELECT * 
--FROM artist

--SELECT * 
--FROM album

--SELECT * 
--FROM customer

--SELECT * 
--FROM employee

--SELECT * 
--  FROM Artist
-- WHERE [Name] LIKE '[bcdth]_[aeiou]%'
-- ORDER BY [Name]

--SELECT TOP 25 * 
--  FROM Artist
-- WHERE [Name] LIKE '[bcdth]_[aeiou]%'
-- ORDER BY [Name]


------------------------------------------------
-- 8) Lista alla album tillsammans med artister för albumen (ArtistName, AlbumTitle)
------------------------------------------------

SELECT Artist.[Name] AS ArtistName, Album.Title AS AlbumTitle
  FROM Artist 
  --INNER JOIN Album
  LEFT OUTER JOIN Album
  --RIGHT OUTER JOIN Album
    ON Artist.ArtistId = Album.ArtistId
 ORDER BY ArtistName ASC

-- select* from album

 --insert album (title, artistid) values ('foo', 2)
 --insert album (title, artistid) values ('faa', null)


------------------------------------------------
-- 9) Förklara skillnaden mellan
------------------------------------------------
--		inner join
--		left OUTER join
--		right OUTER join
--		full OUTER join
--		cross

------------------------------------------------
-- 10.1) Lista de 10 artister som släppt flest album (NrOfAlbums, ArtistName)
------------------------------------------------
SELECT TOP 10 COUNT(*) AS NrOfAlbums, Artist.[Name] AS ArtistName, Album.ArtistId
  FROM Artist
 INNER JOIN Album
    ON Album.ArtistId = Artist.ArtistId
 GROUP BY Artist.[Name], Album.ArtistId
 ORDER BY NrOfAlbums DESC

--SELECT Album.AlbumId, Artist.[Name] AS ArtistName
--  FROM Artist
-- INNER JOIN Album
--    ON Album.ArtistId = Artist.ArtistId
-- WHERE Artist.ArtistId = 90

------------------------------------------------
-- 10.2) Lista den totala längden för varje album.
------------------------------------------------
SELECT SUM(Milliseconds) AS [Total Album Length], 
       ((SUM(Milliseconds) / 1000) / 60) AS [Total Album Length in min], 
	   Album.Title AS AlbumTitle, 
	   Artist.[Name] AS ArtistName
  FROM Track
 INNER JOIN Album  
    ON Track.AlbumId = Album.AlbumId
 INNER JOIN Artist
    ON Album.ArtistId = Artist.ArtistId
 GROUP BY Album.Title, Artist.[Name]
 ORDER BY SUM(Milliseconds) DESC

--SELECT SUM(Track.Milliseconds) AS TotalLengthInMilliSeconds, Artist.[Name] AS ArtistName, Album.Title AS AlbumTitle
--  FROM Album
-- INNER JOIN Artist
--	ON Album.ArtistId = Artist.ArtistId
-- INNER JOIN Track
--	ON Album.AlbumId = Track.AlbumId
-- GROUP BY Artist.[Name], Album.Title
-- ORDER BY SUM(Track.Milliseconds) DESC

------------------------------------------------
-- 10.3) Lista genomsnittslängden för alla album baserat på alla album.
------------------------------------------------
SELECT ((AVG(x.TotalAlbumLengthInMs) / 1000) / 60) AS AverageAlbumLength
  FROM 
  (
	SELECT SUM(t.Milliseconds) TotalAlbumLengthInMs, t.AlbumId
	  FROM Track t
	 GROUP BY t.AlbumId
  ) x

-----------------------------------------------

SELECT AVG(a.TotalLength) AS AverageLengthInMilliSeconds
  FROM 
  (
		SELECT SUM(Track.Milliseconds) AS TotalLength
		  FROM Album
		 INNER JOIN Artist
		    ON Album.ArtistId = Artist.ArtistId
	     INNER JOIN Track
		    ON Album.AlbumId = Track.AlbumId
		 GROUP BY Album.AlbumId
  ) a

------------------------------------------------
-- 10.4) Lista snittlängden för samtliga låtar samt antal låtar per album. 
------------------------------------------------
SELECT ((AVG(a.TotalLength) / 1000) / 60) AS AverageTrackLengthInMinutes, 
       COUNT(a.TrackId) AS NumberOfTracks, 
	   a.AlbumTitle
  FROM 
  (
		SELECT SUM(Track.Milliseconds) AS TotalLength, 
		       Track.TrackId, 
			   Album.Title AS AlbumTitle
		  FROM Album
		 INNER JOIN Artist
		    ON Album.ArtistId = Artist.ArtistId
	     INNER JOIN Track
		    ON Album.AlbumId = Track.AlbumId
		 GROUP BY Track.TrackId, Album.Title
  ) a
 GROUP BY a.AlbumTitle

--SELECT AVG(a.TotalLength) AS AverageLengthInMilliSeconds, AVG(a.NumberOfTracks)
--  FROM 
--  (
--		SELECT SUM(Track.Milliseconds) AS TotalLength, COUNT(Track.TrackId) AS NumberOfTracks
--		  FROM Album
--		 INNER JOIN Artist
--		    ON Album.ArtistId = Artist.ArtistId
--	     INNER JOIN Track
--		    ON Album.AlbumId = Track.AlbumId
--		 GROUP BY Album.AlbumId
--  ) a


------------------------------------------------
-- 10.5) Lista den kortaste låten för varje album
------------------------------------------------
SELECT a.Title, a.AlbumId, t.TrackId, t.[Name] As TrackTitle, t.Milliseconds
  FROM Track t
 INNER JOIN Album a
    ON a.AlbumId = t.AlbumId
 WHERE t.TrackId = (
	SELECT TOP 1 t2.TrackId
	  FROM Track t2
	 WHERE t2.AlbumId = t.AlbumId
	 GROUP BY t2.TrackId, t2.Name, t2.AlbumId, t2.Milliseconds
	HAVING t2.Milliseconds = MIN(t2.Milliseconds)
	)
ORDER BY t.Name

------------------------------------------------
-- 10.5) Lista den längsta låten för varje album
------------------------------------------------
SELECT a.Title, a.AlbumId, t.TrackId, t.[Name] As TrackTitle, t.Milliseconds
  FROM Track t
 INNER JOIN Album a
    ON a.AlbumId = t.AlbumId
 WHERE t.TrackId = (
	SELECT TOP 1 t2.TrackId
	  FROM Track t2
	 WHERE t2.AlbumId = t.AlbumId
	 GROUP BY t2.TrackId, t2.Name, t2.AlbumId, t2.Milliseconds
	HAVING t2.Milliseconds = MAX(t2.Milliseconds)
	)
ORDER BY t.Name

------------------------------------------------
-- 11) Lista namn på alla album som är Jazz eller Blues. 
--     Ett album ska bara finnas i listan en gång. (AlbumTitle)
------------------------------------------------

--SELECT DISTINCT Album.[Title] AlbumTitle
--  FROM Album
-- INNER JOIN Track
--    ON Track.AlbumId = Album.AlbumId
-- INNER JOIN Genre
--    ON Genre.GenreId = Track.GenreId
-- WHERE Genre.GenreId IN (2, 6)
-- --WHERE Genre.[Name] IN ('Jazz', 'Blues', 'Rock')
-- ORDER BY Album.Title
 
------------------------------------------------
--12) Albumet "Let There Be Rock" (av AC/DC) innehåller 8 låtar. 
--    Modifiera databasen så det går att ordna låtar i nummerordning.
--    Uppdatera sedan databasen så låtarna i "Let There Be Rock" är 
--    numrerade från 1 till 8. (du kan lösa detta genom att på valfritt sätt, 
--    t.ex genom flera update-kommandon)
------------------------------------------------

SELECT * FROM Album Where Title LIKE '%Let there be%'

---- AlbumId = 4

--SELECT * FROM Track WHERE AlbumId = 4

----15	Go Down	4	1	1	AC/DC	331180	10847611	0.99
----16	Dog Eat Dog	4	1	1	AC/DC	215196	7032162	0.99
----17	Let There Be Rock	4	1	1	AC/DC	366654	12021261	0.99
----18	Bad Boy Boogie	4	1	1	AC/DC	267728	8776140	0.99
----19	Problem Child	4	1	1	AC/DC	325041	10617116	0.99
----20	Overdose	4	1	1	AC/DC	369319	12066294	0.99
----21	Hell Ain't A Bad Place To Be	4	1	1	AC/DC	254380	8331286	0.99
----22	Whole Lotta Rosie	4	1	1	AC/DC	323761	10547154	0.99

--ALTER TABLE Track ADD TrackNumber tinyint 

--UPDATE Track SET TrackNumber = 2 WHERE TrackId = 15 
--UPDATE Track SET TrackNumber = 3 WHERE TrackId = 16 
--UPDATE Track SET TrackNumber = 4 WHERE TrackId = 17 
--UPDATE Track SET TrackNumber = 1 WHERE TrackId = 18 
--UPDATE Track SET TrackNumber = 5 WHERE TrackId = 19 
--UPDATE Track SET TrackNumber = 6 WHERE TrackId = 20 
--UPDATE Track SET TrackNumber = 7 WHERE TrackId = 21 
--UPDATE Track SET TrackNumber = 8 WHERE TrackId = 22 

------------------------------------------------
-- 13) Skriv en sqlfråga som visar de genres som är mest populära. 
--     Lista genre och antal tracks i den genren. 
--     Visa den genre som har flest tracks först och sedan i nedåtstigande 
--     ordning. Visa endast de genres som har fler än 100 tracks. (GenreName, NrOfTracks)
------------------------------------------------
SELECT COUNT(g.GenreId) AS NumberOfTracks, g.Name
  FROM Genre g
 INNER JOIN Track t
    ON t.GenreId = g.GenreId
 GROUP BY g.Name
HAVING COUNT(*) > 100
 ORDER BY NumberOfTracks DESC






















    select Genre.Name GenreName, Count(Genre.Name) as NrOfAlbums
    from Genre 
    join Track on Genre.GenreId = Track.GenreId
    group by Genre.Name
    having Count(*) > 100 
    order by NrOfAlbums desc








