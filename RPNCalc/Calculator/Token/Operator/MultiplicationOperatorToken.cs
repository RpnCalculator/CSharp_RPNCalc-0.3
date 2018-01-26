﻿using System;
using System.Collections.Generic;

namespace Csd.Calculator.Token.Operator
{
    public class MultiplicationOperatorToken : OperatorToken
    {
        internal MultiplicationOperatorToken(): base("*")
        {

        }

        public override CalculatorToken Execute(Stack<CalculatorToken> stack)
        {
            if (stack.Count < 2)
            {
                throw new ArgumentException(OperatorToken.OPERATOR_REQUIRES_TWO_OPERANDS);
            }

            Double y = ((OperandToken)stack.Pop()).DoubleValue();
            Double x = ((OperandToken)stack.Pop()).DoubleValue();

            stack.Push(new OperandToken(x * y));

            return stack.Peek();
        }
    }
}
