using Episodic.Web.Controllers;
using System;

namespace Episodic.Test.Controllers
{
    public class EpisodeTemplateControllerTests : BaseComponentControllerTest<EpisodeTemplate>
    {
        public EpisodeTemplateControllerTests() : base(m => new EpisodeTemplateController(m))
        {

        }

        protected override EpisodeTemplate Get(Guid id) => new EpisodeTemplate { Id = id };
    }
}
