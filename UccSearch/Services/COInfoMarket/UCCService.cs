using SODA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UccSearch.Services.COInfoMarket
{
    public class UccService : IUccService
    {
        const string APP_TOKEN = "";

        const string MASTER_LIST_ID = "h28s-f3n9";

        const string FILINGS_ID = "8d38-bpb6";

        const string BASE_URL = "https://data.colorado.gov";

        public List<Dictionary<String, Object>> UCCSearch(string searchTerm)
        {
                var client = new SodaClient(BASE_URL, APP_TOKEN);

                var dataset = client.GetResource<Dictionary<string, object>>(MASTER_LIST_ID);

                var query = new SoqlQuery();
                query.Select("debtorname")
                    .Where($"debtorname like '%{searchTerm.ToUpper()}%'")
                    .Limit(30);

                var rows = dataset.Query(query);

                var data = rows.ToList();

                return data;
        }
    }
}
