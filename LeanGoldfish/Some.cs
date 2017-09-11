using System;

namespace LeanGoldfish
{
    public class Some : ParsingUnit
    {
        private ParsingUnit unit;

        public Some(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult, Action<ParsingResult> destroyResult)
        {
            var matchCount = 0;
            var lastPosition = position - 1;
            var match = default(ParsingResult);
            do
            {
                match = unit.TryParse(text, lastPosition + 1, createResult, destroyResult);
                if (match.Succeeded)
                {
                    lastPosition = match.EndPosition;
                    matchCount++;
                }
            } while (match.Succeeded);
            destroyResult(match);

            if (matchCount < 1)
            {
                var none = createResult();
                none.Succeeded = false;
                none.StartPosition = position;
                none.EndPosition = position;

                return none;
            }

            var some = createResult();
            some.Succeeded = true;
            some.StartPosition = position;
            some.EndPosition = lastPosition;

            return some;
        }
    }
}
