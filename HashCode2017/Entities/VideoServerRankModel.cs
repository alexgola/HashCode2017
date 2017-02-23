using System;
namespace HashCode2017
{
	public class VideoServerRankModel
	{
		public int VideoId;
		public int ServerId;
		public float Rank;

		public VideoServerRankModel(int videoId, int serverId, float rank)
		{
			VideoId = videoId;
			ServerId = serverId;
			Rank = rank;
		}

	}
}
