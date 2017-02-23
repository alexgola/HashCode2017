using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode2017
{
	public class CacheServer
	{
		public int Id;
		public int TotalSize;
		public int TotalUsed;
		public int RemainingSize;
		public List<Video> Videos;
		private Dictionary<int, EndPoint> endpoints;


		public IEnumerable<EndPoint> EndPoints 
		{ 
			get
			{
				return endpoints.Values;
			}
		}

		public CacheServer(int id, int totalSize)
		{
			Id = id;
			TotalSize = totalSize;
         	TotalUsed = 0;
			RemainingSize = totalSize;
			Videos = new List<Video>();
			endpoints = new Dictionary<int, EndPoint>();
		}

		public bool CanAdd(Video video)
		{
			return RemainingSize >= video.Size;
		}

		public void AddVideo(Video video)
		{
			this.TotalUsed += video.Size;
			this.RemainingSize = TotalSize - TotalUsed;

			Videos.Add(video); 
		}

		public bool ContainsVideo(Video video)
		{
			return this.Videos.Where(e => e.Id == video.Id).Count() > 0;
		}

		public void AddEndpoint(EndPoint endpoint)
		{
			if(!endpoints.ContainsKey(endpoint.Id))
				endpoints.Add(endpoint.Id, endpoint);
		}


	}
}
