using System.Collections.Generic;

namespace UccSearch.Services.COInfoMarket
{
    public interface IMarketplaceService
    {
        List<Dictionary<string, object>> search(string field, string searchTerm);
    }
}