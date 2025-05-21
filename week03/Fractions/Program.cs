using System;

class Program
{
    static void Main(string[] args)
    {
         // Create fractions using different constructors
        Fraction fraction1 = new Fraction();          // 1/1
        Fraction fraction2 = new Fraction(6);         // 6/1
        Fraction fraction3 = new Fraction(6, 7);      // 6/7

        // Display the fraction strings and decimal values
        Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");
        Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");
        Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()} = {fraction3.GetDecimalValue()}");

        // Modify the fraction values using setters
        fraction1.SetTop(3);
        fraction1.SetBottom(4);

        // Display the modified fraction and decimal
        Console.WriteLine($"Modified Fraction 1: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");
    }
}