using System;
using System.Threading;


    

    class MenuItem
    {
        protected string text { get; set; }
        public int position { get; set; }
        public MenuItem(string desc,int position) {
            this.text = desc;
            this.position = position;
        }
        public virtual void execute(){
            
        }

        public void describe(){
            Console.WriteLine($"[{this.position}] {this.text}"); 
        }
    }

    class CreateNewList : MenuItem
    {
        public CreateNewList(string desc,int position):base(desc,position){ }
 
        public override void execute()
        {
            Console.WriteLine("Jak chcesz nazwać swoją nową listę ToDoList ?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("@Nazwa listy: />");
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            string listName = Console.ReadLine();
            Console.ForegroundColor=ConsoleColor.White;
            TaskList.CreateNewListItem(listName, "create_new");

        }
    }

    class LoadActualLists : MenuItem
    {
        public LoadActualLists(string desc,int position):base(desc,position){ }
        public override void execute()
        {
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("Dostępne listy: ");
            TaskList.LoadList(ConsoleColor.DarkBlue);
            Console.WriteLine();

            Console.WriteLine("Wybierz listę wpisująć w terminalu jej nazwę. Aby usunąć, którąś z list proszę w terminalu napisać \"delete\"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aby wyjść wpisz \"cancel\"");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("all_LIST");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("/> ");
            Console.ForegroundColor = ConsoleColor.White;
            string listName = Console.ReadLine();
            if(listName == "delete")
            { 
                Console.Write("Którą listę chcesz usunąć: ");
                string ListNameToDelete = Console.ReadLine();
                IO.DeleteFile(ListNameToDelete);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Usuwanie listy: {ListNameToDelete}");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
            else if(listName == "cancel")
            {
                
            }
            else
            { 
                TaskList.CreateNewListItem(listName);
            }         
        }
    }

    class ChooseList : MenuItem
    {
        public ChooseList(string desc,int position):base(desc,position){ }
        public override void execute()
        {
            
        }
    }
    class Exit : MenuItem
    {
        public Exit(string desc,int position):base(desc,position){ }
        public override void execute()
        {
            Menu.Program = false;
        }
    }



    // Klassy odpowiedzialna za tworzenie elementów menu na podstawie instancji tych klass tworzone są kolejne pozycje menu a więc podczas rozbudowy programu należy
    // Dodawać kolejne pozycje w tym miejscu.
