using SODA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UccSearch.Services.COInfoMarket
{
    /// <summary>
    /// Gets data from the Uniform Commercial Code of Colorado
    /// </summary>
    public class MasterListService : IMarketplaceService
    {
        const string MASTER_LIST_ID = "h28s-f3n9";

        private readonly SodaClient sodaClient;

        private readonly SoqlQuery soqlQuery;

        public MasterListService(SodaClient sodaClient, SoqlQuery soqlQuery)
        {
            this.sodaClient = sodaClient;
            this.soqlQuery = soqlQuery;
        }

        public List<Dictionary<String, Object>> search(string field, string searchTerm)
        {                    
            var dataset = sodaClient.GetResource<Dictionary<string, object>>(MASTER_LIST_ID);
                                                                                               
            this.soqlQuery.Select(field)
                .Where($"debtorname like '%{searchTerm.ToUpper()}%'")
                .Limit(30);

            var rows = dataset.Query(this.soqlQuery);

            var data = rows.ToList();

            return data;
        }
    }
}
