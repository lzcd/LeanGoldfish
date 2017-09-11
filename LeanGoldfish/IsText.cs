using System;

namespace LeanGoldfish
{
    public class IsText : ParsingUnit
    {
        private ParsingUnit test;

        public IsText(string text)
        {
            var lastOrdinal = text.Length - 1;
            var characterTest = (ParsingUnit)new IsCharacter(text[lastOrdinal]);

            var firstOrdinal = 0;
            var secondLastOrdinal = text.Length - 2;
            for (var ordinal = secondLastOrdinal; ordinal >= firstOrdinal; ordinal--)
            {
                characterTest = new IsCharacter(text[ordinal]).And(characterTest);
            }

            test = characterTest;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult, Action<ParsingResult> destroyResult)
        {
            return test.TryParse(text, position, createResult, destroyResult);
        }
    }
}
