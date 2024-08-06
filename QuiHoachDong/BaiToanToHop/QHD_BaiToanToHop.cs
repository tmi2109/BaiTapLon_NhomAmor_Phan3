using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanToHop
{
    class QHD_BaiToanToHop
    {
        static void Main()
        {
            Nhap(out int n, out int k);
            Xuat(n, k);
            Console.ReadKey();
        }
        static void Nhap(out int n, out int k)
        {
            Console.Write("Nhap n va k: ");
            var input = Console.ReadLine().Split();
            n = int.Parse(input[0]);
            k = int.Parse(input[1]);
        }

        static int TinhToHop_DP(int n, int k)
        {
            int[,] C = new int[n + 1, k + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= Math.Min(i, k); j++)
                {
                    if (j == 0 || j == i)
                    {
                        C[i, j] = 1;
                    }
                    else
                    {
                        C[i, j] = C[i - 1, j - 1] + C[i - 1, j];
                    }
                }
            }

            return C[n, k];
        }

        static void Xuat(int n, int k)
        {
            int kq = TinhToHop_DP(n, k);
            Console.WriteLine($"C[{n}][{k}] = {kq}");
        }

        
    }
}
