using System;
using System.Collections.Generic;

namespace HashCode2017
{
	public class EndPoint
	{
		public int id; 

		public List<Tuple<CacheServer, int>> Caches = new List<Tuple<CacheServer, int>>();


		public EndPoint(int id)
		{
		}

		public void Add(CacheServer cache, int latence)
		{
			this.Caches.Add(new Tuple<CacheServer, int>(cache, latence));
		}
	}
}
