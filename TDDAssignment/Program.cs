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

            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //StreamWriter output = new StreamWriter(Path.Combine(docPath, "Error_log.txt"));

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file = validator.CanOpenFileXML(@"C:\Users\Roland\source\repos\TDDAssignment\TDDAssignment\xmlforuserstory.xml").Item2;
            //while ((line = file.ReadLine()) != null)
            //{
            //    if (!validator.CheckCharactersBeforeOpenTagsAfterClosingTags(line))
            //        output.WriteLine(counter + ' ' + line);
            //    if (!validator.CheckClosingTags(line))
            //        output.WriteLine(counter + ' ' + line);
            //    if (!validator.CheckIncompleteTag(line))
            //        output.WriteLine(counter + ' ' + line);
            //    if (!validator.CheckWhiteSpace(line))
            //        output.WriteLine(counter + ' ' + line);
            //    if (!validator.TESTWellformness_CheckTagsNameSimilar(line))
            //        output.WriteLine(counter + ' ' + line);

            //        counter++;
            //}

            //file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
