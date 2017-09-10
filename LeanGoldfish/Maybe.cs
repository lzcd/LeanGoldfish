using System;

namespace LeanGoldfish
{
    public class Maybe : ParsingUnit
    {
        private ParsingUnit unit;

        public Maybe(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult)
        {
            var result = unit.TryParse(text, position, createResult);

            if (!result.Succeeded)
            {
                result = createResult();
                result.Succeeded = true;
                result.StartPosition = position;
                result.EndPosition = position - 1;

                return result;
            }

            return result;
        }
    }
}
