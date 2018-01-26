using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Csd.Calculator.Token;
using Csd.Calculator.Token.Operator;

namespace Csd.Calculator
{
    public class RPNCalculator
    {
        private readonly TextWriter _output;
        private Stack<CalculatorToken> _stack = new Stack<CalculatorToken>();

        public static void Main(String[] args)
        {
            var calc = new RPNCalculator();
            calc.WriteLine("Enter values followed by operation symbols: ");
            calc.Run(System.Console.In);
            
        }

        public RPNCalculator()
        {
            this._output = System.Console.Out;
        }
        public RPNCalculator(TextWriter output)
        {
            this._output = output;
        }

        public void WriteLine(String msg)
        {
            _output.WriteLine(msg);
        }

        public void Run(TextReader inputStream)
        {
            var tokenInput = new StreamTokenizer(inputStream);
            while (true)
            {
                ProcessInput(tokenInput);
            }

        }

        public void ProcessInput(StreamTokenizer tokenInput)
        {
            while (tokenInput.TokenAvailable())
            {
                _stack.Push(CreateToken(tokenInput.NextToken()));
                if (_stack.Peek().IsOperator())
                {
                    WriteStackToOutput(_stack);
                    OperatorToken opToken = (OperatorToken)_stack.Pop();
                    try
                    {
                        opToken.Execute(_stack);
                    }
                    catch (ArgumentException e)
                    {
                        _output.WriteLine(e.Message);
                    }
                }

               WriteStackToOutput(_stack);
            }
        }

        private CalculatorToken CreateToken(string symbol)
        {
            if (OperatorToken.IsValidOperatorSymbol(symbol))
            {
               return OperatorToken.CreateOperatorToken(symbol);
            }
            return new OperandToken(symbol);
        }

        private void WriteStackToOutput(Stack<CalculatorToken> stack)
        {

            if (stack.Count <= 0)
            {
                return;
            }
            Stack<CalculatorToken> tmp = new Stack<CalculatorToken>(stack);
            StringBuilder str = new StringBuilder();

            str.Append("[");
            while (tmp.Count > 0)
            {
                str.Append(tmp.Pop());
                if (tmp.Count > 0)
                {
                    str.Append(", ");
                }
            }

            str.Append("]");

            _output.WriteLine(str.ToString());
            _output.Flush();
        }
       
    }
}
