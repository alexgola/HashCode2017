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

       
        public InputModel(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string CurrentRow  = sr.ReadLine();

        		
            }

        }
    }
}
