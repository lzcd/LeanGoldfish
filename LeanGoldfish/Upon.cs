using System;

namespace LeanGoldfish
{
    public class Upon : ParsingUnit
    {
        private ParsingUnit unit;
        private Action<ParsingResult> action;

        public Upon(ParsingUnit unit, Action<ParsingResult> action)
        {
            this.unit = unit;
            this.action = action;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult, Action<ParsingResult> destroyResult)
        {
            var result = unit.TryParse(text, position, createResult, destroyResult);

            if (!result.Succeeded)
            {
                return result;
            }

            action(result);

            return result;
        }
    }
}
