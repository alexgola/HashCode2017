using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode2017
{
	public class CacheServer
	{
		public int Id;
		public int Latency;
		public int TotalSize;
		public int TotalUsed;
		public int RemainingSize;
		public List<Video> Videos;

		public CacheServer(string line, int totalSize)
		{
			var values = line.Split(',').ToArray();
			Id = Convert.ToInt32(values[0]);
			Latency = Convert.ToInt32(values[1]);
			TotalSize = totalSize;
         	TotalUsed = 0;
         	RemainingSize = 0;
			Videos = new List<Video>(); 
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


	}
}
