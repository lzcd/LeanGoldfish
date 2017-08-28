using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeanGoldfish;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Upon()
        {
            var calledBack = false;
            var test = new IsCharacter('A')
                        .AndUpon(new IsCharacter('B'), (r) =>
                        {
                            calledBack = true;
                        })
                        .And(new IsCharacter('C'));

            var result = test.TryParse("ABC");
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(calledBack);
        }

        [TestMethod]
        public void Maybe()
        {
            var test = new Maybe(new IsCharacter('A'))
                .And(new IsCharacter('B'));

            var result = test.TryParse("AB");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void ZeroOrMore()
        {
            var test = new ZeroOrMore(new IsCharacter('A'))
                .And(new IsCharacter('B'));

            var result = test.TryParse("AB");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void OneOrMore()
        {
            var test = new OneOrMore(new IsCharacter('A'))
                .And(new IsCharacter('B'));

            var result = test.TryParse("AAAB");

            Assert.IsTrue(result.Succeeded);
        }


        [TestMethod]
        public void IsText()
        {
            var test = new IsText("ABC");

            var result = test.TryParse("ABC");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void SimpleAnds()
        {
            var test = new IsCharacter('A')
                            .And(new IsCharacter('B'))
                            .And(new IsCharacter('C'));

            var result = test.TryParse("ABC");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void SimpleOrs()
        {
            var test = new IsCharacter('A')
                            .Or(new IsCharacter('B'))
                            .Or(new IsCharacter('C'));

            var result = test.TryParse("B");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void AndPlusOr()
        {
            var abc = new IsCharacter('A')
                            .And(new IsCharacter('B'))
                            .And(new IsCharacter('C'))
                            ;

            var def = new IsCharacter('D')
                            .And(new IsCharacter('E'))
                            .And(new IsCharacter('F'))
                            ;

            var abcOrDef = abc.Or(def);

            var result = abcOrDef.TryParse("DEF");

            Assert.IsTrue(result.Succeeded);
        }

       
    }
}
