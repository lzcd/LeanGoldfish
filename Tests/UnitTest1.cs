using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeanGoldfish;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OrUpon()
        {
            var calledBack = false;
            var test = new IsText("AA")
                        .OrUpon(new IsText("BB"), (r) =>
                        {
                            calledBack = true;
                        })
                        .And(new IsText("CC"));

            var result = test.TryParse("BBCC", () => { return new ParsingResult(); });
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(calledBack);
        }

        [TestMethod]
        public void AndUpon()
        {
            var calledBack = false;
            var test = new IsText("AA")
                        .AndUpon(new IsText("BB"), (r) =>
                        {
                            calledBack = true;
                        })
                        .And(new IsText("CC"));

            var result = test.TryParse("AABBCC", () => { return new ParsingResult(); });
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(calledBack);
        }

        [TestMethod]
        public void Maybe()
        {
            var test = new Maybe(new IsCharacter('A'))
                .And(new IsCharacter('B'));

            var result = test.TryParse("AB", () => { return new ParsingResult(); });

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void ZeroOrMore()
        {
            var test = new ZeroOrMore(new IsCharacter('A'))
                .And(new IsCharacter('B'));

            var result = test.TryParse("AB", () => { return new ParsingResult(); });

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void OneOrMore()
        {
            var test = new OneOrMore(new IsCharacter('A'))
                .And(new IsCharacter('B'));

            var result = test.TryParse("AAAB", () => { return new ParsingResult(); });

            Assert.IsTrue(result.Succeeded);
        }


        [TestMethod]
        public void IsText()
        {
            var test = new IsText("ABC");

            var result = test.TryParse("ABC", () => { return new ParsingResult(); });

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void SimpleAnds()
        {
            var test = new IsCharacter('A')
                            .And(new IsCharacter('B'))
                            .And(new IsCharacter('C'));

            var result = test.TryParse("ABC", () => { return new ParsingResult(); });

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public void SimpleOrs()
        {
            var test = new IsCharacter('A')
                            .Or(new IsCharacter('B'))
                            .Or(new IsCharacter('C'));

            var result = test.TryParse("B", () => { return new ParsingResult(); });

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

            var result = abcOrDef.TryParse("DEF", () => { return new ParsingResult(); });

            Assert.IsTrue(result.Succeeded);
        }

       
    }
}
