using HashCode2017.Costants;
using HashCode2017.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputModel r = new OutputModel();
            InputModel input = new InputModel(Strings.INPUT_FILE_NAME);

            r.WriteFile();
            
        }
    }

}
