public static class GlobalMethods
{
    public static string MakeShorter(long number)
    {
        string shorter;
        string visibleNumber = number.ToString();
        
        if (number >= 1000000)
        {
            shorter = "kk";
            visibleNumber = (number/1000000).ToString() + shorter;
        }
        else if (number >= 1000)
        {
            shorter = "k";
            visibleNumber = (number/1000).ToString() + shorter;
        }
        return visibleNumber;
    }
}
