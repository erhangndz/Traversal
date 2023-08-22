using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using Traversal.CQRS.Commands.GuideCommands;

namespace Traversal.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Description = request.Description,
                Name = request.Name,
                Image = request.Image,
                Status = true
            });
            _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
