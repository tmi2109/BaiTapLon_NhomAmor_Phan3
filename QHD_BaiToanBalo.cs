using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanBalo
{
    class QHD_BaiToanBalo
    {
        static void Main()
        {
            int n;
            int[] val;
            int[] wt;
            int W;

            Console.Write("Nhap so do vat: ");
            n = int.Parse(Console.ReadLine());

            val = new int[n];
            wt = new int[n];

            Console.WriteLine("Nhap gia tri va trong luong do vat:");
            for (int i = 0; i < n; ++i)
            {
                string[] input = Console.ReadLine().Split(' ');
                val[i] = int.Parse(input[0]);
                wt[i] = int.Parse(input[1]);
            }

            Console.Write("Nhap kich thuoc cua balo: ");
            W = int.Parse(Console.ReadLine());

            Console.WriteLine("Cac vat pham duoc chon:");
            int result = KnapSack(W, wt, val, n);
            Console.WriteLine("Gia tri lon nhat co the bo vao balo: " + result);
            
            Console.ReadKey();
        }

        static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        static int KnapSack(int W, int[] wt, int[] val, int n)
        {
            int[,] K = new int[n + 1, W + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (wt[i - 1] <= w)
                    {
                        K[i, w] = Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }
            int remainingCapacity = W;
            for (int i = n; i > 0; i--)
            {
                if (K[i, remainingCapacity] != K[i - 1, remainingCapacity])
                {
                    Console.WriteLine($"Vat pham {i}: Gia tri = {val[i - 1]}, Trong luong = {wt[i - 1]}");
                    remainingCapacity -= wt[i - 1];
                }
            }
            return K[n, W];
        }

    }
}
