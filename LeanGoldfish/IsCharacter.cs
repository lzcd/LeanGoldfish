using System;

namespace LeanGoldfish
{
    public class IsCharacter : ParsingUnit
    {
        private char character;

        public IsCharacter(char character)
        {
            this.character = character;
        }

        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult)
        {
            if (position >= text.Length ||
                text[position] != character)
            {
                var failure = createResult();
                failure.Succeeded = false;
                failure.StartPosition = position;
                failure.EndPosition = position;

                return failure;
            }

            var success = createResult();
            success.Succeeded = true;
            success.StartPosition = position;
            success.EndPosition = position;

            return success;
        }
    }
}
