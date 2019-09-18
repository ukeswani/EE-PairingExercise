using System;

namespace EE_SuperMarket
{
    public static class Extensions
    {
        public static Func<X, Z> AndThen<X, Y, Z>(this Func<X, Y> firstFunc, Func<Y, Z> secondFunc)
        {
            return x => secondFunc(firstFunc(x));
        }
    }
}
