namespace Episodic
{
    public class MacGuffinProvider : EpisodeComponentProviderBase<MacGuffin>
    {
        private static readonly MacGuffin defaultValue = new MacGuffin { Name = "Nice cup of tea", Description = "Mmm perhaps we could have some MacGuffins to select from" };

        public MacGuffinProvider(IReadStore<MacGuffin> store, IRandomPicker randomPicker): base(store, randomPicker)
        {
            
        }
        
        protected override MacGuffin GetDefault() => defaultValue;
    }

}
