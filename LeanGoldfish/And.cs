using System;

namespace LeanGoldfish
{
    public class And : ParsingUnit
    {
        private ParsingUnit first;
        private ParsingUnit second;

        public And(ParsingUnit first, ParsingUnit second)
        {
            this.first = first;
            this.second = second;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult)
        {
            var firstResult = first.TryParse(text, position, createResult);

            if (!firstResult.Succeeded)
            {
                return firstResult;
            }

            var secondResult = second.TryParse(text, firstResult.EndPosition + 1, createResult);
            if (!secondResult.Succeeded)
            {
                return secondResult;
            }

            var success = createResult();

            success.Succeeded = true;
            success.StartPosition = firstResult.StartPosition;
            success.EndPosition = secondResult.EndPosition;
            return success;
        }
    }
}
