using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : MonoBehaviour {

    public static bool Line_Clipping(ref Vector3 v0, ref  Vector3 v1)
    {
        Outcode ov0 = new Outcode(v0);
        Outcode ov1 = new Outcode(v1);

        print("Vectors : " + v0 + " / " +v1);

        if (TrivialAcceptance(ov0,ov1))
        {
            print("Trivial Acceptance !");
            return true;
        }
        else if (TrivialRejection(ov0,ov1))
        {
            print("Trivial Rejection !");
            return false;
        }
        else
        {
            print(WorkToDO(ref v0,ref v1));
            print("Vectors : " + v0 + " / " + v1);
        }
        return false;
    }    

    public static bool TrivialAcceptance(Outcode oc1, Outcode oc2)
    {
        return oc1.IsZero() && oc2.IsZero();
    }

    public static bool TrivialRejection(Outcode oc1, Outcode oc2)
    {
        return !((oc1&oc2).IsZero());
    }

    public static bool WorkToDO(ref Vector3 v0, ref Vector3 v1)
    {
        
        float m = (v1.y-v0.y) / (v1.x-v0.x);

        float X=v0.x, Y=v1.y;
        v0 = Clipping(v0,m);
        v1 = Clipping(v1, m);

        Outcode ov0 = new Outcode(v0);
        Outcode ov1 = new Outcode(v1);

        if (TrivialAcceptance(ov0,ov1))
        {
           print("Work to Do : true, on the Screen");
            return true;
        }
        else
        {
            print("Work to Do : false, not on the Screen");
            return false;
        }
    }

    private static Vector3 Clipping(Vector3 v, float m)
    {

        Outcode ov = new Outcode(v);
        float X = v.x, Y = v.y;

        if (ov.Left)
        {
            Y = lineIntersectY(-1, v, m);
            X = -1;
        }
        else if (ov.Right)
        {
            Y = lineIntersectY(1, v, m);
            X = 1;
        }
        else if (ov.Up)
        {
            X = lineIntersectX(1, v, m);
            Y = 1;
        }
        else if (ov.Down)
        {
            X = lineIntersectX(-1, v, m);
            Y = -1;
        }

        v.x = X;
        v.y = Y;

        return v;
    }

    private static float lineIntersectX(int edge, Vector3 v, float m)
    {
        return (m*v.x + edge - v.y)/m;
    }

    public static float lineIntersectY(int edge, Vector3 v, float m)
    {
        return m * (edge - v.x) + v.y;
    }
    
}
