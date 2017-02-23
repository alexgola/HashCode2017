using HashCode2017.Costants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Entities
{
    public class InputModel
    {

		public Video[] Videos;
		public DataCenter DataCenter;
		public CacheServer[] ChaceServers;
		public EndPoint[] endpoints;
		public int CacheSize; 
       
        public InputModel(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string CurrentRow  = sr.ReadLine();
				//5 videos, 2 endpoints, 4 request descriptions, 3 caches 100MB each.
				var values = CurrentRow.Split(',').Select(e => Convert.ToInt32(e)).ToArray();
				int VideosNumber = values[0];
				int EndPoints = values[1]; 
				int Request = values[2];
				int cacheNumbers = values[3]; 
				CacheSize = values[4];


				// videos
				CurrentRow = sr.ReadLine();
				values = CurrentRow.Split(',').Select(e => Convert.ToInt32(e)).ToArray();
				Videos = new Video[VideosNumber]; 
				for (int i = 0; i < VideosNumber; i++)
				{
					Videos[i] = new Video(values[i], i);
				}

				//create cache 
				ChaceServers = new CacheServer[cacheNumbers]; 
				for (int i = 0; i < cacheNumbers; i++)
				{
					ChaceServers[i] = new CacheServer(i, CacheSize);
				}

				// create Endpoiny



			}

        }
    }
}
