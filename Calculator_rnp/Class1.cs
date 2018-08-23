using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_rnp
{
    class Class1
    {
        static public double Calculate(string input)
        {
            try { return double.Parse(GetExpression(input)); }
            catch (Exception) { return Counting(GetExpression(input)); }

        }

        static private string GetExpression(string input)
        {
            string output = string.Empty;
            string funcc = string.Empty;
            Stack<char> operStack = new Stack<char>();
            char k = ' '; string p = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (CheckOper(input[i]) || Char.IsDigit(input[i]))
                {
                    if (k == ' ')
                        k = input[i];
                    else
                    if (input[i] == '-' && !Char.IsDigit(k))
                        p += " 0 ";
                    k = input[i];
                }
                p += input[i];
            }
            input = p;
            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                    continue;
                if (Char.IsDigit(input[i]))
                {
                    while (!IsDelimeter(input[i]) && !CheckOper(input[i]))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    output += " ";
                    i--;
                }
                else
                    if (CheckOper(input[i]))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = operStack.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (DeterminePriority(input[i]) <= DeterminePriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";

                        operStack.Push(char.Parse(input[i].ToString()));

                    }
                }
                else if (input[i] == '\u03C0')
                    output += " \u03C0 ";
                else if (input[i] == 'e')
                    output += " e ";
                else
                {
                    funcc = String.Empty;
                    while (input[i] != '(')
                    {
                        funcc += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    i++;
                    if (CheckFunc(funcc))
                    {
                        String param = String.Empty;
                        while (input[i] != ')')
                        {
                            param += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        double d;
                        try { d = double.Parse(param); }
                        catch (Exception) { d = Counting(GetExpression(param)); }
                        output += Funcc(funcc, d);
                    }
                }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
            }


        static private bool CheckOper(char с)
        {
            if (("+-/*^()PC!%".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private byte DeterminePriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '!': return 4;
                case '%': return 4;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 4;
            }
        }
        static private double Counting(string input)
        {
            double result = 0;
            double b = 0;
            Stack<double> temp = new Stack<double>();
            try { return double.Parse(input); }
            catch (Exception)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]))
                    {
                        string a = string.Empty;

                        while (!IsDelimeter(input[i]) && !CheckOper(input[i]))
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        temp.Push(double.Parse(a));
                        i--;
                    }
                    else if (input[i] == '\u03C0')
                        temp.Push(Math.PI);
                    else if (input[i] == 'e')
                        temp.Push(Math.E);
                    else if (CheckOper(input[i]))
                    {
                        double a = temp.Pop();
                        try
                        { b = temp.Pop(); }
                        catch (Exception) { b = 0; }

                        switch (input[i])
                        {
                            case '!': result = Factorial((int)a); break;
                            case 'P': result = Factorial((int)b) / Factorial((int)(b - a)); break;
                            case 'C': result = Factorial((int)b) / (Factorial((int)a) * Factorial((int)(b - a))); break;
                            case '^': result = Math.Pow(b, a); break;
                            case '%': result = b % a; break;
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '/': result = b / a; break;
                        }
                        temp.Push(result);
                    }
                }
                try { return temp.Peek(); }
                catch (Exception) { throw new SyntaxException(); }

            }

        }
        static private bool CheckFunc(String s)
        {
            String[] func = { "sin", "cos", "tg", "asin", "acos", "atg", "sqrt", "ln", "lg" };
            if (Array.Exists(func, e => e == s))
                return true;
            return false;
        }
        private static int Factorial(int x)
        {
            int i = 1;
            for (int s = 1; s <= x; s++)
                i = i * s;
            if (x < 0) throw new NegativeFactorialException(x);
            return i;
        }
        static private String Funcc(String fun, double param)
        {
            switch (fun)
            {
                case "cos": return Math.Cos(param).ToString();
                case "sin": return Math.Sin(param).ToString();
                case "tg": if (Math.Abs(param % (2 * Math.PI)) == (Math.PI / 2)) throw new TgException(param); else return Math.Tan(param).ToString();
                case "asin": if (param < -1 || param > 1) throw new ArcSinCosException(param); else return Math.Asin(param).ToString();
                case "acos": if (param < -1 || param > 1) throw new ArcSinCosException(param); else return Math.Acos(param).ToString();
                case "atg": return Math.Atan(param).ToString();
                case "sqrt": if (param < 0) throw new SqrtException(param); else return Math.Sqrt(param).ToString();
                case "ln": if (param <= 0) throw new LogException(param); else return Math.Log(param).ToString();
                case "lg": if (param <= 0) throw new LogException(param); else return Math.Log10(param).ToString();
                default: return "";
            }
        }

    }
    public class MyException : Exception
    {
        public string type;
    }
    public class NegativeFactorialException : MyException
    {
        public NegativeFactorialException(int x)
        {
            this.type = "Math error";
            MessageBox.Show("Factorial(" + x + ") does not exsists", type, MessageBoxButtons.OK);
        }
    }
    public class TgException : MyException
    {
        public TgException(double x)
        {
            this.type = "Math error";
            MessageBox.Show("Tg(" + x + ") does not exsists", type, MessageBoxButtons.OK);
        }
    }
    public class SqrtException : MyException
    {
        public SqrtException(double x)
        {
            this.type = "Math error";
            MessageBox.Show("Sqrt(" + x + ") does not exsists", type, MessageBoxButtons.OK);
        }
    }
    public class DividedByZeroException : MyException
    {
        public DividedByZeroException()
        {
            this.type = "Math error";
            MessageBox.Show("Division by zero is impossible", type, MessageBoxButtons.OK);
        }
    }
    public class LogException : MyException
    {
        public LogException(double x)
        {
            this.type = "Math error";
            MessageBox.Show("Log(" + x + ") does not exsists", type, MessageBoxButtons.OK);
        }
    }
    public class SyntaxException : MyException
    {
        public SyntaxException()
        {
            this.type = "Syntax error";
            MessageBox.Show("You made a mistake", type, MessageBoxButtons.OK);
        }
    }
    public class ArcSinCosException : MyException
    {
        public ArcSinCosException(double x)
        {
            this.type = "Math error";
            MessageBox.Show("Acos(or Asin) (" + x + ") does not exsists", type, MessageBoxButtons.OK);
        }
    }
}