using System;

namespace LeanGoldfish
{
    public class ZeroOrMore : ParsingUnit
    {
        private ParsingUnit unit;

        public ZeroOrMore(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult)
        {
            var matchCount = 0;
            var lastPosition = position - 1;
            var result = default(ParsingResult);
            do
            {
                result = unit.TryParse(text, lastPosition + 1, createResult);
                if (result.Succeeded)
                {
                    lastPosition = result.EndPosition;
                    matchCount++;
                }
            } while (result.Succeeded);

            if (matchCount == 0)
            {
                result = createResult();
                result.Succeeded = true;
                result.StartPosition = position;
                result.EndPosition = position - 1;

                return result;
            }

            result = createResult();
            result.Succeeded = true;
            result.StartPosition = position;
            result.EndPosition = lastPosition;

            return result;
        }
    }
}
