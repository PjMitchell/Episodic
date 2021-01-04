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
            string pattern = @"{{([aA-zZ]+)}}";

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
                _ => Error
            };
        }
    }
}
