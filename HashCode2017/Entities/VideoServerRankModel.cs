using System;
namespace HashCode2017
{
	public class VideoServerRankModel
	{
		public int VideoId;
		public int ServerId;
		public double GainTime;

		public VideoServerRankModel(int videoId, int serverId, double gainTime)
		{
			VideoId = videoId;
			ServerId = serverId;
			GainTime = gainTime;
		}

	}
}
