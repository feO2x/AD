using Light.GuardClauses;

namespace AD.Tests.Shared;

public static class CommonMath
{
    public static int CalculateFactorial(int number)
    {
        number.MustNotBeLessThan(0);
        return number switch
        {
            0 or 1 => 1,
            2 => 2,
            _ => CalculateFactorialChecked(number)
        };
    }

    private static int CalculateFactorialChecked(int number)
    {
        checked
        {
            var returnValue = 2;
            var limit = number + 1;
            for (var i = 3; i < limit; i++)
            {
                returnValue *= i;
            }

            return returnValue;
        }
    }
}