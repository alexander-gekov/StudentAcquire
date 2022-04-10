using System.Threading.Tasks;
using StudentAcquire.Listing.Service.Dtos;

namespace StudentAcquire.Listing.Service.SyncDataServices.Http
{
    public interface IUserDataClient
    {
        Task SendListingToUser(ListingReadDto listing);
    }
}