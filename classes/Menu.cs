using System;
using System.Threading;


    static class Menu
    {
        public static bool Program = true;
        private static MenuItem[] menuItemsArray = CreateMainMenu(); 
        private static MenuItem[] CreateMainMenu()
        {
            return new MenuItem[3] {new CreateNewList("Utworz nowa liste zadan", 1),new LoadActualLists("Wyswietl zapisane listy zadan", 2),new Exit("Zamknij program", 3)};
        } // metoda tworząca obiekty Menu oraz inicjalizująca tablicę menuItemsArray

        public static void ShowMenu()
        {   
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("                                      APLIKACJA TO DO LIST                                     ");
            Console.WriteLine("                                    Jakub Czarnecki WRX75755                                   ");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("");
            foreach(MenuItem item in menuItemsArray){
                item.describe();
            }
        } // moetoda wyświtlająca menu na ekranie

        public static void ChoicePosition(){
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("Wybierz pozycje: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int userChoiceposition = 0;
            try{
                    userChoiceposition = Int32.Parse(Console.ReadLine());
            }
            catch(FormatException){
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Należy podać numer przypisany opcji menu");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for(int i=0; i<menuItemsArray.Length;i++)
            {
                if(menuItemsArray[i].position == userChoiceposition){
                    Console.Clear();
                    menuItemsArray[i].execute();
                }
                else{
                    Console.WriteLine("Podany numer nie pasuje do żadnej z pozycji");
                    Console.Clear();
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        } 

}
//Klasa odpowiedzialna za Wyświetalnie oraz tworzenie Menu ( powiązana z klasą MenuItems )
