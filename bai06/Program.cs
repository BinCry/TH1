using System;
using System.Collections.Generic;

namespace Bai06
{
    internal class Program
    {
        class MaTran
        {
            public int Row { get; private set; }
            public int Col { get; private set; }
            private List<List<int>> A = new List<List<int>>();

            public void Create()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                Row = NhapSoDuong("Nhập số dòng n: ");
                Col = NhapSoDuong("Nhập số cột m: ");

                var rnd = new Random();
                A.Clear();
                for (int i = 0; i < Row; i++)
                {
                    var row = new List<int>(Col);
                    for (int j = 0; j < Col; j++)
                        row.Add(rnd.Next(0, 101)); // 0..100
                    A.Add(row);
                }
            }

            // a) Xuất ma trận
            public void Print(string title = "Ma trận")
            {
                Console.WriteLine($"\n{title} (kích thước {Row} x {Col}):");
                if (Row == 0 || Col == 0)
                {
                    Console.WriteLine("(trống)");
                    return;
                }

                int width = 3;
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                    {
                        int len = A[i][j].ToString().Length;
                        if (len > width) width = len;
                    }

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                        Console.Write(A[i][j].ToString().PadLeft(width) + " ");
                    Console.WriteLine();
                }
            }

            // b) Lớn nhất / Nhỏ nhất
            public int MaxElement()
            {
                int mx = A[0][0];
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                        if (A[i][j] > mx) mx = A[i][j];
                return mx;
            }
            public int MinElement()
            {
                int mn = A[0][0];
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                        if (A[i][j] < mn) mn = A[i][j];
                return mn;
            }

            // c) Dòng có tổng lớn nhất
            public int RowWithMaxSum(out long maxSum)
            {
                int idx = 0;
                maxSum = long.MinValue;

                for (int i = 0; i < Row; i++)
                {
                    long sum = 0;
                    for (int j = 0; j < Col; j++)
                        sum += A[i][j];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        idx = i;
                    }
                }
                return idx; // 0-based
            }

            // d) Tổng các số KHÔNG phải số nguyên tố
            public long SumOfNonPrimes()
            {
                long sum = 0;
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                        if (!IsPrime(A[i][j])) sum += A[i][j];
                return sum;
            }

            // e) Xóa dòng thứ k (người dùng nhập 1-based)
            public void DeleteRow1Based(int k1)
            {
                if (Row == 0) return;
                int k = k1 - 1;
                if (k < 0 || k >= Row)
                {
                    Console.WriteLine("Chỉ số dòng không hợp lệ!");
                    return;
                }
                A.RemoveAt(k);
                Row--;
            }

            // f) Xóa cột chứa phần tử lớn nhất (xóa TẤT CẢ các cột có chứa max)
            public void DeleteColumnsContainMax()
            {
                if (Row == 0 || Col == 0) return;
                int mx = MaxElement();

                // Đánh dấu cột cần xóa
                bool[] mark = new bool[Col];
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                        if (A[i][j] == mx) mark[j] = true;

                // Xóa từ phải qua trái
                for (int c = Col - 1; c >= 0; c--)
                {
                    if (!mark[c]) continue;
                    for (int i = 0; i < Row; i++)
                        A[i].RemoveAt(c);
                    Col--;
                }
            }

            // --- Helpers ---
            private static int NhapSoDuong(string prompt)
            {
                int n;
                while (true)
                {
                    Console.Write(prompt);
                    if (!int.TryParse(Console.ReadLine(), out n))
                    {
                        Console.WriteLine("Vui lòng nhập số nguyên hợp lệ!");
                        continue;
                    }
                    if (n <= 0)
                    {
                        Console.WriteLine("Số phải > 0!");
                        continue;
                    }
                    return n;
                }
            }

            private static bool IsPrime(int n)
            {
                if (n < 2) return false;
                if (n % 2 == 0) return n == 2;
                for (int i = 3; i * i <= n; i += 2)
                    if (n % i == 0) return false;
                return true;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var mt = new MaTran();
            mt.Create();
            mt.Print("Ma trận ban đầu");

            Console.WriteLine($"\nPhần tử lớn nhất: {mt.MaxElement()}");
            Console.WriteLine($"Phần tử nhỏ nhất: {mt.MinElement()}");

            long maxSum;
            int idx = mt.RowWithMaxSum(out maxSum);
            Console.WriteLine($"Dòng có tổng lớn nhất: dòng {idx + 1} (tổng = {maxSum})");

            Console.WriteLine($"Tổng các số KHÔNG phải số nguyên tố: {mt.SumOfNonPrimes()}");

            int k;
            while (true)
            {
                Console.Write("\nNhập k (dòng muốn xóa, 1..n): ");
                if (!int.TryParse(Console.ReadLine(), out k))
                {
                    Console.WriteLine("Vui lòng nhập số nguyên hợp lệ!");
                    continue;
                }
                if (k < 1 || k > mt.Row)
                {
                    Console.WriteLine($"k phải trong [1..{mt.Row}]!");
                    continue;
                }
                break;
            }
            mt.DeleteRow1Based(k);
            mt.Print($"Ma trận sau khi xóa dòng {k}");

            Console.WriteLine("\nXóa tất cả cột có chứa phần tử lớn nhất...");
            mt.DeleteColumnsContainMax();
            mt.Print("Ma trận sau khi xóa cột chứa phần tử lớn nhất");

            Console.WriteLine("\nHoàn thành.");
        }
    }
}
