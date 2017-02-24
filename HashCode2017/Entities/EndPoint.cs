using System;
using System.Collections.Generic;

namespace HashCode2017
{
	public class EndPoint
	{
		public int Id; 

		public List<Tuple<CacheServer, int>> Caches = new List<Tuple<CacheServer, int>>();
		public int DatacenterLatency;
		public Dictionary<int, Video> VideosByRequests; 

		public EndPoint(int id, int datacenterLat)
		{
			Id = id;
			DatacenterLatency = datacenterLat;
			VideosByRequests = new Dictionary<int, Video>();
		}

		public void Add(CacheServer cache, int latence)
		{
			this.Caches.Add(new Tuple<CacheServer, int>(cache, latence));
		}

		public void Add(Video video) {
			if (!VideosByRequests.ContainsKey(video.Id))
			{
				VideosByRequests.Add(video.Id, video);
			}
		}

		public bool ContainsVideo(Video video)
		{
			return VideosByRequests.ContainsKey(video.Id);
		}
	}
}
