using System;
using System.Collections.Generic;
using System.Text;

namespace LeanGoldfish
{
    public abstract class ParsingUnit
    {
        public ParsingUnit And(ParsingUnit nextUnit)
        {
            return new And(this, nextUnit);
        }

        public ParsingUnit Or(ParsingUnit nextUnit)
        {
            return new Or(this, nextUnit);
        }

        public ParsingResult TryParse(string text)
        {
            return TryParse(text, 0);
        }

        internal abstract ParsingResult TryParse(string text, int position);
    }
}
