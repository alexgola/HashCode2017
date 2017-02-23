using System;
namespace HashCode2017
{
	public class VideoServerRankModel: IEquatable<VideoServerRankModel>
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


		public bool Equals(VideoServerRankModel other)
		{
			return this.ServerId == other.ServerId && VideoId == other.VideoId; 
		}
		public override int GetHashCode()
		{
			return VideoId.GetHashCode() ^ ServerId.GetHashCode();
		}
	}
}
