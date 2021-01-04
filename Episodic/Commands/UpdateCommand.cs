namespace Episodic
{
    public record UpdateCommand<T>(T Item) : Command where T : IStoreObject
    {
    }
}
