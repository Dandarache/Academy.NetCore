using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDemo
{
    public class ChinookUserInterface
    {
        private readonly ChinookDataRepository chinookDataRepository = 
            new ChinookDataRepository();

        public void Run()
        {
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine(
                    $"Chinook - Musikdatabas\n" +
                    $"\n" +
                    $"Vad vill du göra?\n" +
                    $"\n" +
                    $"(1) Skapa ny artist med album och allt\n" +
                    $"(2) Lista alla artister\n" +
                    $"(3) Lista alla artister med album och låtar, dvs rubbet\n" +
                    $"(4) Uppdatera artist med album och allt\n" +
                    $"(5) Radera artist med album och allt\n" +
                    $"(q) Avsluta programmet");

                char pressedChar = Console.ReadKey().KeyChar;
                switch (pressedChar)
                {
                    case '1':
                        DisplayCreateArtistDialog();
                        break;
                    case '2':
                        DisplayAllArtists(false);
                        break;
                    case '3':
                        DisplayAllArtists(true);
                        break;
                    case '4':
                        break;
                    case '5':
                        DisplayDeleteDialog();
                        break;
                    case 'q':
                        return;
                }

                Console.Clear();
            }
        }

        private void DisplayCreateArtistDialog()
        {
            Console.Clear();
            Console.WriteLine("Ange namn på artisten du vill skapa:");
            var userInput = Console.ReadLine();

            var artist = new Artist
            {
                ArtistName = userInput
            };

            int newArtistId =
                chinookDataRepository.CreateArtist(artist);

            Console.WriteLine($"Artisten skapades med ID: {newArtistId}");

            ExitDialog();
        }

        private void DisplayDeleteDialog()
        {
            Console.Clear();
            Console.WriteLine("Ange ID på artisten du vill radera:");
            var userInput = Console.ReadLine();
            int.TryParse(userInput, out int artistId);

            string returnValue =
                chinookDataRepository.DeleteArtist(artistId);

            Console.WriteLine(returnValue);

            ExitDialog();
        }

        private static void ExitDialog()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri knapp för att återgå till huvudmeny.");
            Console.ReadKey();
        }

        private void DisplayAllArtists(bool listAllData)
        {
            List<Artist> artists = chinookDataRepository.GetAllArtist(listAllData);

            foreach (var artist in artists)
            {
                Console.WriteLine($"ID: {artist.ArtistId}, Artist Name: {artist.ArtistName}");
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine($"\t{album.AlbumTitle}");
                    foreach (var track in album.Tracks)
                    {
                        Console.WriteLine($"\t\t{track.TrackName}");
                    }
                }
            }
            ExitDialog();
        }
    }
}
