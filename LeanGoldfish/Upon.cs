using System;
using System.Collections.Generic;
using System.Text;

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

        internal override ParsingResult TryParse(string text, int position)
        {
            var result = unit.TryParse(text, position);

            if (!result.Succeeded)
            {
                return result;
            }

            action(result);

            return result;
        }
    }
}
