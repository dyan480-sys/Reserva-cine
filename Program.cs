using System;

namespace Cine
{
    class Program
    {
        static void Main()
        {
           
            string[,] sala1 = new string[5, 10];
            string[,] sala2 = new string[5, 10];
            string[,] salavip = new string[5, 6];

            
            string[,] sala1_estado = new string[5, 10];
            string[,] sala2_estado = new string[5, 10];
            string[,] salavip_estado = new string[5, 6];

            // Llenar lo nombres
            sala1 = visualsala(sala1);
            sala2 = visualsala(sala2);
            salavip = visualsala(salavip);

            // Llenal estad como libre
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sala1_estado[i, j] = "libre";
                    sala2_estado[i, j] = "libre";
                }
                for (int j = 0; j < 6; j++)
                {
                    salavip_estado[i, j] = "libre";
                }
            }

            int opcion = 0;
            while (opcion != 3)
            {
                Console.Clear();
                Console.WriteLine("sistema de reservas cine ");
                Console.WriteLine("MENU");
                Console.WriteLine("1. ver sala y asientos disponibles");
                Console.WriteLine("2. reservar asiento");

                Console.WriteLine("3. salir");
                Console.Write("elige una opcion (1-3): ");

                string entrada = Console.ReadLine()!;
                if (entrada == "1") opcion = 1;
                else if (entrada == "2") opcion = 2;
                else if (entrada == "3") opcion = 3;
                else
                {
                    Console.WriteLine("opcion invalida.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        VerSala(sala1, sala2, salavip, sala1_estado, sala2_estado, salavip_estado);
                        break;
                    case 2:
                        ReservarAsiento(sala1, sala2, salavip, sala1_estado, sala2_estado, salavip_estado);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("gracias por usar el sistema.");
                        break;
                }
            }
        }

        static void VerSala(string[,] sala1, string[,] sala2, string[,] salavip,
                            string[,] e1, string[,] e2, string[,] evip)
        {
            Console.Clear();
            Console.WriteLine("elige la sala:");
            Console.WriteLine("1. sala 1");
            Console.WriteLine("2. sala 2");
            Console.WriteLine("3. sala vip");
            Console.Write("opcion: ");
            string op = Console.ReadLine()!;
            Console.Clear();

            if (op == "1")
            {
                Console.WriteLine("sala 1 ");
                mostrarConEstado(sala1, e1, 10);
            }
            else if (op == "2")
            {
                Console.WriteLine("sala 2 ");
                mostrarConEstado(sala2, e2, 10);
            }
            else if (op == "3")
            {
                Console.WriteLine("sala vip ");
                mostrarConEstado(salavip, evip, 6);
            }
            else
            {
                Console.WriteLine("sala no valida.");
                Console.ReadKey();
            }
        }

        static void ReservarAsiento(string[,] s1, string[,] s2, string[,] svip,
                                    string[,] e1, string[,] e2, string[,] evip)
        {
            Console.Clear();
            Console.WriteLine("elige la sala para reservar:");
            Console.WriteLine("1. sala 1");
            Console.WriteLine("2. sala 2");
            Console.WriteLine("3. sala vip");
            Console.Write("opcion: ");
            string op = Console.ReadLine()!;

            if (op == "1")
            {
                Console.Clear();
                Console.WriteLine(" sala 1 ");
                mostrarConEstado(s1, e1, 10);
                ProcesoReserva(e1, 10);
            }
            else if (op == "2")
            {
                Console.Clear();
                Console.WriteLine(" sala 2 ");
                mostrarConEstado(s2, e2, 10);
                ProcesoReserva(e2, 10);
            }
            else if (op == "3")
            {
                Console.Clear();
                Console.WriteLine(" sala vip ");
                mostrarConEstado(svip, evip, 6);
                ProcesoReserva(evip, 6);
            }
            else
            {
                Console.WriteLine("sala no valida.");
                Console.ReadKey();
            }
        }

        static void ProcesoReserva(string[,] estado, int columnas)
        {
            Console.Write("\ningresa el asiento (ej: A1): ");
            string input = Console.ReadLine()!;


            if (input.Length < 2)
            {
                Console.WriteLine("error: formato invalido.");
                Console.ReadKey();
                return;
            }

   
            string letra = "";
            string numStr = "";

            if (input.Length == 2)
            {
                letra = input.Substring(0, 1);
                numStr = input.Substring(1, 1);
            }
            else if (input.Length == 3)
            {

                letra = input.Substring(0, 1);
                numStr = input.Substring(1, 2);
            }
            else
            {
                Console.WriteLine("error: asiento no valido.");
                Console.ReadKey();
                return;
            }


            bool numValido = false;
            int num = 0;
            for (int n = 1; n <= columnas; n++)
            {
                if (numStr == n.ToString())
                {
                    num = n;
                    numValido = true;
                    break;
                }
            }

            if (!numValido)
            {
                Console.WriteLine($"error: columna debe ser 1-{columnas}.");
                Console.ReadKey();
                return;
            }

            int fila = -1;
            if (letra == "A") fila = 4;
            else if (letra == "B") fila = 3;
            else if (letra == "C") fila = 2;
            else if (letra == "D") fila = 1;
            else if (letra == "E") fila = 0;
            else
            {
                Console.WriteLine("error: fila debe ser A-E.");
                Console.ReadKey();
                return;
            }

            int col = num - 1;

            if (estado[fila, col] == "ocupado")
            {
                Console.WriteLine("ya esta ocupado.");
            }
            else
            {
                estado[fila, col] = "ocupado";
                Console.WriteLine("reserva exitosa!");
            }
            Console.ReadKey();
        }

        static string[,] visualsala(string[,] sala)
        {
            for (int i = 0; i < sala.GetLength(0); i++)
            {
                for (int j = 0; j < sala.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0: sala[i, j] = "E" + (j + 1); break;
                        case 1: sala[i, j] = "D" + (j + 1); break;
                        case 2: sala[i, j] = "C" + (j + 1); break;
                        case 3: sala[i, j] = "B" + (j + 1); break;
                        case 4: sala[i, j] = "A" + (j + 1); break;
                    }
                }
            }
            return sala;
        }

        static void mostrarConEstado(string[,] nombres, string[,] estado, int columnas)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (estado[i, j] == "ocupado")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{nombres[i, j]} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{nombres[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine("\nverde = disponible | rojo = ocupado");
        }
    }
}