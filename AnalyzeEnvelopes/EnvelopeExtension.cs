namespace AnalysisOfEnvelopes
{
    public static class EnvelopeExtension
    {
        public static bool IsInsertedInto(this Envelope envelope1, Envelope envelope2)
        {
            if (envelope1 is null || envelope2 is null)
            {
                return false;
            }
            
            return (envelope1.ShortSide < envelope2.ShortSide)
                && (envelope1.LongSide < envelope2.LongSide);
        }
    }
}
