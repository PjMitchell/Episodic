namespace Episodic
{
    public class FactionProvider : EpisodeComponentProviderBase<Faction>
    {
        private static readonly Faction defaultValue = new Faction { Name = "Legion of Doom", Description = "Mmm perhaps we could have some Faction to select from" };

        public FactionProvider(IReadStore<Faction> store, IRandomPicker randomPicker) : base(store, randomPicker)
        {

        }

        protected override Faction GetDefault() => defaultValue;
    }

}
