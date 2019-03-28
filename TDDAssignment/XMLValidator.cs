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

        public bool CanOpenFileXML(string path)
        {
            string extension = Path.GetExtension(path);
            if (extension != ".xml") return false; ;

            try
            {
                using (var streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    string text = streamReader.ReadToEnd();
                    if (text != null) return true;
                    else return false;
                }
            }
            catch (FileNotFoundException e2)
            {
                //should write to log
                Console.WriteLine(e2.StackTrace);
                return false;
            }
            catch (IOException e)
            {
                //should write to log
                Console.WriteLine(e.StackTrace);
                return false;
            }
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
