using System;
using System.Numerics;

namespace RationalLib
{
    // immutable
    public readonly partial struct BigRational
    {
        public readonly BigInteger Numerator { get; init; }
        public readonly BigInteger Denominator { get; init; }

        #region
        public readonly static BigRational Zero = new (0);
        public readonly static BigRational One = new(1);
        public readonly static BigRational Half = new(1, 2);

        public readonly static BigRational PositiveInfinity = new(1, 0);
        public readonly static BigRational NegativeInfinity = new(-1, 0);
        public readonly static BigRational NaN = new(0, 0);
        #endregion

        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            if (Denominator < 0)
            {
                Numerator *= (-1);
                Denominator *= (-1);
            }
        }

        public BigRational(BigInteger value) : this(value, 1)
        {
        }

        public override string ToString() => $"{Numerator}/{Denominator}";
        public static BigRational Parse(string value)
        {
            var tab = value.Split("/");
            if (tab.Length != 2)
                throw new FormatException("Za dużo ukośników");
            return new BigRational(BigInteger.Parse(tab[0]), BigInteger.Parse(tab[1]));
            
        }

        public static bool IsNaN(BigRational u) => u.Numerator == 0 && u.Denominator == 0;
    }
}
