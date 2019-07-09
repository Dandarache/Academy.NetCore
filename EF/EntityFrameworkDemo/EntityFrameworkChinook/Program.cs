using System;

namespace EntityFrameworkChinook
{
    class Program
    {
        static void Main(string[] args)
        {
            ChinookContext chinookContext = new ChinookContext();

            var albums = chinookContext.Album;

            foreach (var album in chinookContext.Album)
            {
                Console.WriteLine($"{album.Title}");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
