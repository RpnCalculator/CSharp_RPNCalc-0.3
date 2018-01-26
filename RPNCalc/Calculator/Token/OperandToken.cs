using System;

namespace Csd.Calculator.Token
{
    public class OperandToken:CalculatorToken
    {

        private static String FormatOperand(String sym)
        {
            Double val = Convert.ToDouble(sym);
            String str = val.ToString();
            if (str.EndsWith(".0"))
            {
                return str.Substring(0, str.Length - 2);
            }
            return str;
        }

        public OperandToken(String symbol):base(FormatOperand(symbol))
        {
            
        }


        public OperandToken(Double val): base(FormatOperand(val.ToString()))
        {
            
        }

        public Double DoubleValue()
        {
            return Convert.ToDouble(GetSymbol());
        }
        
        public sealed override  bool IsOperator()
        {
            return false;
        }
    }
}