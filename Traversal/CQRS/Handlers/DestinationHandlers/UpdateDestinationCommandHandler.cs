using DataAccessLayer.Concrete;
using Traversal.CQRS.Commands.DestinationCommands;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.Id);
            values.City= command.City;
            values.StayDuration= command.StayDuration;
            values.Price= command.Price;
            values.Capacity= command.Capacity;
            values.Status = true;
            _context.SaveChanges();
        }
    }
}
