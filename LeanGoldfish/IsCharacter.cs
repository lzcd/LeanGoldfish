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

        internal override ParsingResult TryParse(string text, int position)
        {
            if (position >= text.Length ||
                text[position] != character)
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
                EndPosition = position
            };
        }
    }
}
