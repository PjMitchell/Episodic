using System;
using Easy.Endpoints;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Episodic.Web.Controllers
{


    public class EpisodeComponentsAttribute : SingleGenericParameterDiscoveryAttribute
    {
        protected override IEnumerable<Type> GetTypes()
        {
            yield return typeof(MacGuffin);
            yield return typeof(Environment);
            yield return typeof(Faction);
            yield return typeof(Location);
            yield return typeof(EpisodeTemplate);
        }
    }
}
