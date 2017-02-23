using System;
namespace HashCode2017
{
	public class VideoRequestOnEndPoint
	{
		public Video Video;
		public EndPoint Endpoint;
		public int RequestsNumber; 

		public VideoRequestOnEndPoint(Video video, EndPoint endpoint, int requestsNumber)
		{
			Video = video;
			Endpoint = endpoint;
			RequestsNumber = requestsNumber;
		}
	}
}
