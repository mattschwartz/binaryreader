using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;

            if (args.Length > 0) {
                file = args[0];
            } else {
                Console.Write("Enter path: ");
                file = Console.ReadLine();
            }

            if (!File.Exists(file)) {
                Console.WriteLine("File {0} does not exist.", file);
                return;
            }

            Parse(file);

            Console.WriteLine("\nDone. Press any key to continue... ");
            Console.ReadKey();
        }

        private static void Parse(string filepath, int segmentSize = 16)
        {
            int i = 0;
            char[] line;
            string res = string.Format("{0:x10}", i) + "  ";
            byte[] data = File.ReadAllBytes(filepath);

            for (i = 0; i < data.Length; i += segmentSize) {
                Console.Write("{0:x10}  ", i);
                line = new char[segmentSize];

                for (int j = 0; j < segmentSize / 2; ++j) {
                    byte byt = data[i + j];
                    line[j] = (char)byt;

                    if (data[i + j] == 0) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("{0:x2} ", byt);
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0:x2} ", byt);
                    }

                    Console.ResetColor();
                }
                Console.Write(" ");
                for (int j = segmentSize / 2; j < segmentSize; ++j) {
                    byte byt = data[i + j];
                    line[j] = (char)byt;

                    if (data[i + j] == 0) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("{0:x2} ", byt);
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0:x2} ", byt);
                    }

                    Console.ResetColor();
                }

                Console.Write(" ");
                foreach (var ch in line) {
                    if (ch == (char)0) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (char.IsControl(ch)) {
                        Console.Write(". ");
                    } else {
                        Console.Write(ch + " ");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
