using System;
using System.Collections.Generic;
using System.Text;

namespace LeanGoldfish
{
    public class Maybe : ParsingUnit
    {
        private ParsingUnit unit;

        public Maybe(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position)
        {
            var result = unit.TryParse(text, position);

            if (!result.Succeeded)
            {
                return new ParsingResult()
                {
                    Succeeded = true,
                    StartPosition = position,
                    EndPosition = position - 1
                };
            }

            return result;
        }
    }
}
