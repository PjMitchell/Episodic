using Episodic.Web.Controllers;
using System;

namespace Episodic.Test.Controllers
{
    public class MacGuffinControllerTests : BaseComponentControllerTest<MacGuffin>
    {
        public MacGuffinControllerTests() : base(m => new MacGuffinController(m))
        {

        }

        protected override MacGuffin Get(Guid id) => new MacGuffin { Id = id };
    }
}
