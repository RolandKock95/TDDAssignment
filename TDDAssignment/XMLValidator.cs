using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDAssignment
{
    class XMLValidator
    {

        public Tuple<bool, StreamReader> CanOpenFileXML(string path)
        {
            string extension = Path.GetExtension(path);
            bool didWeMakeIt = false;
            if (extension == ".xml") didWeMakeIt = true;
            StreamReader streamReader = null;

            //string text = null;
            try
            {
                string line;
                int counter = 0;

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                StreamWriter output = new StreamWriter(Path.Combine(docPath, "Error_log.txt"));

                StreamReader file = new StreamReader(path, Encoding.UTF8);

                while ((line = file.ReadLine()) != null)
                {
                    if (!CheckCharactersBeforeOpenTagsAfterClosingTags(line))
                        output.WriteLine(counter + ' ' + line);
                    if (!CheckClosingTags(line))
                        output.WriteLine(counter + ' ' + line);
                    if (!CheckIncompleteTag(line))
                        output.WriteLine(counter + ' ' + line);
                    if (!CheckWhiteSpace(line))
                        output.WriteLine(counter + ' ' + line);
                    if (!TESTWellformness_CheckTagsNameSimilar(line))
                        output.WriteLine(counter + ' ' + line);

                    counter++;
                }
                //text = streamReader.ReadToEnd();
                //didWeMakeIt = true;

            }
            catch (FileNotFoundException e2)
            {
                //should write to log
                Console.WriteLine(e2.StackTrace);
            }
            catch (IOException e)
            {
                //should write to log
                Console.WriteLine(e.StackTrace);
            }

            if (streamReader != null)
                return new Tuple<bool, StreamReader>(didWeMakeIt, streamReader);
            else
                return new Tuple<bool, StreamReader>(didWeMakeIt, null);
        }


        //Kan erstatte de 3 næste metoder da de er total ens
        //public bool CheckTagCompletness(string str)
        //{
        //    return Regex.Matches(str, @"<(/?\w+)>").Count == 2;
        //}

        public bool CheckWhiteSpace(string str)
        {
            return Regex.Matches(str, @"<(/?\w+)>").Count == 2;
        }

        public bool CheckIncompleteTag(string str)
        {
            return Regex.Matches(str, @"<(/?\w+)>").Count == 2;
        }

        public bool CheckClosingTags(string str)
        {
            return Regex.Matches(str, @"<(/\w+)>").Count == 1;
        }

        public bool CheckCharactersBeforeOpenTagsAfterClosingTags(string str)
        {
            //tæller matches, hvis der er text FØR tag
            int firstTag = Regex.Matches(str, @"(\w+)<\w+>").Count;

            //tæller matches, hvis der er text EFTER tag
            int secondTag = Regex.Matches(str, @"</\w+>(\w+)").Count;

            return !((firstTag + secondTag) > 0);
        }

        public bool TESTWellformness_CheckTagsNameSimilar(string str)
        {
            string firstTag = str.Substring(0, str.IndexOf('>') + 1);
            if (firstTag.IndexOf('>') == str.IndexOf('>')) return true;
            string newStr = str.Substring(str.IndexOf('>') + 1);

            string secondTag = newStr.Substring(newStr.IndexOf('<'));
            secondTag = secondTag.Replace("/", "");

            return firstTag.Equals(secondTag);
        }
    }
}
