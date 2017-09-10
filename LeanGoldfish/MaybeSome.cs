using System;

namespace LeanGoldfish
{
    public class MaybeSome : ParsingUnit
    {
        private ParsingUnit unit;

        public MaybeSome(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult)
        {
            var matchCount = 0;
            var lastPosition = position - 1;
            var match = default(ParsingResult);
            do
            {
                match = unit.TryParse(text, lastPosition + 1, createResult);
                if (match.Succeeded)
                {
                    lastPosition = match.EndPosition;
                    matchCount++;
                }
            } while (match.Succeeded);

            if (matchCount == 0)
            {
                var none = createResult();
                none.Succeeded = true;
                none.StartPosition = position;
                none.EndPosition = position - 1;

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
