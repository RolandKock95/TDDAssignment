using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDDAssignment;

namespace TDDAssignmentTEST
{
    [TestFixture]
        class XMLTest
    {
        XMLValidator xMLValidator = new XMLValidator();

        [Test]
        public void TESTCanOpenFileXML()
        {
            Assert.True(xMLValidator.CanOpenFileXML(@"C:\Users\Roland\source\repos\TDDAssignment\TDDAssignment\xmlforuserstory.xml").Item1);
            Assert.False(xMLValidator.CanOpenFileXML(@"C:\Users\Roland\source\repos\TDDAssignment\TDDAssignment\xmltest.docx").Item1);
        }

        [Test]
        public void TESTWelformness_CheckWhiteSpace()
        {
            string str1 = "<test> test </test>";
            string str2 = "<test > test </test>";
            string str3 = "<test> test </ test>";
            Assert.True(xMLValidator.CheckWhiteSpace(str1));
            Assert.False(xMLValidator.CheckWhiteSpace(str2));
            Assert.False(xMLValidator.CheckWhiteSpace(str3));
        }

        [Test]
        public void TESTWelformness_CheckIncompleteTag()
        {
            string str1 = "<test> test </test>";
            string str2 = "<test  test </test>";
            string str3 = "<test> test / test><";
            Assert.True(xMLValidator.CheckIncompleteTag(str1));
            Assert.False(xMLValidator.CheckIncompleteTag(str2));
            Assert.False(xMLValidator.CheckIncompleteTag(str3));
        }

        [Test]
        public void TESTWelformness_CheckClosingTags()
        {
            string str1 = "<test> test </test>";
            string str2 = "<test> test <//test>";
            string str3 = "<test> test <test/>";
            Assert.True(xMLValidator.CheckClosingTags(str1));
            Assert.False(xMLValidator.CheckClosingTags(str2));
            Assert.False(xMLValidator.CheckClosingTags(str3));
        }

        [Test]
        public void TESTWelformness_CheckCharactersBeforeOpenTagsAfterClosingTags()
        {
            string str1 = "<test> test </test>";
            string str2 = "afaf<test> test </test>";
            string str3 = "<test> test </test>asdasd";
            Assert.True(xMLValidator.CheckCharactersBeforeOpenTagsAfterClosingTags(str1));
            Assert.False(xMLValidator.CheckCharactersBeforeOpenTagsAfterClosingTags(str2));
            Assert.False(xMLValidator.CheckCharactersBeforeOpenTagsAfterClosingTags(str3));
        }

        [Test]
        public void TESTWellformness_CheckTagsNameSimilar()
        {
            string str1 = "<test> test </test>";
            string str2 = "<test> test </test1>";
            Assert.True(xMLValidator.TESTWellformness_CheckTagsNameSimilar(str1));
            Assert.False(xMLValidator.TESTWellformness_CheckTagsNameSimilar(str2));
        }
    }
}
