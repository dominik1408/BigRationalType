using System;
using System.Numerics;

namespace RationalLib
{
    public readonly partial struct BigRational : IEquatable<BigRational>
    {
        public bool Equals(BigRational other)
        {
            if (IsNaN(this) && IsNaN(other)) return true;
            if (IsNaN(this) && !IsNaN(other) ||
                IsNaN(other) && !IsNaN(this)
                )
                 return false;

            return this.Numerator == other.Numerator && this.Denominator == other.Denominator;

        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is BigRational other) return true;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public static bool operator ==(BigRational left, BigRational right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BigRational left, BigRational right)
        {
            return !(left == right);
        }
    }
}
