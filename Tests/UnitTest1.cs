using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeanGoldfish;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void IsText()
        {
            var test = new IsText("ABC");

            var result = test.TryParse("ABC");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void SimpleAndAlsos()
        {
            var test = new IsCharacter('A')
                            .AndAlso(new IsCharacter('B'))
                            .AndAlso(new IsCharacter('C'));

            var result = test.TryParse("ABC");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void SimpleOrElses()
        {
            var test = new IsCharacter('A')
                            .OrElse(new IsCharacter('B'))
                            .OrElse(new IsCharacter('C'));

            var result = test.TryParse("B");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void AndAlsoPlusOrElses()
        {
            var abc = new IsCharacter('A')
                            .AndAlso(new IsCharacter('B'))
                            .AndAlso(new IsCharacter('C'))
                            ;

            var def = new IsCharacter('D')
                            .AndAlso(new IsCharacter('E'))
                            .AndAlso(new IsCharacter('F'))
                            ;

            var abcOrDef = abc.OrElse(def);

            var result = abcOrDef.TryParse("DEF");

            Assert.IsTrue(result.Succeeded);
        }

       
    }
}
