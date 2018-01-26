using System;

namespace Csd.Calculator.Token
{
    public  abstract class CalculatorToken
    {
        private readonly string _symbol;
        public abstract bool IsOperator();  

        public CalculatorToken(string symbol)
        {
            _symbol = symbol;
        }

        public override string ToString()
        {
            return GetSymbol();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetType()!= obj.GetType())
            {
                return false;
            }
            var other = (CalculatorToken)obj;
            if (GetSymbol() == null)
            {
                if (other.GetSymbol() != null)
                {
                    return false;
                }
            }
            else if (!GetSymbol().Equals(other.GetSymbol()))
            {
                return false;
            }
            return true;
        }

        public String GetSymbol()
        {
            return _symbol;
        }
        public override int GetHashCode()
        {
            return (_symbol != null ? _symbol.GetHashCode() : 0);
        }
    }
}