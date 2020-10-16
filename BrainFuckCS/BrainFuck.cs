using System;

namespace BrainFuckCS
{
    public class BrainFuck
    {
        public static int MaxMem = 3000;
        public static string Interpret(string s)
        {
            char c;
            string output = "";
            int mempos = 0, currentpos = 0;
            char[] memory = new char[MaxMem + 1];
            char[] code = s.ToCharArray();
            while (currentpos < code.Length)
            {
                c = code[currentpos];
                if (c == '>') mempos++;
                else if (c == '<' && mempos != 0) mempos--;
                else if (c == '.') output += memory[mempos];
                else if (c == ',') memory[mempos] = Console.ReadLine().ToCharArray()[0];
                else if (c == '+' && memory[mempos] != 255) memory[mempos]++;
                else if (c == '+' && memory[mempos] == 255) memory[mempos] = (char)0;
                else if (c == '-' && memory[mempos] != 0) memory[mempos]--;
                else if (c == '-' && memory[mempos] == 0) memory[mempos] = (char)255;
                else if (c == '[' && memory[mempos] == 0)
                {
                    int open = 1;
                    while (open != 0 && currentpos <= code.Length)
                    {
                        currentpos++;
                        if (code[currentpos] == '[') open++;
                        if (code[currentpos] == ']') open--;

                    }
                }
                else if (c == ']' && memory[mempos] != 0)
                {
                    int close = 1;
                    while (close != 0 && currentpos >= 0)
                    {
                        currentpos--;
                        if (code[currentpos] == ']') close++;
                        if (code[currentpos] == '[') close--;
                    }
                }
                currentpos++;
            }
            return (output);
        }
    }
}
