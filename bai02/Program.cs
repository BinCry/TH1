using System;

class Program
{
    // Hàm kiểm tra số nguyên tố
    static bool LaSoNguyenTo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int n;

        // Nhập n và kiểm tra hợp lệ
        while (true)
        {
            Console.Write("Nhập số nguyên dương n: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ!");
                continue;
            }

            if (n <= 0)
            {
                Console.WriteLine("Số phải lớn hơn 0!");
                continue;
            }

            break; // nhập đúng thì thoát vòng lặp
        }

        // Tính tổng các số nguyên tố < n
        int tong = 0;
        for (int i = 2; i < n; i++)
        {
            if (LaSoNguyenTo(i))
                tong += i;
        }

        // Xuất kết quả
        Console.WriteLine($"\nTổng các số nguyên tố < {n} là: {tong}");
    }
}
