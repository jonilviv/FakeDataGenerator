using System;
using System.Threading;

namespace Tests.FakeDataGenerator
{
    public abstract class Randomiser
    {
        private static int _seed = Environment.TickCount;
        protected static readonly ThreadLocal<Random> __random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)));
    }
}