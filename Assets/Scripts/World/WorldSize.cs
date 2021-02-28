using UnityEngine;

public static class WorldSize
{
    public static float FullWidth()
    {
        return FullHeight() * Camera.main.aspect;
    }

    public static float FullHeight()
    {
        return Camera.main.orthographicSize * 2;
    }

    // Relative height from (0,0)
    public static float RelativeHeight()
    {
        return FullHeight() / 2;
    }
    
    // Relative width from (0,0)
    public static float RelativeWidth()
    {
        return FullWidth() / 2;
    }
}
