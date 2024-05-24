using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasuryChallenge.Old
{
  public class CodeGenerate
    {
        private static Hashtable _caracteresUtilizados = new Hashtable();
        private static Hashtable _codigoGerado = new Hashtable();

        internal static void Generate()
        {
            Console.WriteLine("Tell me the number of lines do you need and press enter.");


            int l = int.Parse(Console.ReadLine());

            var t = Stopwatch.StartNew();

            Write(l);

            t.Stop();

            System.Console.WriteLine(t.ElapsedMilliseconds);
        }

        static string GetChar()
        {
            Random random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

            return chars[random.Next(26)].ToString();
        }

        static void Write(int quantidadeCodigosSolicitado)
        {
            using (StreamWriter writer = new StreamWriter("aleatory-file.txt"))
            {
                for (int i = 0; i < quantidadeCodigosSolicitado; i++)
                {
                    var codigo = string.Empty;
                    Console.WriteLine($"Linha: {i}");
                    do
                    {
                        codigo = GetLine();

                    } while (_codigoGerado.ContainsKey(codigo));

                    _codigoGerado.Add(codigo, codigo);

                    writer.WriteLine(codigo);
                }

                _codigoGerado.Clear();
            }



            System.Console.WriteLine($"A file with {quantidadeCodigosSolicitado} lines was generated.");

        }

        public static string GetLine(string linha = "")
        {
            if (linha.Length == 7)
            {
                _caracteresUtilizados.Clear();
                return linha;
            }
            var caractere = string.Empty;

            do
            {
                caractere = GetChar();

            } while (_caracteresUtilizados.ContainsKey(caractere));

            _caracteresUtilizados.Add(caractere, linha);

            return GetLine(string.Concat(linha, caractere));

        }

    }
}

