namespace StudentAcquire.Listing.Service.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewListing(ListingPublishDto listing);
    }
}