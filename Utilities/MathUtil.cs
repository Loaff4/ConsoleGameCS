namespace Utilities;

public class MathUtil
{
    public static float Scale(float value, float factor)
    {
        return value + (value*factor*0.01f);
    }
}