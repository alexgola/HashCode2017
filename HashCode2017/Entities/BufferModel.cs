﻿using System;
using System.Collections.Generic;

namespace HashCode2017
{
	public class BufferModel
	{
		public List<VideoServerRankModel> List;

		public BufferModel()
		{
			List = new List<VideoServerRankModel>();
		}

		public BufferModel(List<VideoServerRankModel> list)
		{
			List = list;
		}

		public void AddVideoServerRank(VideoServerRankModel vsr)
		{
			List.Add(vsr);
		}


	}
}
