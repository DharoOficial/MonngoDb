using MongoDB.Driver;
using Nyous_NoSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous_NoSQL.Context
{
    public class NyousDataBaseSettigs : INyousDataBaseSettigs
    {

       
        public string EventosCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
}

    public interface INyousDataBaseSettigs
    {
        string EventosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
