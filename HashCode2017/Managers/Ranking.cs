using HashCode2017.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace HashCode2017.Managers
{
    public class Ranking
    {
        public static BufferModel CalculateRanking(
            VideoRequestOnEndPoint[] requests,
            InputModel input)
        {
            BufferModel Result = new BufferModel();

			ConcurrentBag<VideoServerRankModel> listResult = new ConcurrentBag<VideoServerRankModel>();

			Parallel.For(0, requests.Length, i =>
			{
				if (requests[i].Video.Size <= input.CacheSize)
				{
					EndPoint CurrentEndPoint = requests[i].Endpoint;

					foreach (Tuple<CacheServer, int> CacheServer in CurrentEndPoint.Caches)
					{
						int Rank = 0;

						IEnumerable<EndPoint> EndPointsForCurrentCache = CacheServer.Item1.EndPoints.Where(e => e.ContainsVideo(requests[i].Video));

						foreach (EndPoint EndPointToRank in EndPointsForCurrentCache)
						{
							int LatencyToDataCenter = EndPointToRank.DatacenterLatency;
							int LatencyToCurrentCacheServer = CacheServer.Item2;

							int PartialRank = LatencyToDataCenter - LatencyToCurrentCacheServer;

							if (PartialRank > 0)
								Rank = Rank + PartialRank;
						}

						listResult.Add(new VideoServerRankModel(requests[i].Video.Id, CacheServer.Item1.Id, Rank));

					}
				}
			});


			Result.List = listResult.OrderByDescending(e => e.GainTime).Distinct().ToList();

			return Result; 
        }
    }
}
