using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brainfuckCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length!=2)
            {
                Console.WriteLine("usage: brainfuckCompiler.exe <filename_with_bf> <output_filename>");
                Console.ReadLine();
                return;
            }
            StreamReader bfCodeReader = new StreamReader(args[0]);
            string bfCode = bfCodeReader.ReadToEnd();
            bfCodeReader.Close();
            BinaryWriter outputWriter = new BinaryWriter(File.OpenWrite(args[1]));
            outputWriter.Write(1);
            outputWriter.Write(1);
            outputWriter.Write(0);
            outputWriter.Write(0xb0);
            outputWriter.Write(0);
            outputWriter.Write(0);

            outputWriter.Write(1);
            outputWriter.Write(2);
            outputWriter.Write(1);
            outputWriter.Write(0);
            outputWriter.Write(0);
            outputWriter.Write(0);

            outputWriter.Write(1);
            outputWriter.Write(3);
            outputWriter.Write(0);
            outputWriter.Write(0);
            outputWriter.Write(0);
            outputWriter.Write(0);
            for (int i = 0; i < bfCode.Length; i++)
            {
                switch (bfCode[i])
                {
                    case '+':
                        outputWriter.Write(4);
                        outputWriter.Write(6);
                        outputWriter.Write(1);
                        outputWriter.Write(10);
                        outputWriter.Write(6);
                        outputWriter.Write(2);
                        outputWriter.Write(5);
                        outputWriter.Write(1);
                        outputWriter.Write(6);
                        break;
                    case '-':
                        outputWriter.Write(4);
                        outputWriter.Write(6);
                        outputWriter.Write(1);
                        outputWriter.Write(11);
                        outputWriter.Write(6);
                        outputWriter.Write(2);
                        outputWriter.Write(5);
                        outputWriter.Write(1);
                        outputWriter.Write(6);
                        break;
                    case '>':
                        outputWriter.Write(10);
                        outputWriter.Write(1);
                        outputWriter.Write(2);
                        break;
                    case '<':
                        outputWriter.Write(11);
                        outputWriter.Write(1);
                        outputWriter.Write(2);
                        break;
                    case '.':
                        outputWriter.Write(4);
                        outputWriter.Write(6);
                        outputWriter.Write(1);
                        outputWriter.Write(0xf2);
                        outputWriter.Write(6);
                        outputWriter.Write(0x20);
                        break;
                    case ']':
                        outputWriter.Write(0x31);
                        outputWriter.Write(0);
                        break;
                    case '[':

                        break;
                }
            }
            outputWriter.Close();
            Console.Write("Press enter to close");
            Console.ReadLine();
        }
    }
}
