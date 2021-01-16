using System.Collections.Generic;
using System.Linq;

namespace Episodic
{
    public interface IEpisodeComponent
    {
        EpisodeComponentType Type { get; }
    }

    public class EmptyEpisodeComponent : IEpisodeComponent
    {
        public static EmptyEpisodeComponent Default => new EmptyEpisodeComponent();
        public EpisodeComponentType Type => EpisodeComponentType.Empty;
    }

    public enum EpisodeComponentType
    {
        Empty = 0,
        MacGuffin = 1,
        Faction = 2,
        Environment = 3,
        Location = 4
    }

    public class EpisodeComponentCollection
    {
        private readonly Dictionary<EpisodeComponentType, IEpisodeComponent> source;
        public EpisodeComponentCollection(IEnumerable<IEpisodeComponent> components)
        {
            source = components.ToDictionary(k => k.Type);
        }

        public IEpisodeComponent GetComponent(EpisodeComponentType type)
        {
            if (source.TryGetValue(type, out var result))
                return result;
            return EmptyEpisodeComponent.Default;
        }
    }
}
