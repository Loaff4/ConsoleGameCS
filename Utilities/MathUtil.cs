namespace ConsoleGame.Utilities;

public class MathUtil
{
    public static float Scale(float value, float factor)
    {
        return value + (value*factor*0.01f);
    }

    public static float Round2(float number)
    {
       return (float)Math.Round(number*100)/100; 
    }
}