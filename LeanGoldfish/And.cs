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

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult, Action<ParsingResult> destroyResult)
        {
            var firstResult = first.TryParse(text, position, createResult, destroyResult);

            if (!firstResult.Succeeded)
            {
                return firstResult;
            }
            destroyResult(firstResult);

            var secondResult = second.TryParse(text, firstResult.EndPosition + 1, createResult, destroyResult);
            if (!secondResult.Succeeded)
            {
                return secondResult;
            }
            destroyResult(secondResult);

            var success = createResult();

            success.Succeeded = true;
            success.StartPosition = firstResult.StartPosition;
            success.EndPosition = secondResult.EndPosition;
            return success;
        }
    }
}
