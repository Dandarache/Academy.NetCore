DECLARE @albumid INT
DECLARE @album_cursor CURSOR 

SET @album_cursor = CURSOR FOR  
SELECT AlbumId
  FROM Album

OPEN @album_cursor

FETCH NEXT FROM @album_cursor INTO @albumid
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT CONCAT('Album Id: ', @albumid)

	DECLARE @trackid INT
	DECLARE @cursor CURSOR 
	DECLARE @tracknumber INT = 1

	SET @cursor = CURSOR FOR  
	SELECT TrackId
	  FROM Track
	 INNER JOIN Album
		ON Album.AlbumId = Track.AlbumId
	 --WHERE Album.Title LIKE '%Zooropa%'
	 WHERE Album.AlbumId = @albumid

	OPEN @cursor

	FETCH NEXT FROM @cursor INTO @trackid
	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT CONCAT('Track Id: ', @trackid, ', Track Number: ', @tracknumber)

		UPDATE Track SET TrackNumber = @tracknumber WHERE TrackId = @trackid

		--   i++
		SET @tracknumber = @tracknumber + 1
		FETCH NEXT FROM @cursor INTO @trackid
	END

	CLOSE @cursor
	DEALLOCATE @cursor

	FETCH NEXT FROM @album_cursor INTO @albumid

END

CLOSE @album_cursor
DEALLOCATE @album_cursor
