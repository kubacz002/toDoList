using System;
using System.Collections.Generic;


    class ListItem
    {
        public int TaskNumber { get; set; }
        public string ListName { get; set; }
        private string[] Tasks { get; set; }

        myArray newMyArray;

        public ListItem(string ListName)
        {
            this.ListName = ListName;
            this.TaskNumber = 0;
            this.newMyArray = new myArray();
        }

        public ListItem(string ListName, string[] tasks)
        {
            this.ListName= ListName;
            this.Tasks = tasks;
            this.TaskNumber = tasks.Length;
            this.newMyArray = new myArray(tasks);
        }

        public void ShowList()
        {
            Console.Clear();
            Console.Write("Pracujesz na liście: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.ListName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Ilość zadań do wykonania: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.TaskNumber);
            Console.ForegroundColor = ConsoleColor.Blue;

            if(Tasks != null)
            {
                for(int i = 0; i < Tasks.Length; i++)
                {
                    Console.WriteLine($" --> [{i+1}] {Tasks[i]}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public string AddNewTask()
        {
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.Write("Aby zapisać zadania w liście proszę w lini poleceń napisać ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\"save\"");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" Aby wyjść bez zapisywania prosze napisać  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\"stop\"");
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine("Dodaj nowe zadanie");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(this.ListName);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("/> ");
            Console.ForegroundColor = ConsoleColor.White;

            string newTask = Console.ReadLine();

            if(newTask == "save")
            {
                return "stopAndSave";
            }
            else if(newTask == "stop")
            {
                return "stopWithoutSave";
            }

            this.TaskNumber++;
            this.Tasks = newMyArray.Push(newTask);
            return newTask;

        }
        public List<string> ReturnTasks() //Wykorzystałem listę tylko na potrzeby zadania
        {
            List<string> tasks = new List<string>();
            if(this.Tasks != null)
            {
                foreach(string task in this.Tasks)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }
    }

    //Klasa odpowiedzialna za ToDoListy - na jej podstawie powstają instancje nowych list