using MediatR;

namespace Traversal.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
