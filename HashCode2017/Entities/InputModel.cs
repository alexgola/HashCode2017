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
		public CacheServer[] ChaceServers;
		public EndPoint[] EndPoints;
		public VideoRequestOnEndPoint[] RequestDescriptions; 

		public int CacheSize; 
       
        public InputModel(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string CurrentRow  = sr.ReadLine();
				//5 videos, 2 endpoints, 4 request descriptions, 3 caches 100MB each.
				var values = CurrentRow.Split(' ').Select(e => Convert.ToInt32(e)).ToArray();
				int VideosNumber = values[0];
				int EndpointsNumber = values[1]; 
				int Requests = values[2];
				int cacheNumbers = values[3]; 
				CacheSize = values[4];


				// videos
				CurrentRow = sr.ReadLine();
				values = CurrentRow.Split(' ').Select(e => Convert.ToInt32(e)).ToArray();
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

				// create Endpoint 
				EndPoints = new EndPoint[EndpointsNumber];

				// add cache to endpoints
				for (int i = 0; i < EndpointsNumber; i++)
				{
					CurrentRow = sr.ReadLine();

					values = CurrentRow.Split(' ').Select(e => Convert.ToInt32(e)).ToArray();
					int datacenterLat = values[0];
					int totalCaches = values[1];

					EndPoints[i] = new EndPoint(i, datacenterLat);
					for (int k = 0; k < totalCaches; k++)
					{
						CurrentRow = sr.ReadLine();
						values = CurrentRow.Split(' ').Select(e => Convert.ToInt32(e)).ToArray();
						int cacheId = values[0];
						int lat = values[1];

						EndPoints[i].Add(ChaceServers[cacheId], lat);

					}
				}

				// VideoRequestOnEndPoint creations 
				RequestDescriptions = new VideoRequestOnEndPoint[Requests];
				for (int i = 0; i < Requests; i++)
				{
					CurrentRow = sr.ReadLine();
					values = CurrentRow.Split(' ').Select(e => Convert.ToInt32(e)).ToArray();
					int requestNumbers = values[2];
					int videoNumber = values[0];
					int endpoint = values[1];

					RequestDescriptions[i] = new VideoRequestOnEndPoint(Videos[videoNumber], EndPoints[endpoint], requestNumbers); 

				}

			}

        }
    }
}
