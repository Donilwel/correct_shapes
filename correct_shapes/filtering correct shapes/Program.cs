using System;
using System.IO;
using System.Text;
using Class;
namespace filtering_correct_shapes
{
    internal class Program
    {
        const string pathSquare = "square.txt";
        const string patheqTriangale = "eqTriangle.txt";
        static string path;

        static StreamWriter sw;

        static int N = 0;
        static int M = 0;

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //create file if he don't exist
            if (File.Exists(pathSquare) && File.Exists(patheqTriangale))
            {
                File.Create(pathSquare).Close() ;
                File.Create(patheqTriangale).Close();
            }

            do
            {
                Console.WriteLine("Введите название файла в формате [name your file].txt");
                Console.WriteLine("В файле данные должны быть в формате:");
                Console.WriteLine("N [число] M [число]");
                Console.WriteLine("Square/EqTriangle [координата x левой нижней] [координата y левой нижней] [длина стороны правильной фигуры]");
                path = Console.ReadLine();
                try
                {
                    StartWork();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Exception - Пустой файл");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Для повтора действий введите 1");
            } while (Console.ReadLine() == "1" );


        }

        private static void StartWork() {
            // If the file exists, then read it and Extension file txt
            if (File.Exists(path) && new FileInfo(path).Extension == ".txt")
            {
                // Read file 
                StreamReader reader = new StreamReader(path);

                string[] line = reader.ReadLine().Split(' ');
                var encoding = reader.CurrentEncoding;
                    if (line[0] == "N" && line[2] == "M")
                    {
                        // If this not end of file
                        try
                        {
                            N = int.Parse(line[1]);
                            M = int.Parse(line[3]);
                            while (!reader.EndOfStream)
                            {
                                line = reader.ReadLine().Split(' ');
                                // Check figure
                                switch (line[0])
                                {
                                    case "Square":
                                        // We initialize the class object and pass parameters to the constructor
                                        var square = new Square(new Point(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]));

                                        Console.WriteLine(square.ToString() + " Radius = " + square.Radius());

                                        Check(pathSquare, square.Radius(), M, String.Join(' ', line));

                                        break;

                                    case "EqTriangle":
                                        // We initialize the class object and pass parameters to the constructor

                                        var eqTriangle = new EqTriangle(new Point(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]));

                                        // outpitung information to console 
                                        Console.WriteLine(eqTriangle.ToString() + " Radius = " + eqTriangle.Radius());

                                        Check(patheqTriangale, eqTriangle.Radius(), N, String.Join(' ', line));

                                        break;
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Exception - Неверный формат данных");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Exception - Заполнены не все данные");
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Exception - Файл не найден");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не указаны значения N и M. Формат записи в файле - N 100 M 200 ");
                    }
            }
            else
            {
                Console.WriteLine("Такого файла не существует или неверное расширение");
            }
        }

        /// <summary>
        /// check for the radius of the circumscribed circle with a large value
        /// </summary>
        /// <param name="path"> path to file </param>
        /// <param name="radius"> raduis </param>
        /// <param name="value"> N or M </param>
        /// <param name="line"> string to write </param>
        public static void Check(string path, int radius, int value, string line) {
            try
            {
                sw = new StreamWriter(path, true);
                if (radius > value)
                    sw.WriteLine(line);
                sw.Close();
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Exception - Файла не существует");
            }
        }
    }
}//wait my 10 mark))))
