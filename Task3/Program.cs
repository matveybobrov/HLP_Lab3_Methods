using System;

public class Program
{
    public static string Check(string str)
    {
        char prev = ' ';
        int i = 0;
        foreach (char c in str)
        {
            i++;
            // Если перед открывающей была другая открывающая
            if (c == '(' && c == prev)
            {
                return ($"Лишняя открывающая скобка на позиции {i} ");
            }
            // Если перед закрывающей не было открывающей
            if (c == ')' && prev != '(')
            {
                return ($"Лишняя закрывающая скобка на позиции {i} ");
            }

            if (c == ')' || c == '(')
            {
                prev = c;
            }
        }
        // Если заканчиваем открывающей скобкой
        if (prev == '(') return $"Лишняя открывающая скобка на позиции {str.Length}";

        return "Скобки расставлены правильно";
    }

    public static void Main()
    {
        Console.WriteLine("Введите строку со скобками:");
        string str = Console.ReadLine();
        Console.WriteLine(Check(str));
    }
}