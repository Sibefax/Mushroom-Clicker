public static class GlobalMethods 
{ 
    public static string MakeShorter(long number) 
    { 
        long absoluteNumber = System.Math.Abs(number);
        string suffix = "";
        double value = number;

        if (absoluteNumber >= 1000000) 
        { 
            suffix = "kk";
            value = (double)number / 1000000; 
        } 
        else if (absoluteNumber >= 1000) 
        { 
            suffix = "k"; 
            value = (double)number / 1000; 
        } 

        return value.ToString("0.##") + suffix; 
    } 
}