namespace Traversal.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public string City { get; set; }
        public string StayDuration { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }
       
    }
}
