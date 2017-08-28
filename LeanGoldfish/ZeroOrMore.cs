namespace LeanGoldfish
{
    public class ZeroOrMore : ParsingUnit
    {
        private ParsingUnit unit;

        public ZeroOrMore(ParsingUnit unit)
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

            if (matchCount == 0)
            {
                return new ParsingResult()
                {
                    Succeeded = true,
                    StartPosition = position,
                    EndPosition = position - 1
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
