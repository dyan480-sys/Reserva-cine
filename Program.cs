namespace Cine
{
    class Program
    {
        static void Main()
        {
            string [,] sala1= new string[5, 10];
            string [,] sala2= new string[5, 10];
            string [,] salavip= new string[5, 6];

            Console.WriteLine("Ingresar el numero de la sala: ");

            switch (Console.ReadLine())
            {
                case "1":
                    sala1 = visualsala(sala1);
                    mostrar(sala1);
                    break;
                case "2":
                    sala2 = visualsala(sala2);
                    mostrar(sala2);
                    break;
                case "vip":
                    salavip = visualsala(salavip);
                    mostrar(salavip);
                    break;
                default:
                    Console.WriteLine("Sala no disponible");
                    break;
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
                            sala[i, j] = "E" + (j + 1);
                            break;
                        case 1:
                            sala[i, j] = "D" + (j + 1);
                            break;
                        case 2:
                            sala[i, j] = "C" + (j + 1);
                            break;
                        case 3:
                            sala[i, j] = "B" + (j + 1);
                            break;
                        case 4:
                            sala[i, j] = "A" + (j + 1);    
                            break;
                        default:
                            break;
                    }
                }
            }

            return sala;
        }

        static string [,] mostrar(string[,] sala)
        {
            Console.Clear();
            for (int i = 0; i < sala.GetLength(0); i++)
            {
                for (int j = 0; j < sala.GetLength(1); j++)
                {
                    Console.Write($"{sala[i,j]} ");
                }
                Console.WriteLine();
            }
            return sala;
        }
    }
}