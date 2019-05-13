using System;
using System.Numerics;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projekt_2
{
    class Program
    {
        static BigInteger operation = 0; //zmienna ktora zlicza wiodące operacje
        static bool IsPrime(BigInteger Num)//metoda sprawdzająca bez instrumentacji
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)

                    if (Num % u == 0) return false;
            return true;
        }
        static bool IsPrime2(BigInteger Num)//metoda sprawdzająca z instrumentacją
        {
            if (Num < 2)
            {
                return false;
            }
            else if (Num < 4)
            {
                return true;
            }
            else if (Num % 2 == 0)
            {
                ++operation;
                return false;
            }
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    ++operation;
                    if (Num % u == 0)
                    {
                        
                        return false;
                    }
                }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("L.p.;Checked Number;Time elapsed (s);result");
            BigInteger[] tab = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };//Sprawdzane liczby, zgodne z założeniem projektu.
            int lp = 1;
            for (int i = 0; i < tab.Length; i++)
            {
                IsPrime2(tab[i]);//zaimplementowana tablica do metody z instrumentacją
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();//stoper start
                IsPrime(tab[i]);//zaimplementowana tablica do metody
                stopwatch.Stop();//stoper stop
                Console.WriteLine(lp + ";" + tab[i] + ";" + stopwatch.Elapsed.TotalSeconds.ToString("F5") + ";" + operation);
                operation = 0;
                lp++;
            }
        }
    }
}
