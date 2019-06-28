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
-- 8) Lista alla album tillsammans med artister f�r albumen (ArtistName, AlbumTitle)
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
-- 9) F�rklara skillnaden mellan
------------------------------------------------
--		inner join
--		left OUTER join
--		right OUTER join
--		full OUTER join
--		cross

------------------------------------------------
-- 10.1) Lista de 10 artister som sl�ppt flest album (NrOfAlbums, ArtistName)
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
-- 10.2) Lista den totala l�ngden f�r varje album.
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
-- 10.3) Lista genomsnittsl�ngden f�r alla album baserat p� alla album.
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
-- 10.4) Lista snittl�ngden f�r samtliga l�tar samt antal l�tar per album. 
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
-- 10.5) Lista den kortaste l�ten f�r varje album
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
-- 10.5) Lista den l�ngsta l�ten f�r varje album
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
-- 11) Lista namn p� alla album som �r Jazz eller Blues. 
--     Ett album ska bara finnas i listan en g�ng. (AlbumTitle)
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
--12) Albumet "Let There Be Rock" (av AC/DC) inneh�ller 8 l�tar. 
--    Modifiera databasen s� det g�r att ordna l�tar i nummerordning.
--    Uppdatera sedan databasen s� l�tarna i "Let There Be Rock" �r 
--    numrerade fr�n 1 till 8. (du kan l�sa detta genom att p� valfritt s�tt, 
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
-- 13) Skriv en sqlfr�ga som visar de genres som �r mest popul�ra. 
--     Lista genre och antal tracks i den genren. 
--     Visa den genre som har flest tracks f�rst och sedan i ned�tstigande 
--     ordning. Visa endast de genres som har fler �n 100 tracks. (GenreName, NrOfTracks)
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






------------------------------------------------
-- 101) Lista alla l�tar (Track) av Frank Zappa 
--      l�ngre �n 240000 ms 
------------------------------------------------
SELECT [Name], Milliseconds  
  FROM Track
 WHERE Composer LIKE '%Zappa%' 
   AND Milliseconds >= 240000

------------------------------------------------
-- 102) Lista f�rnamn, efternamn och land f�r alla
--      kunder (Customer) som finns i Brazil  
--      och Argentina.
------------------------------------------------
SELECT FirstName, LastName, Country
  FROM Customer
 WHERE Country IN ('Brazil', 'Argentina') 

------------------------------------------------
-- 103) Lista namn, millisekunder f�r alla l�tar som 
--      �r mellan 30000 och 60000 ms (Track)
------------------------------------------------
SELECT [Name], Milliseconds
  FROM Track
 WHERE Milliseconds BETWEEN 30000 AND 60000

------------------------------------------------
-- 104.1) Lista hela namnet, dvs f�r- och  
--        efternamn p� alla anst�llda i en 
--        kolumn (Employee) 
--
-- Tips:  Anv�nd CONCAT
------------------------------------------------
SELECT CONCAT(FirstName, ' ', LastName) 
  FROM Employee

------------------------------------------------
-- 104.2) Lista efternamnet p� alla anst�llda i 
--        med stora bokst�ver (Employee) 
--
-- Tips:  Anv�nd UPPER
------------------------------------------------
SELECT UPPER(LastName) 
  FROM Employee

------------------------------------------------
-- 104.3) Lista efternamnet p� alla anst�llda i 
--        med sm� bokst�ver (Employee) 
--
-- Tips:  Anv�nd LOWER
------------------------------------------------
SELECT LOWER(LastName) 
  FROM Employee

------------------------------------------------
-- 104.4) Lista f�rsta bokstaven i f�rnamnet och
--        efternamnet p� alla anst�llda enligt 
--        f�ljande format: 
--        D. Jansson
--
-- Tips:  Anv�nd CONCAT, SUBSTRING
------------------------------------------------
SELECT SUBSTRING(FirstName, 1, 1) + '. ' + LastName
  FROM Employee

------------------------------------------------
-- 104.5) Lista f�r- och efternamnet, f�delsedatum
--        samt �lder i antal �r p� alla anst�llda. 
--
-- Tips:  Anv�nd DATEDIFF, GETDATE, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   BirthDate,
	   DATEDIFF(YEAR, BirthDate, GETDATE())
  FROM Employee

------------------------------------------------
-- 104.6) Lista f�r- och efternamnet, anst�llningsdatum
--        samt antal dagar som anst�llda har arbetat. 
--
-- Tips:  Anv�nd DATEDIFF, GETDATE, DAY
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEDIFF(DAY, HireDate, GETDATE())
  FROM Employee

