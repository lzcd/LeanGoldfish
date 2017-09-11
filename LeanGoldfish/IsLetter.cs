using System;

namespace LeanGoldfish
{
    public class IsLetter : ParsingUnit
    {
        public IsLetter()
        {

        }


        internal override ParsingResult TryParse(string text, int position, Func<ParsingResult> createResult, Action<ParsingResult> destroyResult)
        {
            if (position >= text.Length ||
                !char.IsLetter(text[position]))
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
