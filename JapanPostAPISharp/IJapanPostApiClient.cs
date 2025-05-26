using JapanPostAPISharp.Model;

namespace JapanPostAPISharp
{
    public interface IJapanPostApiClient
    {
        Task<SearchCodeResponce?> SearchCodeAsync(string serachCode, string ecuid = "", int page = 1, int limit = 1, int choikittype = 1, int searchtype = 1);
        Task<AddressZipResponse?> AddressZip(AddressZipRequestParameter addressZipRequestParameter, string ecuid);
    }
}