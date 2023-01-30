using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CustomMath
{
    public static float GetRandom(Vector2 bounds)
    {
        return Random.Range(bounds.x, bounds.y);
    }
    public static int GetRandomInt(Vector2 bounds)
    {
        return Mathf.RoundToInt(Random.Range(bounds.x-0.5f, bounds.y+0.5f)); ;
    }
    public static string SecondsToTimer(int time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return minutes + ":" + seconds;
    }
}
