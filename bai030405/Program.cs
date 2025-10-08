using System;

class Program
{
    static bool LaNamNhuan(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    static int SoNgayTrongThang(int month, int year)
    {
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                return LaNamNhuan(year) ? 29 : 28;
            default:
                return -1;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int day = 0, month = 0, year = 0;
        bool validDay = false, validMonth = false, validYear = false;

        // Nhập ngày
        while (!validDay)
        {
            Console.Write("Nhập ngày: ");
            if (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
                Console.WriteLine("Ngày không hợp lệ (1–31), vui lòng nhập lại!");
            else
                validDay = true;
        }

        // Nhập tháng
        while (!validMonth)
        {
            Console.Write("Nhập tháng: ");
            if (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
                Console.WriteLine("Tháng không hợp lệ (1–12), vui lòng nhập lại!");
            else
                validMonth = true;
        }

        // Nhập năm
        while (!validYear)
        {
            Console.Write("Nhập năm: ");
            if (!int.TryParse(Console.ReadLine(), out year) || year < 1)
                Console.WriteLine("Năm không hợp lệ, vui lòng nhập lại!");
            else
                validYear = true;
        }

        // Kiểm tra số ngày thực tế trong tháng
        int soNgay = SoNgayTrongThang(month, year);
        while (day > soNgay)
        {
            Console.WriteLine($"Tháng {month} năm {year} chỉ có {soNgay} ngày. Vui lòng nhập lại ngày!");
            Console.Write("Nhập ngày: ");
            int.TryParse(Console.ReadLine(), out day);
        }

        // Kết quả hợp lệ
        Console.WriteLine($"\nNgày bạn nhập: {day}/{month}/{year}");
        Console.WriteLine("Ngày tháng năm hợp lệ!");

        // In số ngày của tháng đó
        Console.WriteLine($"Tháng {month} năm {year} có {soNgay} ngày.");

        // Tính thứ trong tuần
        DateTime dt = new DateTime(year, month, day);
        string[] thuVN = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
        Console.WriteLine($"Ngày {day}/{month}/{year} là {thuVN[(int)dt.DayOfWeek]}.");
    }
}
