using HashCode2017.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Managers
{
    public class Ranking
    {
        public static BufferModel CalculateRanking(
            List<VideoRequestOnEndPoint> requests,
            InputModel input)
        {
            BufferModel Result = new BufferModel();

			foreach(var request in requests)
            {
                EndPoint CurrentEndPoint = request.Endpoint;
                foreach (Tuple<CacheServer, int> CacheServer in CurrentEndPoint.Caches)
                {
                    int Rank = 0;

					List<EndPoint> EndPointsForCurrentCache = CacheServer.Item1.EndPoints.ToList(); 

                    EndPointsForCurrentCache = 
                        EndPointsForCurrentCache.Where(e => input.GetVideoRequestsByEndpoint(e).Where(r => r.Video.Id == request.Video.Id).Count() > 0).ToList();

                    foreach (EndPoint EndPointToRank in EndPointsForCurrentCache)
                    {
                        int LatencyToDataCenter = EndPointToRank.DatacenterLatency;
                        Tuple<CacheServer, int> Couple =
                            EndPointToRank.Caches.Where(e => e.Item1.Id == CacheServer.Item1.Id).FirstOrDefault();
                        int LatencyToCurrentCacheServer = 0;
                        if (Couple != null)
                            LatencyToCurrentCacheServer = Couple.Item2;

                        int PartialRank = LatencyToDataCenter - LatencyToCurrentCacheServer;

                        if (PartialRank > 0)
                            Rank = Rank + PartialRank;
                    }

                    Result.AddVideoServerRank(new VideoServerRankModel(request.Video.Id, CacheServer.Item1.Id, Rank));

                }
            }


			Result.List = Result.List.OrderBy(e => e.GainTime).Distinct().ToList();

			return Result; 
        }
    }
}
