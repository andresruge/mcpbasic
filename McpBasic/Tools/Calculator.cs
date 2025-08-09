
using System.ComponentModel;
using ModelContextProtocol.Server;

/// <summary>
/// Provides basic mathematical calculation tools accessible as server tools.
/// </summary>
/// <remarks>
/// This class contains various mathematical operations that can be used as server tools,
/// including basic arithmetic operations and prime number validation.
/// Each method is decorated with the McpServerTool attribute to make it available as a server tool.
/// </remarks>
[McpServerToolType]
public static class Calculator
{
    /// <summary>
    /// Calculates the sum of two numbers.
    /// </summary>
    /// <param name="numberA">The first number.</param>
    /// <param name="numberB">The second number.</param>
    /// <returns>The sum of the two numbers.</returns>
    [McpServerTool, Description("Calculates the sum of two numbers")]
    public static double Add(double numberA, double numberB)
    {
        return numberA + numberB;
    }

    /// <summary>
    /// Calculates the difference of two numbers.
    /// </summary>
    /// <param name="numberA">The first number.</param>
    /// <param name="numberB">The second number.</param>
    /// <returns>The difference of the two numbers.</returns>
    [McpServerTool, Description("Calculates the difference of two numbers")]
    public static double Subtract(double numberA, double numberB)
    {
        return numberA - numberB;
    }

    /// <summary>
    /// Calculates the product of two numbers.
    /// </summary>
    /// <param name="numberA">The first number.</param>
    /// <param name="numberB">The second number.</param>
    /// <returns>The product of the two numbers.</returns>
    [McpServerTool, Description("Calculates the product of two numbers")]
    public static double Multiply(double numberA, double numberB)
    {
        return numberA * numberB;
    }

    /// <summary>
    /// Calculates the quotient of two numbers.
    /// </summary>
    /// <param name="numberA">The dividend.</param>
    /// <param name="numberB">The divisor.</param>
    /// <returns>The quotient of the two numbers.</returns>
    /// <exception cref="ArgumentException">Thrown when the divisor is zero.</exception>
    [McpServerTool, Description("Calculates the quotient of two numbers")]
    public static double Divide(double numberA, double numberB)
    {
        if (numberB == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }
        return numberA / numberB;
    }
    
    /// <summary>
    /// Validates if a number is prime.
    /// </summary>
    /// <param name="number">The number to validate.</param>
    /// <returns>True if the number is prime, false otherwise.</returns>
    [McpServerTool, Description("Validates if a number is prime")]
    public static bool IsPrime(long number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        // Check divisibility using the 6k±1 optimization
        for (long i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }
}
