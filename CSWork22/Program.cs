using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSWork22;

internal class Program
{
    private static string[] testStrings = new string[]
    {
        "",
        "0",
        "1",
        "999999999999999999999999999",
        "-999999999999999999999999999",
        "-0",
        "+123",
        "-123",
        "123",
        "afsda21123",
        "0OO",
        "1.234",
        "-1.234",
        "-1,234",
        "1,234",
        "1,234.324,213,3",
        "23,431,234.324,213,3",
        ",431,234.324,213,3",
        ",431,234.324,213,",
        "431,234.324,213,",
        "23`431`234.324`21",
        "`431`234.324`21",
        "`431`234.324`",
        "431`234.324`",
        "431.234.324`",
        "431.234,324.324`",
        "431.234`324.324`"
    };

    static void Main(string[] args)
    {
        test1();
        
        Console.ReadKey();
    }

    static private void showString(string value) => Console.Write($"{value,40}");
    static private void showString(int value) => showString(value.ToString());
    static private void showString(double value) => showString(value.ToString());

    static private void test1()
    {
        StringToDouble converter = new StringToDouble();
        foreach (string testString in testStrings)
        {
            Console.Write($"{testString, 30} >> ");
            try
            {
                double myd = converter.Convert(testString);
                showString(myd);
            }
            catch (Exception ex)
            {
                showString(ex.Message);
            }

            try
            {
                double standart = double.Parse(testString);
                showString(standart);
            }
            catch (Exception ex)
            {
                showString(ex.Message);
            }

            Console.WriteLine();
        }
    }
}
