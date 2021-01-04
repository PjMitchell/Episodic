namespace Episodic.Test
{
    public class AlwaysPicksFirst : IRandomPicker
    {
        public T Pick<T>(T[] source)
        {
            return source[0];
        }
    }
}
