using System;
using System.Threading;

namespace juegomara
{
    
    class Program
    {
        static String[,] grid = new String[10,10];

        //Ubicacion del perro
        static int px;
        static int py = 9;

        //Ubicacion del hueso
        static int hx = 9;
        static int hy;

        static Boolean DebugEnabled;

        static Boolean Movement;

        static bool Playing = true; //Used to avoid some weird buggs xd

        static void Main(string[] args)
        {

            Console.WriteLine("© 2019-2021 iMarcoMC");
            Console.WriteLine("Vos sos la P (Perro), tu objetivo es llegar a la H (H) hueso");
            Console.WriteLine("Si sales del cuadro pierdes.");
            Console.WriteLine("Para moverte usa W A S D si activas el movimiento para todos lados");
            Console.WriteLine("Si no activas el movimiento para todos lados, unicamente puedes usar w y d");
            Console.WriteLine("Si intentas volver por donde ya pasaste pierdes");
            //Console.WriteLine("Si quieres se puede activar el limite de intentos");

            Thread.Sleep(1000);


            Console.WriteLine("Deseas permitir el movimiento para todos los lados? (Y/n)");


            String res = Console.ReadLine();


            if (res.ToUpper() == "Y")
            {
                Movement = true;
                Console.WriteLine("Movimiento para todos lados activado.");

                Thread.Sleep(1000);

                StartGame();


            }
            else
            {
                Movement = false;
                Console.WriteLine("Movimiento para todos lados Desactivado.");

                Thread.Sleep(1000);

                StartGame();


            }
        }

       static void StartGame(){
            //Delete all previus lines lol
            Console.Clear();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Debug("Seteando valores default a " + x + " -- " + y);
                    grid[x, y] = "_";

                }
            }

            Debug("Seteando perro y hueso");

            grid[9, 0] = "P";
            grid[0, 9] = "H";

            Debug("Dibujando grilla");
            DrawGrid();


            Debug("Waiting for player input");
            ReadInput();
        }

        static void Debug(String info)
        {
            if (DebugEnabled)
            {
                Console.WriteLine("Debug - " + info);
            }
        }


        static void DrawGrid()
        {
            if(px == hx && py == hy)
            {
                Console.WriteLine("Llegaste al hueso!");
                Playing = false;
                return;
            }
            Console.WriteLine("   |1|2|3|4|5|6|7|8|9|9|");

            for (int i = 0; i < 9; i++)
            {

                Console.WriteLine((i+1) + "  |" + grid[i, 0] + "|" + grid[i, 1] + "|" + grid[i, 2] + "|" + grid[i, 3] + "|" + grid[i, 4] + "|" + grid[i, 5] + "|" + grid[i, 6] + "|" + grid[i, 7] + "|" + grid[i, 8] + "|" + grid[i, 9] + "|");
            }
            Console.WriteLine("10" + " |" + grid[9, 0] + "|" + grid[9, 1] + "|" + grid[9, 2] + "|" + grid[9, 3] + "|" + grid[9, 4] + "|" + grid[9, 5] + "|" + grid[9, 6] + "|" + grid[9, 7] + "|" + grid[9, 8] + "|" + grid[9, 9] + "|");
            
        }

        static void ReadInput()
        {
            while (Playing)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key.Equals(ConsoleKey.W))
                {
                    Debug("Pressed W key");

                    //Go up one row

                    if (py -1 !< 0)
                    {
                        Console.WriteLine("No puedes salir de la grilla!");
                        Playing = false;
                        return;

                    }

                    if (grid[py -1, px] == "=")
                    {
                        Console.WriteLine("No puedes volver a pasar por el mismo lugar. Perdiste");
                        Playing = false;
                        return;
                    }


                    grid[py, px] = "=";

                    py -= 1;

                    grid[py, px] = "P";

                    Console.Clear();
                    DrawGrid();

                }else if (key.Equals(ConsoleKey.D))
                {

                    if (px + 1 > 9)
                    {
                        Console.WriteLine("No puedes salir de la grilla!");
                        return;
                    }

                    Debug("Pressed key D");

                    if (grid[py, px + 1] == "=")
                    {
                        Console.WriteLine("No puedes volver a pasar por el mismo lugar. Perdiste");
                        Playing = false;
                        return;
                    }


                    grid[py, px] = "=";

                    px += 1;

                    grid[py, px] = "P";

                    Console.Clear();
                    DrawGrid();
                }
                else
                {
                    Console.WriteLine("Tecla invalida.");
                }

                if (Movement)
                {
                    if (key.Equals(ConsoleKey.A))
                    {

                        if (px - 1 < 0)
                        {
                            Console.WriteLine("No puedes salir de la grilla!");
                            return;

                        }

                        if (grid[py, px - 1] == "=")
                        {
                            Console.WriteLine("No puedes volver a pasar por el mismo lugar. Perdiste");
                            Playing = false;
                            return;
                        }

                        grid[py, px] = "=";

                        px -= 1;

                        grid[py, px] = "P";

                        Debug("Pressed key A");

                        Console.Clear();
                        DrawGrid();
                    }
                    else if (key.Equals(ConsoleKey.S))
                    {

                        if (py + 1 > 9)
                        {
                            Console.WriteLine("No puedes salir de la grilla!");
                            return;

                        }

                        if (grid[py + 1, px] == "=")
                        {
                            Console.WriteLine("No puedes volver a pasar por el mismo lugar. Perdiste");
                            Playing = false;
                            return;
                        }

                        grid[py, px] = "=";

                        py += 1;

                        grid[py, px] = "P";

                        Debug("Pressed key S");

                        Console.Clear();
                        DrawGrid();
                    }
                }
                
                
            }
                
        }
    }

    
}
