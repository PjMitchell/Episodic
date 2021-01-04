using System;

namespace Episodic
{
    public interface IRandomPicker
    {
        T Pick<T>(T[] source);
    }

    public class RandomPicker : IRandomPicker
    {
        private readonly Random random;
        public RandomPicker()
        {
            random = new Random(DateTime.UtcNow.Millisecond);
        }
        public T Pick<T>(T[] source)
        {
            var index = random.Next(0, source.Length);
            return source[index];
        }
    }
}
