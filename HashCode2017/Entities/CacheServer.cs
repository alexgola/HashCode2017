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

		public CacheServer(int id, int totalSize)
		{
			Id = id;
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

		public bool ContainsVideo(Video video)
		{
			return this.Videos.Where(e => e.Id == video.Id).Count() > 0;
		}


	}
}
