using System;

public class Program
{
    public static void Main(string[] args)
    {
        int year = validYear();
        int month = validMonth();
        int day = GetValidDay(year, month);

        DateTime currentDate = DateTime.Now;
        DateTime birthDate = new DateTime(year, month, day);

        TimeSpan ageSpan = currentDate - birthDate;

        int ageYears = (int)(ageSpan.Days / 365.25);
        int remainingDays = ageSpan.Days % 365;
        int ageMonths = remainingDays / 30;
        int ageDays = remainingDays % 30;

        Console.WriteLine($"You are {ageYears} years, {ageMonths} months, and {ageDays} days old.");
    }

    public static int validYear()
    {
        int year;
        do
        {
            Console.WriteLine("Enter the year between 1980 and 2023");
            year = int.Parse(Console.ReadLine());
        } while (year < 1980 || year > 2023);
        return year;
    }

    public static int validMonth()
    {
        int month;
        do
        {
            Console.WriteLine("Enter the month from 1 to 12");
            month = int.Parse(Console.ReadLine());
        } while (month < 1 || month > 12);
        return month;
    }

    static int GetValidDay(int year, int month)
    {
        int day;
        int maxDays = GetDaysInMonth(year, month);

        do
        {
            Console.Write($"Enter your birth day (1-{maxDays}): ");
            day = Convert.ToInt32(Console.ReadLine());
        } while (day < 1 || day > maxDays);

        return day;
    }

    static int GetDaysInMonth(int year, int month)
    {
        if (month == 2)
        {
            if (DateTime.IsLeapYear(year))
            {
                return 29;
            }
            return 28;
        }
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            return 31;
        }
        return 30;
    }
}
