using System;

namespace LeanGoldfish
{
    public class MaybeOne : ParsingUnit
    {
        private ParsingUnit unit;

        public MaybeOne(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult,  Action<ParsingResult> destroyResult)
        {
            var match = unit.TryParse(text, position, createResult, destroyResult);

            if (!match.Succeeded)
            {
                destroyResult(match);

                var none = createResult();
                none.Succeeded = true;
                none.StartPosition = position;
                none.EndPosition = position - 1;

                return none;
            }

            return match;
        }
    }
}
