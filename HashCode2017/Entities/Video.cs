using System;
using System.Collections.Generic;

namespace HashCode2017
{
	public class Video
	{
		public int Id; 
		public int Size;


		public Video(string line)
		{
			Size = Convert.ToInt32(line);
		}
	}
}
