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
            if (extension != ".xml") return false;

            string text = null;
            try
            {
                using (var streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
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
            return true;
        }

        public bool CheckWhiteSpace(string str)
        {
            return Regex.Matches(str, @"<(/?\w+)>").Count == 2;
        }

        public bool CheckIncompleteTag(string str) { return false; }

        public bool CheckClosingTags(string str) { return false; }

        public bool CheckCharactersBeforeOpenTagsAfterClosingTags(string str) { return false; }

        public bool TESTWellformness_CheckTagsNameSimilar(string str) { return false; }
    }
}
