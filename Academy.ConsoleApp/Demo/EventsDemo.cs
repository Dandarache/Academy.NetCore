using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class EventsDemo
    {
        public void Run()
        {
            // Events är händelser som inträffar i klasserna som sedan 
            // kommuniceras till alla som "lyssnar".

            string myFilePath = @"C:\Temp\Academy\fsw";

            System.IO.FileSystemWatcher fileSystemWatcher = 
                new FileSystemWatcher(myFilePath);

            fileSystemWatcher.EnableRaisingEvents = true;

            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.Created += FileSystemWatcher_Created1;
            fileSystemWatcher.Created += FileSystemWatcher_Created2;


            Console.WriteLine($"I'm watching this folder: '{myFilePath}'");
            Console.ReadKey();
        }

        private void FileSystemWatcher_Created1(
            object sender, 
            FileSystemEventArgs e)
        {
            Console.WriteLine($"File Created (1): {e.Name}");
        }
        private void FileSystemWatcher_Created2(
            object sender,
            FileSystemEventArgs e)
        {
            Console.WriteLine($"File Created (2): {e.Name}");
        }


        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File Deleted: {e.FullPath}");
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File Renamed: {e.Name}");
        }
    }
}
