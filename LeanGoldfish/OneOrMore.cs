namespace LeanGoldfish
{
    public class OneOrMore : ParsingUnit
    {
        private ParsingUnit unit;

        public OneOrMore(ParsingUnit unit)
        {
            this.unit = unit;
        }

        internal override ParsingResult TryParse(string text, int position)
        {
            var matchCount = 0;
            var lastPosition = position - 1;
            var result = default(ParsingResult);
            do
            {
                result = unit.TryParse(text, lastPosition + 1);
                if (result.Succeeded)
                {
                    lastPosition = result.EndPosition;
                    matchCount++;
                }
            } while (result.Succeeded);

            if (matchCount < 1)
            {
                return new ParsingResult()
                {
                    Succeeded = false,
                    StartPosition = position,
                    EndPosition = position
                };
            }

            return new ParsingResult()
            {
                Succeeded = true,
                StartPosition = position,
                EndPosition = lastPosition
            };
        }
    }
}
