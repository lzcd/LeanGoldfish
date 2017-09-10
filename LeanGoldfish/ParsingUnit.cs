using System;

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

        public ParsingUnit AndUpon(ParsingUnit nextUnit, Action<ParsingResult> action)
        {
            return new And(this, new Upon(nextUnit, action));
        }

        public ParsingUnit OrUpon(ParsingUnit nextUnit, Action<ParsingResult> action)
        {
            return new Or(this, new Upon(nextUnit, action));
        }

        public ParsingResult TryParse(string text, Func<ParsingResult> createResult)
        {
            return TryParse(text, 0, createResult);
        }

        internal abstract ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult);
    }
}
