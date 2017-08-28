using System;
using System.Collections.Generic;
using System.Text;

namespace LeanGoldfish
{
    public abstract class ParsingUnit
    {
        public ParsingUnit AndAlso(ParsingUnit nextUnit)
        {
            return new AndAlso(this, nextUnit);
        }

        public ParsingUnit OrElse(ParsingUnit nextUnit)
        {
            return new OrElse(this, nextUnit);
        }

        public ParsingResult TryParse(string text)
        {
            return TryParse(text, 0);
        }

        internal abstract ParsingResult TryParse(string text, int position);
    }
}
