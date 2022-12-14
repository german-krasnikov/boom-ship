public static class IntHelper
{
    public static int GetPrevSequenceNumber(this int it, int max, int start)
    {
        return it > start ? it - 1 : max;
    }

    public static int GetNextSequenceNumber(this int it, int max, int start)
    {
        return it < max ? it + 1 : start;
    }
}