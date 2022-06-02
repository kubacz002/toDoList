using System;
using System.Collections.Generic;
using System.Threading;


    static class TaskList
    {
        public static void CreateNewListItem(string listName) // Pobiera elementy z pliku oraz zwraca obiekt ListItem("Uzupełnia go o zadania zapisane z pliku")
        {
           string[] loadedTasks = IO.LoadFromFile(listName);

           if(loadedTasks != null)
           {
                ListItem newList = new ListItem(listName,loadedTasks);
                string condition = "";
                while(condition != "stopAndSave" && condition !="stopWithoutSave")
                {
                    newList.ShowList();
                    condition = newList.AddNewTask();
                }

                if(condition == "stopAndSave")
                {
                    SaveList(newList);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zapisywanie listy..");
                    Console.ResetColor();
                    Thread.Sleep(2000);

                }
           }
        }
        public static void CreateNewListItem(string listName, string createFile) // Tworzy nowy plik oraz zwraca obiekt ListTitem ("pusty") - Wymaga podania argumentu "create_new"
        {
            if(createFile == "create_new")
            {
                string FinallyListName = IO.CreateNewFile(listName);
                ListItem newList = new ListItem(FinallyListName);

                string condition = "";

                while(condition != "stopAndSave" && condition !="stopWithoutSave")
                {
                    newList.ShowList();
                    condition = newList.AddNewTask();
                }

                if(condition == "stopAndSave")
                {
                    SaveList(newList);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zapisywanie listy..");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }
            else
            {
                throw new ValidCreateNewListItemArguments();
            }
        }
        public static void LoadList() //Pobiera pliki z folderu i wyświetla je na ekranie tworząc menu dostępnych list
        { 
           foreach(string List in IO.GetfilesList())
           {
                Console.WriteLine($" ----> {List}");
           }
        }

        public static void LoadList(ConsoleColor color) //  -||- dodatkowo daje opcja wyboru koloru w jakim ma być prezentowana lista
        { 
           Console.ForegroundColor = color;
           foreach(string List in IO.GetfilesList())
           {
                Console.WriteLine($" ----> {List}");
           }
           Console.ForegroundColor = ConsoleColor.White;
        }

        public static void SaveList(ListItem savedObject)
        {
            List<string> tasks = savedObject.ReturnTasks();
            IO.SaveToFile(savedObject.ListName,tasks);
        }
    }

// Klasa odpowiedzialna za pracę na listach, tworzenia nowych instancji list, wyswietlanie oraz tworzenie nowych list