using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongDiNguoiGiaoHang
{
    class QHD_DuongDiNguoiGiaoHang
    {
        static int[,] matrix;
        static int n;
        static int[,] dp;

        static void Main()
        {
            TravellingSalesmanProblem();
            PrintMatrix();
            int result = ChiPhiToiThieu(1, 0);
            Console.WriteLine("\n\nChi phi toi thieu: {0}", result);
            Console.ReadKey();
        }

        static void TravellingSalesmanProblem()
        {
            Console.Write("Nhap so thanh pho: ");
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            dp = new int[n, (1 << n) - 1];

            Console.WriteLine("\nNhap ma tran:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap {0} phan tu dong [{1}]:", n, i + 1);
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (1 << n) - 1; j++)
                {
                    dp[i, j] = -1;
                }
            }
        }

        static void PrintMatrix()
        {
            Console.WriteLine("\nMa tran khoang cach:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static int ChiPhiToiThieu(int mask, int pos)
        {
            if (mask == (1 << n) - 1)
            {
                return matrix[pos, 0];
            }

            if (dp[pos, mask] != -1)
            {
                return dp[pos, mask];
            }

            int ans = int.MaxValue;

            for (int city = 0; city < n; city++)
            {
                if ((mask & (1 << city)) == 0)
                {
                    int newAns = matrix[pos, city] + ChiPhiToiThieu(mask | (1 << city), city);
                    ans = Math.Min(ans, newAns);
                }
            }

            return dp[pos, mask] = ans;
        }
    }
}
