using System;
public class Utils{
    public static bool EqualFloat(float a, float b, float epsilon=0.01f){
        return Math.Abs(a-b) <= epsilon;
    }
}