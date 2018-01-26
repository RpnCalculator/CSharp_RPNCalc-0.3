using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csd.Calculator.Token.Operator
{
    public class DivisionOperatorToken : OperatorToken
    {
        internal DivisionOperatorToken(): base("/")
        {

        }

        public override CalculatorToken Execute(Stack<CalculatorToken> stack)
        {
            if (stack.Count < 2)
            {
                throw new ArgumentException(OperatorToken.OPERATOR_REQUIRES_TWO_OPERANDS);
            }

            Double y = ((OperandToken)stack.Pop()).DoubleValue();
            if (Convert.ToInt32(y) == 0)
            {
                throw new ArgumentException("Cannot divide by 0!");
            }
            Double x = ((OperandToken)stack.Pop()).DoubleValue();

            stack.Push(new OperandToken(x / y));

            return stack.Peek();
        }
    }
}
