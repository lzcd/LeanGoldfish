namespace LeanGoldfish
{
    public class Or : ParsingUnit
    {
        private ParsingUnit first;
        private ParsingUnit second;

        public Or(ParsingUnit first, ParsingUnit second)
        {
            this.first = first;
            this.second = second;
        }

        internal override ParsingResult TryParse(string text, int position)
        {
            var firstResult = first.TryParse(text, position);

            if (firstResult.Succeeded)
            {
                return firstResult;
            }

            var secondResult = second.TryParse(text, position);

            return secondResult;
        }
    }
}
