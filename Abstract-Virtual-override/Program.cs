using System;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new Operation(
                new VariableRefrence("x")
                , '-', 
               new Operation
               (
                   new VariableRefrence("y"),
                   '*',
                   new Constants(3)
                   )
               );
            Dictionary<string, object> vars = new();
            vars.Add("x", 4);
            vars.Add("y", 1);
            Console.WriteLine(e.Evaluate(vars));
        }
    }

    abstract class Expression
    {
        public abstract double Evaluate(Dictionary<string, object> vars);
    }

    class Constants : Expression
    {
        int _value;

        public Constants(int value)
        {
            _value = value;
        }
        public override double Evaluate(Dictionary<string , object> vars)
        {
            return _value;
        }
    }

    class VariableRefrence : Expression
    {
        string _name;

        public VariableRefrence(string name)
        {
            _name = name;
        }

        public override double Evaluate(Dictionary<string, object> vars)
        {
            object value = vars[_name] ?? throw new Exception($"{_name} does not have a value");
            return Convert.ToDouble(value);
        }
    }

    class Operation : Expression
    {
        Expression _left;
        char _op;
        Expression _right;

        public Operation(Expression left , char op , Expression right)
        {
            _left = left;
            _op = op;
            _right = right;
        }

        public override double Evaluate(Dictionary<string , object> vars)
        {
            double x = _left.Evaluate(vars);
            double y = _right.Evaluate(vars);

            switch (_op)
            {
                case '+':
                    return x + y;
                case '-':
                    return x - y;
                case '/':
                    return x / y;
                case '*':
                    return x * y;
                default:
                    throw new Exception("Operation is not Valid");
            }
        }
    }
}