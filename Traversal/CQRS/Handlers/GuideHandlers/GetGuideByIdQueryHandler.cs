using DataAccessLayer.Concrete;
using MediatR;
using Traversal.CQRS.Queries.GuideQueries;
using Traversal.CQRS.Results.GuideResults;

namespace Traversal.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.id);
            return new GetGuideByIdQueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                Image = values.Image,
                Name = values.Name
            };
        }
    }
}
