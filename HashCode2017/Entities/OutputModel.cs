using HashCode2017.Costants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Entities
{
    public class OutputModel
    {
        public List<ICommand> list;

        public OutputModel()
        {
            list = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            list.Add(command);
        }

        public void WriteFile()
        {
            var file = File.Create(Strings.OUTPUT_FILE_NAME);
            file.Close();
            using (StreamWriter outfile = new StreamWriter(Strings.OUTPUT_FILE_NAME, true))
            {
                outfile.WriteLine(list.Count);
                foreach (ICommand command in list)
                {
                    outfile.WriteLine(command.ToString());
                }
            }
        }
    }

    public interface ICommand
    {
        string ToString();
    }
    
}
