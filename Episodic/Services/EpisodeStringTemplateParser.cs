using System.Text.RegularExpressions;

namespace Episodic
{
    public interface IEpisodeStringTemplateParser
    {
        string ParseTemplate(string template, EpisodeComponentCollection components);
    }
    public class EpisodeStringTemplateParser : IEpisodeStringTemplateParser
    {
        public const string Error = "ERROR";
        public const string NotFound = "NOT FOUND";

        public string ParseTemplate(string template, EpisodeComponentCollection components)
        {
            string pattern = @"{{([aA-zZ.]+)}}";

            return Regex.Replace(template, pattern, MatchEvaluator(components));
        }

        private static MatchEvaluator MatchEvaluator(EpisodeComponentCollection components) => m => ParseMatch(m, components);
        private static string ParseMatch(Match match, EpisodeComponentCollection components)
        {
            if (match.Groups.Count != 2)
                return Error;
            return match.Groups[1].Value switch
            {
                "MacGuffin" => components.MacGuffinOrDefault()?.Name ?? NotFound,
                "Environment" => components.EnvironmentOrDefault()?.Name ?? NotFound,
                "Location" => components.LocationOrDefault()?.Name ?? NotFound,
                string w when w.StartsWith("Faction") => ParseFaction(w, components),
                _ => Error
            };
        }

        private static string ParseFaction(string request, EpisodeComponentCollection components)
        {
            var faction = components.FactionOrDefault();
            if (faction is null)
                return NotFound;
            return request.Split('.') switch
            {
                string[] args when args.Length == 1 && args[0] is "Faction" => faction.Name,
                string[] args when args.Length == 2 && args[0] is "Faction" &&  args[1] is "Boss" => faction.Boss.Name,
                _ => Error
            };
        }
    }
}
