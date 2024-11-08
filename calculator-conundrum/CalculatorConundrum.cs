using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        string result = "";
        switch (operation)
        {
            case "+":
                int add = operand1 + operand2;
                result = operand1 + " + " + operand2 + " = " + add;
                break;
            case "*":
                int multi = operand1*operand2;
                result = operand1 + " * " + operand2 + " = " + multi;
                break;
            case "/":
                if(operand2 == 0)
                {
                    result = "Division by zero is not allowed.";
                    break;
                } else 
                {
                    int divide = operand1/operand2;
                    result = operand1 + " / " + operand2 + " = " + divide;
                    break;
                }
            case "":
                throw new ArgumentException(operation, "Operation cannot be empty string");
            case null:
                throw new ArgumentNullException(operation, "Operation cannot be null");
            default:
                throw new ArgumentOutOfRangeException(operation, "Operation must be one of the options");
        }
        return result;
    }
}
