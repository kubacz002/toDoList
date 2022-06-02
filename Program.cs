using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            IO.CreateDirectories();
            do
            {
                Menu.ShowMenu();
                Menu.ChoicePosition();
            }
            while(Menu.Program);
        }
    }

    //Główna klasa programu