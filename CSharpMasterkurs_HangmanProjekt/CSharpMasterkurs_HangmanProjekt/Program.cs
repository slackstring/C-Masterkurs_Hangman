using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace ProjektHangman
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();

            static void MainMenu()
            {
                while (true)
                {

                    Console.ResetColor();
                    Console.WriteLine("### HANGMAN ###");
                    Console.WriteLine("###############");
                    Console.WriteLine("\nWähle ein Aktion aus:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n[1] Spielen\n[2]Beenden");
                    Console.ResetColor();
                    Console.WriteLine("\nAktion:");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    bool abort = false;
                    string word;
                    switch (choice)
                    {
                        case 1:
                            StartGame();
                            break;
                        case 2:
                            abort = true;
                            break;
                    }
                    if (abort == true)
                    {
                        break;
                    }
                    Console.Clear();
                }
                
               
            }

            static void StartGame()
            {
                
                string[] bibliothek = new string[] {"lastwagen","theater","bockwurst","tastatur","smartphone","computer"};
                Random rnd = new Random();
                int index = rnd.Next(0, bibliothek.Length);
                string lösung = bibliothek[index].ToLower();
                GameLoop(lösung);

            }

            static void GameLoop(string wort)
            {
                int maxTrys=6;
                int actTrys = 0;
                bool win = false;
                bool treffer = false;
                int nTreffer = 0;
                char[] userResult = new char[wort.Length];
                for(int k=0; k<wort.Length; k++)
                {
                    userResult[k] = '_';                  
                }
               
                
                
                while ((actTrys < maxTrys) && (win==false))
                {

                    Console.Clear();
                    Console.WriteLine("Gesuchtes Wort:  ");
                    Console.WriteLine(userResult);

                    Console.Write("\n\nVerbleibende Leben: ");
                    for (int j = 1; j <= maxTrys - actTrys; j++)
                    {
                        
                        Console.Write("X");
                    }
                    Console.WriteLine("\n\nGebe einen Buchstaben ein:");
                    char input = Convert.ToChar(Console.ReadLine());
                    for (int i=0; i < wort.Length; i++)
                    {
                        if (input == wort[i])
                        {
                            if (userResult[i] != wort[i])
                            {
                                nTreffer += 1;
                            }
                            userResult[i]=input;
                            treffer = true;
                            
                        }
                    }
                    if (treffer==false)
                    {
                        actTrys += 1;
                    }else
                    {
                        treffer = false;
                        
                        if(nTreffer  == wort.Length)
                        {
                            win = true;
                        }
                    } 
                }
                Console.Clear();
                if (win)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("GEWONNEN!");
                    Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER");
                    Console.ReadLine();
                }
            }
        }
    }
}
