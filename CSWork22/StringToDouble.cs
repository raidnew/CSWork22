using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSWork22;

public class StringToDouble
{
    public double Convert(string doubleString)
    {
        string checkPattern = @"^[+-]?[0-9]+([.,]{1}[0-9]+)?$";
        bool isMatch = Regex.IsMatch(doubleString, checkPattern);
        if (!isMatch) throw new FormatException("Can`t format string to double");

        string parsePattern = @"^(?<sign>[+-]?)(?<integer>[0-9]+)([.,]{1}(?<fractal>[0-9]+))?$";
        Match match = Regex.Match(doubleString, parsePattern);

        bool isPositive = !(match.Groups["sign"].Value == "-");
        string integerPart = match.Groups["integer"].Value;
        string fractalPart = match.Groups["fractal"].Value;

        int i;
        double result = 0, miltiplier;

        int CharToInt(char letter) => letter - '0';

        for (i = (integerPart.Length - 1), miltiplier = 1; i >= 0; i--, miltiplier *= 10)
            result += CharToInt(integerPart[i]) * miltiplier;

        for (i = 0, miltiplier = 0.1; i < fractalPart.Length; i++, miltiplier /= 10)
            result += CharToInt(fractalPart[i]) * miltiplier;

        return isPositive ? result : -result;
    }

}
