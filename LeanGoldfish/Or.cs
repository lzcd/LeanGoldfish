using System;

namespace LeanGoldfish
{
    public class Or : ParsingUnit
    {
        private ParsingUnit first;
        private ParsingUnit second;

        public Or(ParsingUnit first, ParsingUnit second)
        {
            this.first = first;
            this.second = second;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult, Action<ParsingResult> destroyResult)
        {
            var firstResult = first.TryParse(text, position, createResult, destroyResult);

            if (firstResult.Succeeded)
            {
                return firstResult;
            }
            destroyResult(firstResult);

            var secondResult = second.TryParse(text, position, createResult, destroyResult);

            return secondResult;
        }
    }
}