------------------------------------------------
-- 104.7) R�kna ut hur gammal varje anst�lld var
--        n�r de anst�lldes. 
--
-- Tips:  Anv�nd DATEDIFF, GETDATE, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEDIFF(YEAR, BirthDate, HireDate)
  FROM Employee


------------------------------------------------
-- 104.8) Ta reda p� vilken m�nad varje anst�lld 
--        �r f�dd. 
--
-- Tips:  Anv�nd DATENAME, MONTH
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATENAME(MONTH, BirthDate) AS BirthMonth
  FROM Employee

------------------------------------------------
-- 104.9) L�gg till 15 �r p� anst�llningsdatum 
--        f�r varje anst�lld.
--
-- Tips:  Anv�nd DATEADD, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEADD(YEAR, 15, HireDate) AS ModifiedHireDate
  FROM Employee

------------------------------------------------
-- 104.10) Lista alla anst�llda (Employee) som 
--        inte har n�gon chef. (ReportsTo)
------------------------------------------------
SELECT FirstName, LastName 
  FROM Employee
 WHERE ReportsTo IS NULL

------------------------------------------------
-- 105) Lista alla anst�llda som har kunder i USA 
--      V�lj anst�llnings id, f�r- och efternamn
--      samt antal amerikanska kunder per anst�lld.
------------------------------------------------
SELECT Employee.FirstName,
       Employee.LastName,
	   Employee.EmployeeId,
	   COUNT(Customer.CustomerId) AS NumberOfCustomers
  FROM Employee
 INNER JOIN Customer 
    ON Customer.SupportRepId = employee.employeeid
 WHERE Customer.Country='USA' 
 GROUP By Employee.FirstName, Employee.LastName, Employee.EmployeeId

------------------------------------------------
-- 106) G�r en self join med tabellen Employee.
--      Syftet �r att lista data �ver anst�llda 
--      tillsammans med en kolumn med chefens namn.
--      Anv�nd en LEFT OUTER JOIN.
------------------------------------------------
SELECT emp.EmployeeId, 
       emp.LastName + ' ' + emp.FirstName AS Employee, 
       mgr.EmployeeId AS ManagerId,
	   mgr.LastName + ' ' + mgr.FirstName AS Manager
  FROM Employee emp 
  LEFT JOIN Employee mgr 
    ON emp.ReportsTo = mgr.EmployeeId

------------------------------------------------
-- 107) Lista genre, antal l�tar per genre,
--      kortaste l�ten, l�ngsta l�ten samt 
--      snittl�ngden f�r en l�t.
--
-- Tips: GROUP BY, MIN, MAX, AVG, COUNT   
------------------------------------------------
SELECT Genre.[Name] AS Genre, 
       COUNT(*) AS NumberOfTracks, 
	   MIN(Milliseconds) AS ShortestTrack,
       MAX(Milliseconds) AS LongestTrack, 
	   AVG(Milliseconds) AS AverageTrackLength
  FROM Track 
 INNER JOIN Genre 
    ON Genre.GenreId = Track.GenreId
 GROUP BY Genre.[Name]

------------------------------------------------
-- 108) Lista genre, antal l�tar per genre,
--      kortaste l�ten, l�ngsta l�ten samt 
--      snittl�ngden f�r en l�t f�r alla genrer
--      som har fler �n 100 l�tar. 
--      Sortera listan fallande med den genre 
--      som har flest l�tar �verst.
--
-- Tips: GROUP BY, HAVING, MIN, MAX, AVG, COUNT   
------------------------------------------------
SELECT Genre.[Name] AS Genre, 
       COUNT(*) AS NumberOfTracks, 
	   MIN(Milliseconds) AS ShortestTrack,
       MAX(Milliseconds) AS LongestTrack, 
	   AVG(Milliseconds) AS AverageTrackLength
  FROM Track 
 INNER JOIN Genre 
    on Genre.GenreId = Track.GenreId
 GROUP BY Genre.[Name]
 HAVING COUNT(*) > 100
 ORDER BY NumberOfTracks DESC
 
------------------------------------------------
-- 109) G�r en CROSS JOIN mellan Genre och 
--      MediaType. Studera resultatet och f�rs�k
--      att f�rklara varf�r det.
------------------------------------------------
SELECT * 
FROM Genre
  CROSS JOIN MediaType

