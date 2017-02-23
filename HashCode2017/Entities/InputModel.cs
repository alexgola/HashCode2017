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

		Video[] Videos;
		DataCenter DataCenter;
		CacheServer[] ChaceServers;
		EndPoint[] endpoints;
		int CacheSize; 
       
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
				CacheSize = values[3]; 



			}

        }
    }
}
