using System;

// Ta klasa ma za zadanie tworzenie tablicy bez konieczności określania indexu z góry :) Coś w stylu tablicy z pythona i JS i jej metody push/shift
    class myArray
    {
        public int indexer = 0;
        public string[] alredyArray;

        public myArray()
        {

        }
        public myArray(string[] array)
        {
            alredyArray = array;
            indexer = array.Length;
        }

        public string[] Push(string element)
        {
            if(alredyArray == null)
            {
                indexer++;
                alredyArray = new string[indexer];
                alredyArray[0] = element;
            }
            else
            {
                string[] buffor = alredyArray;
                indexer++;
                alredyArray = new string[indexer];
                for(int i=0; i<buffor.Length;i++)
                {
                    alredyArray[i] = buffor[i];
                }
                alredyArray[indexer-1] = element;
            }
            return alredyArray;
        
        }
    }

    // Jest to moja klasa stworzona na podstawy zadania, której zadaniem jest stworzenie nowego typu tablic ( podobnych do tych z JavaScript czy Python ) 
    // Pozwala na tworzenie tablicy bez określania jej długości. Tablica sama będzie zwiększać swoją wielkość dynamicznie.