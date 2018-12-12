using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertion : MonoBehaviour
{
    private static int ResX = 1920;

    private static int ResY = 1080;

	public Convertion(Vector3 start,Vector3 end)
    {
        Breshenhams b = new Breshenhams(VectorToPixelX(start), VectorToPixelY(end));
    }

    private static Vector2 VectorToPixelY(Vector3 end)
    {
        return new Vector2(((end.x + 1)/2) * (ResX-1), ((1 - end.y) / 2) * (ResY - 1));
    }

    private static Vector2 VectorToPixelX(Vector3 v)
    {
        return new Vector2(((v.x + 1) / 2) * (ResX - 1), ((1 - v.y) / 2) * (ResY - 1));
    }
}
