using System;
namespace Cine
{
    class Program
    {
        string nombre = "";
        string codigo = "";
        static void Main()
        {
            string usuario = "admin";
            string contrasena = "1234";
            string usuarioingresado;
            string contrasenaingresada;
            int opcion = 0;
            int ss = 0;
            string buscar = "";
            string [,] sala1= new string[5, 10];
            string [,] sala2= new string[5, 10];
            string [,] salavip= new string[5, 6];
            
            string[,] sala1_estado = new string[5, 10];
            string[,] sala2_estado = new string[5, 10];
            string[,] salavip_estado = new string[5, 6];

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

            while (true)
            {
                Console.WriteLine("ingrese su nombre de usuario: ");
                usuarioingresado = Console.ReadLine()!;
                Console.WriteLine("ingrese su contrasena: ");
                contrasenaingresada = Console.ReadLine()!;
                if (usuario == usuarioingresado && contrasena == contrasenaingresada)
                {
                    Console.WriteLine("inicio de sesion exitoso");
                    break;
                }
                else
                {
                    Console.WriteLine("usuario o contrasena incorrectos, intente de nuevo");
                }
            }

            while (opcion != 4)
            {
                Console.Clear();
                Console.WriteLine("sistema de reservas cine ");
                Console.WriteLine("MENU");
                Console.WriteLine("1. ver sala y asientos disponibles");
                Console.WriteLine("2. reservar asiento");
                Console.WriteLine("3. salir");
                Console.Write("elige una opcion (1-3): ");
                opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        while (ss == 0)
                        {   
                            Console.WriteLine("precione enter para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("salas disponibles:");
                            Console.WriteLine("1. sala 1");
                            Console.WriteLine("2. sala 2");
                            Console.WriteLine("3. sala vip");
                            Console.WriteLine("4. salir");
                            Console.WriteLine("elige la sala (<1-4>): ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("sala 1 seleccionada");
                                    sala1 = visualsala(sala1);
                                    mostrarestado(sala1, sala1_estado, sala1.GetLength(1));
                                    break;
                                case "2":
                                    Console.WriteLine("sala 2 seleccionada");
                                    sala2 = visualsala(sala2);
                                    mostrarestado(sala2, sala2_estado, sala2.GetLength(1));
                                    break;
                                case "3":
                                    Console.WriteLine("sala vip seleccionada");
                                    salavip = visualsala(salavip);
                                    mostrarestado(salavip, salavip_estado, salavip.GetLength(1));
                                    break;
                                case "4":
                                    ss = 1;
                                    break;
                                default:
                                    Console.WriteLine("Sala no disponible");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        while (ss == 0)
                        {   
                            
                            Console.Clear();
                            Console.WriteLine("salas disponibles:");
                            Console.WriteLine("1. sala 1");
                            Console.WriteLine("2. sala 2");
                            Console.WriteLine("3. sala vip");
                            Console.WriteLine("4. salir");
                            Console.WriteLine("elige la sala (<1-4>): ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("sala 1 seleccionada");
                                    sala1 = visualsala(sala1);
                                    mostrarestado(sala1, sala1_estado, sala1.GetLength(1));
                                    Console.Write("ingrese el numero de asiento a reservar: (ejemplo A1):");
                                    buscar = Console.ReadLine()!;
                                    reservarasiento(sala1, sala1_estado, buscar);
                                    Console.WriteLine("precione enter para continuar");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Console.WriteLine("sala 2 seleccionada");
                                    sala2 = visualsala(sala2);
                                    mostrarestado(sala2, sala2_estado, sala2.GetLength(1));
                                    Console.Write("ingrese el numero de asiento a reservar: (ejemplo A1):");
                                    buscar = Console.ReadLine()!;
                                    reservarasiento(sala2, sala2_estado, buscar);
                                    Console.WriteLine("precione enter para continuar");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Console.WriteLine("sala vip seleccionada");
                                    salavip = visualsala(salavip);
                                    mostrarestado(salavip, salavip_estado, salavip.GetLength(1));
                                    Console.Write("ingrese el numero de asiento a reservar: (ejemplo A1):");
                                    buscar = Console.ReadLine()!;
                                    reservarasiento(salavip, salavip_estado, buscar);
                                    Console.WriteLine("precione enter para continuar");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    ss = 1;
                                    break;
                                default:
                                    Console.WriteLine("Sala no disponible");
                                    Console.WriteLine("precione enter para continuar");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("opcion no valida");
                        break;
                }
            }
        }   

        static string[,] visualsala(string[,] sala)
        {
            for (int i = 0; i < sala.GetLength(0); i++)
            {
                for (int j = 0; j < sala.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0:
                            sala[i, j] = "|E" + (j + 1) + "|";
                            break;
                        case 1:
                            sala[i, j] = "|D" + (j + 1) + "|";
                            break;
                        case 2:
                            sala[i, j] = "|C" + (j + 1) + "|";
                            break;
                        case 3:
                            sala[i, j] = "|B" + (j + 1) + "|";
                            break;
                        case 4:
                            sala[i, j] = "|A" + (j + 1) + "|";
                            break;
                        default:
                            break;
                    }
                }
            }

            return sala;
        }

        static void reservarasiento(string[,] sala, string[,] estado, string buscar)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < sala.GetLength(1); j++)
                {
                    if (sala[i, j] == buscar)
                    {
                        if (estado[i, j] == "libre")
                        {
                            estado[i, j] = "ocupado";
                            Console.WriteLine("asiento reservado con exito");
                        }
                        else
                        {
                            Console.WriteLine("el asiento ya esta ocupado");
                        }
                    }
                }
            }
        }
         static void mostrarestado(string[,] nombres, string[,] estado, int columnas)
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