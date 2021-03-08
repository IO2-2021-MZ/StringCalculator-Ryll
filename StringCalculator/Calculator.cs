using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private static string[] separators = new string[]
        {
            ",",
            "\n",
            ";"
        };

        public int Add(string input)
        {
            string[] usedSeparators = separators;
            string validInput = input;

            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.Length > 2)
                if (input[0] == '/' && input[1] == '/')
                {
                    int index = input.IndexOf('\n');
                    validInput = input.Substring(index + 1);
                    if (input[2] == '[')
                    {
                        string[] declaredSeparatos = input.Split('[',']');
                        List<string> readSeparators = new List<string>();
                        for (int i = 1; i < declaredSeparatos.Length; i++)
                            if (string.IsNullOrEmpty(declaredSeparatos[i]))
                                continue;
                            else if (declaredSeparatos[i][0] == '\n')
                                break;
                            else
                                readSeparators.Add(declaredSeparatos[i]);
                        usedSeparators = readSeparators.ToArray();
                    }
                    else if (input[3] == '\n')
                    {
                        usedSeparators = new string[] { input[2].ToString() };
                    }
                }

            string[] values = validInput.Split(usedSeparators, StringSplitOptions.None);
            int firstValue = int.Parse(values[0]);
            int value = firstValue > 1000 ? 0 : firstValue;
            if (value < 0) throw new Exception();
            for (int i = 1; i < values.Length; i++)
            {
                int newValue = int.Parse(values[i]);
                if (newValue < 0) throw new Exception();
                value += newValue > 1000 ? 0 : newValue;
            }

            return value;
        }
    }
}
