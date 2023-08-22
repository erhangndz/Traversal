using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Traversal.CQRS.Queries.DestinationQueries;
using Traversal.CQRS.Results.DestinationResults;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationsQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationsQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationsQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationsQueryResult
            {
                Capacity = x.Capacity,
                City = x.City,
                Id = x.DestinationID,
                Price = x.Price,
                StayDuration = x.StayDuration
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
