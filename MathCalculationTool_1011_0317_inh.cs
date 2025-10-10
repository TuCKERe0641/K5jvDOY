// 代码生成时间: 2025-10-11 03:17:29
using System;

namespace MathTools
{
    // MathCalculationTool class provides a set of mathematical operations
    public class MathCalculationTool
    {
        /// <summary>
        /// Adds two numbers and returns the result.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts the second number from the first and returns the result.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The difference between the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers and returns the result.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides the first number by the second and returns the result.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The quotient of the two numbers.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the divisor is zero.</exception>
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        /// <summary>
        /// Calculates the power of a number to a given exponent and returns the result.
        /// </summary>
        /// <param name="base">The base number</param>
        /// <param name="exponent">The exponent</param>
        /// <returns>The result of the base raised to the exponent.</returns>
        public double Power(double @base, double exponent)
        {
            return Math.Pow(@base, exponent);
        }

        /// <summary>
        /// Calculates the square root of a number and returns the result.
        /// </summary>
        /// <param name="number">The number to calculate the square root of</param>
        /// <returns>The square root of the number.</returns>
        /// <exception cref="ArgumentException">Thrown when the input number is negative.</exception>
        public double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentException("Cannot calculate the square root of a negative number.");
            return Math.Sqrt(number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MathCalculationTool calculator = new MathCalculationTool();

            try
            {
                double addResult = calculator.Add(5, 3);
                Console.WriteLine($"Addition: {5} + {3} = {addResult}");

                double subtractResult = calculator.Subtract(5, 3);
                Console.WriteLine($"Subtraction: {5} - {3} = {subtractResult}");

                double multiplyResult = calculator.Multiply(5, 3);
                Console.WriteLine($"Multiplication: {5} * {3} = {multiplyResult}");

                double divideResult = calculator.Divide(5, 3);
                Console.WriteLine($"Division: {5} / {3} = {divideResult}");

                double powerResult = calculator.Power(5, 3);
                Console.WriteLine($"Power: {5} ^ {3} = {powerResult}");

                double squareRootResult = calculator.SquareRoot(9);
                Console.WriteLine($"Square Root: {9} = {squareRootResult}");

                // Uncommenting the following line will cause a DivideByZeroException
                // double divideByZeroResult = calculator.Divide(5, 0);

                // Uncommenting the following line will cause an ArgumentException
                // double negativeSquareRootResult = calculator.SquareRoot(-4);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}