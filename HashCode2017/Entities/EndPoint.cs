using System;
using System.Collections.Generic;

namespace HashCode2017
{
	public class EndPoint
	{
		public int Id; 

		public List<Tuple<CacheServer, int>> Caches = new List<Tuple<CacheServer, int>>();
		public int DatacenterLatency; 

		public EndPoint(int id, int datacenterLat)
		{
			Id = id;
			DatacenterLatency = datacenterLat;
		}

		public void Add(CacheServer cache, int latence)
		{
			this.Caches.Add(new Tuple<CacheServer, int>(cache, latence));
		}
	}
}
