using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;


    class IO
    {
       static string ProgramPath = "C:\\projekt\\";

       public static void CreateDirectories()
       { 
            DirectoryInfo dir = new DirectoryInfo(ProgramPath);
            if(!dir.Exists)
            {
                 dir.Create();
            }
       }
       public static string CreateNewFile(string name)   //Metoda tworząca plik z listą oraz ze względu, że podczas tworzenia pliku użytkownik może zmienić jego nazwę zwraca
       {                                                                                                                            // Jak finalnie będzie nazywała się lista
            FileInfo list = new FileInfo(ProgramPath + name + ".txt");
            Etykieta:
            if (list.Exists)
            {
                Console.Write("Taki plik już istnieje czy chcesz go nadpisać ? (tak/nie): ");
                Console.ForegroundColor = ConsoleColor.Red;
                string decision = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (decision)
                {
                    case "tak":
                        FileStream plik = list.Create();
                        plik.Close();
                    return name;

                    case "nie":
                        Console.Write("Podaj nazwę pliku: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        string newFileName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        return CreateNewFile(newFileName);
                        
                    default:
                        Console.WriteLine("!Błędna opcja! - spróbuj jeszcze raz.");
                        goto Etykieta;
                        
                }
            }
            else
            {
                Console.WriteLine("Tworzę plik");
                FileStream plik = list.Create();
                plik.Close();
                return name;
            }
       } 
       public static string[] GetfilesList()
       {
            DirectoryInfo newChecking = new DirectoryInfo(ProgramPath);
            FileInfo[] files = newChecking.GetFiles();
            string[] result = new string[files.Length];
            int index =0;
            foreach (FileInfo file in files)
            {
                result[index++] = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
            }
            return result;
       }
       public static string[] LoadFromFile(string file)
       {
            try
            {
                StreamReader newStream = new StreamReader(ProgramPath + file + ".txt");
                myArray newArray = new myArray();
                string[] resoult = null;
                while(!newStream.EndOfStream)
                {
                   resoult = newArray.Push(newStream.ReadLine());  // wykorzystujemy moją klasę myArray ponieważ nigdy nie wiemy ile w pliku będzie zadań do przechowania w tablicy
                }
                newStream.Close();
                if(resoult != null)
                {
                    return resoult;
                }
                else
                {
                    return new string[0];
                }
            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("Lista o takiej nazwie nie istnieje ! Proszę podać poprawną listę");
                Thread.Sleep(2000);
                return null;
            }
            

            
       }
       public static void SaveToFile(string listName,List<string> tasks)
       {
            Console.WriteLine(ProgramPath + listName + ".txt");
            Console.WriteLine(listName);
            StreamWriter newStream = new StreamWriter(ProgramPath + listName + ".txt");
            foreach (string task in tasks)
            {
                newStream.WriteLine(task);
            }
            newStream.Close();
       }
       public static void DeleteFile(string listName)
       { 
            FileInfo fileToDelete = new FileInfo(ProgramPath + listName + ".txt");
            fileToDelete.Delete();
       }

    }

    // Klasa odpowiedzialan za wszystkie operacje na plikach