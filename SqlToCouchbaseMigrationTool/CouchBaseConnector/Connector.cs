using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.IO;
using Couchbase.N1QL;
using Couchbase.Views;


namespace CouchBaseConnector
{
    public class Connector
    {
        public bool Save<T>(string key, T obj, TimeSpan timeSpan)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(AppSettings.DefaultBucket))
                {
                    IOperationResult res = bucket.Upsert(key, obj, timeSpan);
                    if (res.Status == ResponseStatus.Success)
                        return true;
                }
            }
            return false;
        }

        public T Get<T>(string key)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(AppSettings.DefaultBucket))
                {
                    IOperationResult<T> res = bucket.Get<T>(key);
                    if (res.Status == ResponseStatus.Success)
                    {
                        return res.Value;
                    }
                    throw new Exception("Data not found");
                }
            }
        }

        public List<dynamic> Query(IQueryRequest query)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(AppSettings.DefaultBucket))
                {
                    var res = bucket.Query<dynamic>(query);

                    var resultSet = new List<dynamic>();

                    foreach (var row in res.Rows)
                    {
                        resultSet.Add(row);
                    }
                    return resultSet;
                }
            }
        }

        public List<T> Query<T>(string view, string queryName)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(AppSettings.DefaultBucket))
                {
                    var query = bucket.CreateQuery(view, queryName, true).Limit(5);
                    var resultSet = new List<T>();
                    var result = bucket.Query<T>(query);
                    foreach (ViewRow<T> row in result.Rows)
                    {
                        resultSet.Add(row.Value);
                    }
                    return resultSet;
                }
            }
        }
    }
}
