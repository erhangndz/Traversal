﻿namespace Traversal.CQRS.Results.DestinationResults
{
    public class GetDestinationByIDQueryResult
    {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string StayDuration { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }
    }
}
