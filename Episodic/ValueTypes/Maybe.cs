namespace Episodic
{
    public abstract record Maybe<T>
    {
        private Maybe()
        {
        }

        public sealed record Some(T Value) : Maybe<T>
        {
        }

        public sealed record None : Maybe<T>
        {
        }

        public static Maybe<T> Create(T? value)
        {
            if (value is null)
                return new None();
            return new Some(value);
        }
    }
}
