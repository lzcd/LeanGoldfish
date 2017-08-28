using System;
using System.Collections.Generic;
using System.Text;

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

        internal override ParsingResult TryParse(string text, int position)
        {
            var firstResult = first.TryParse(text, position);

            if (!firstResult.Succeeded)
            {
                return firstResult;
            }

            var secondResult = second.TryParse(text, firstResult.EndPosition + 1);

            return secondResult;
        }
    }
}
