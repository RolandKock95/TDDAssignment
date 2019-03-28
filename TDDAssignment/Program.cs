using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLValidator validator = new XMLValidator();

            string path = @"C:\Users\Roland\source\repos\TDDAssignment\TDDAssignment\xmlforuserstory.xml";

            if (!validator.CanOpenFileXML(path)) Console.WriteLine("Den gik ikke");
            else
            {
                string line;
                int counter = 0;

                try
                {
                    

                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    StreamWriter output = new StreamWriter(Path.Combine(docPath, "Error_log.txt"));

                    using (var file = new StreamReader(path, Encoding.UTF8))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            if (!validator.CheckCharactersBeforeOpenTagsAfterClosingTags(line))
                                output.WriteLine(counter + ' ' + line);
                            if (!validator.CheckClosingTags(line))
                                output.WriteLine(counter + ' ' + line);
                            if (!validator.CheckIncompleteTag(line))
                                output.WriteLine(counter + ' ' + line);
                            if (!validator.CheckWhiteSpace(line))
                                output.WriteLine(counter + ' ' + line);
                            if (!validator.TESTWellformness_CheckTagsNameSimilar(line))
                                output.WriteLine(counter + ' ' + line);

                            counter++;
                        }
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                Console.WriteLine("Der var {0} linjer", counter);
            }

        }
    }
}
