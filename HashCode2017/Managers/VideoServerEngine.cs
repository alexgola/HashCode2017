using System;
using System.Collections.Generic;
using System.Linq;
using HashCode2017.Entities;

namespace HashCode2017
{
	public static class VideoServerEngine
	{
		
		static BufferModel bufferModel = new BufferModel(new List<VideoServerRankModel> { 
			new VideoServerRankModel(0, 0, 100.0),
			new VideoServerRankModel(0, 1, 120.0),
			new VideoServerRankModel(0, 2, 300.0),
			new VideoServerRankModel(1, 0, 500.0),
			new VideoServerRankModel(1, 1, 180.0),
			new VideoServerRankModel(1, 3, 400.0),
			new VideoServerRankModel(2, 0, 130.0),
			new VideoServerRankModel(2, 1, 10.0),
			new VideoServerRankModel(2, 2, 700.0),
			new VideoServerRankModel(3, 0, 190.0),
			new VideoServerRankModel(3, 1, 900.0),
			new VideoServerRankModel(3, 2, 140.0),
			new VideoServerRankModel(4, 0, 400.0),
			new VideoServerRankModel(4, 1, 500.0),
			new VideoServerRankModel(4, 2, 140.0),
			new VideoServerRankModel(5, 0, 430.0),
			new VideoServerRankModel(5, 1, 670.0),
			new VideoServerRankModel(5, 2, 270.0)
		});

		public static void checkCacheSize(InputModel input) {
			
			//bufferModel.List.Where(i=>)
		}

	}
}
