namespace Episodic
{
    public class LocationProvider : EpisodeComponentProviderBase<Location>
    {
        private static readonly Location defaultValue = new Location { Name = "Somewhere", Description = "It is a place" };

        public LocationProvider(IReadStore<Location> store, IRandomPicker randomPicker) : base(store, randomPicker)
        {
        }

        protected override Location GetDefault() => defaultValue;
    }

}
