using System;
using System.Collections.Generic;

namespace Csd.Calculator.Token.Operator
{
    public abstract class OperatorToken : CalculatorToken
    {
        public const string OPERATOR_REQUIRES_TWO_OPERANDS = "operation requires 2 operands";
        private static readonly List<string> OperatorSymbols = new List<string>(new string[] { "+", "-", "*", "/" });

        public OperatorToken(string symbol): base(symbol)
        {
           
        }

        public abstract CalculatorToken Execute(Stack<CalculatorToken> stack);
        public static bool IsValidOperatorSymbol(string symbol)
        {
            return OperatorSymbols.Contains(symbol);
        }

        public sealed override bool IsOperator()
        {
            return true;
        }

        public static OperatorToken CreateOperatorToken(string operatorSymbol)
        {
            switch (operatorSymbol[0])
            {
                case '+':
                    return new AdditionOperatorToken();

                case '-':
                    return new SubtractionOperatorToken();
                    
                case '*':
                    return new MultiplicationOperatorToken();
                    
                case '/':
                    return new DivisionOperatorToken();
                    
            }
    
            throw new ArgumentException("Unrecognized Operator Symbol");
        }

        
    }
}
