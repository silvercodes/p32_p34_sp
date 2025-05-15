namespace _03_MathLib;

public class Calculator
{
    public int Sum(int a, int b) => a + b;
    public static int Factorial(int n)
    {
        int result = 1;

        for (int i = 1; i <= n; ++i)
            result *= i;

        return result;
    }
}
