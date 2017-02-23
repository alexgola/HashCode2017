using System;
using HashCode2017.Costants;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HashCode2017.Entities;

namespace HashCode2017
{
	public static class VideoServerEngine
	{
		public static List<VideoServerRankModel> CheckCacheSize(BufferModel bufferModel, List<Video> videos, int cacheSize) {
			Dictionary<int, int> sizes = new Dictionary<int, int>();

			for (int i = 0; i < videos.Count; i++) {
				sizes.Add(videos[i].Id, videos[i].Size);
			}

			return bufferModel.List.Where(vsr => sizes[vsr.VideoId] < cacheSize).ToList();

		}

		public static void WriteFile(List<CacheServer> cacheServers)
		{
			var file = File.Create(Strings.OUTPUT_FILE_NAME);
			file.Close();
			using (StreamWriter outfile = new StreamWriter(Strings.OUTPUT_FILE_NAME, true))
			{
				outfile.WriteLine(cacheServers.Count);

				foreach (CacheServer server in cacheServers)
				{
					outfile.WriteLine(server.Id+" "+string.Join(" ", server.Videos.Select(video=>video.Id.ToString())));
				}
			}
		}

		public static void CalculateCaches(InputModel input, BufferModel bufferModel)
		{
			List<VideoServerRankModel> filteredVideoServerRank = CheckCacheSize(bufferModel, input.Videos.ToList(), input.CacheSize);

			List<CacheServer> cacheServers = input.ChaceServers.ToList();

			for (int i = 0; i < filteredVideoServerRank.Count; i++)
			{
				VideoServerRankModel vsr = filteredVideoServerRank[i];
				Video video = input.Videos[vsr.VideoId];
				CacheServer cacheServer = cacheServers[vsr.ServerId];

				if (cacheServer.CanAdd(video))
				{
					cacheServer.AddVideo(video);
				}
			}

			cacheServers = cacheServers.Where(s => s.Videos.Count != 0).ToList();

			WriteFile(cacheServers);

		}
	}
}
