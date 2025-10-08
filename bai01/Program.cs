using System;

class Program
{
    static bool LaSoNguyenTo(int n)
    {
        if (n < 2) return false;
        if (n % 2 == 0) return n == 2;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    static bool LaSoChinhPhuong(int n)
    {
        if (n < 0) return false;
        int r = (int)Math.Sqrt(n);
        return r * r == n;
    }

    static int NhapSoDuong(string prompt)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int n;
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (!int.TryParse(s, out n))
            {
                Console.WriteLine("Vui lòng nhập số nguyên hợp lệ!");
                continue;
            }
            if (n <= 0)
            {
                Console.WriteLine("Số phải lớn hơn 0!");
                continue;
            }
            return n;
        }
    }

    static void Main()
    {
        int n = NhapSoDuong("Nhập số lượng phần tử của mảng (n): ");

        const int MIN = 0, MAX = 100;
        var rand = new Random();
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
            a[i] = rand.Next(MIN, MAX + 1);

        Console.WriteLine("\nMảng ngẫu nhiên:");
        Console.WriteLine(string.Join(" ", a));

        long tongLe = 0;
        int demNguyenTo = 0;
        int minChinhPhuong = -1;

        foreach (int x in a)
        {
            if (x % 2 != 0) tongLe += x;
            if (LaSoNguyenTo(x)) demNguyenTo++;
            if (LaSoChinhPhuong(x))
            {
                if (minChinhPhuong == -1 || x < minChinhPhuong)
                    minChinhPhuong = x;
            }
        }

        Console.WriteLine($"\nTổng các số lẻ: {tongLe}");
        Console.WriteLine($"Số lượng số nguyên tố: {demNguyenTo}");
        Console.WriteLine($"Số chính phương nhỏ nhất: {minChinhPhuong}");
    }
}

