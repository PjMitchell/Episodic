namespace Episodic
{
    public class EnvironmentProvider : EpisodeComponentProviderBase<Environment>
    {
        private static readonly Environment defaultValue = new Environment { Name = "Limbo", Description = "Not much here" };

        public EnvironmentProvider(IReadStore<Environment> store, IRandomPicker randomPicker) : base(store, randomPicker)
        {

        }

        protected override Environment GetDefault() => defaultValue;
    }

}
