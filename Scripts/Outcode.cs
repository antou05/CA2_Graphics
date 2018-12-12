using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outcode : MonoBehaviour
{

    private bool[] UDLR { get; set; }

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;

    public Outcode()
    {
        Up = Down = Left = Right = true; 
    }

    public Outcode(bool u, bool d, bool l, bool r)
    {
        Up = u;
        Down = d;
        Left = l;
        Right = r;
    }
    
    public Outcode(Vector3 v)
    {
        double x = v.x;
        double y = v.y;

        Up = false;
        Down = false;
        Left = false;
        Right = false;

        if (y > 1)
        {
            Up = true;
        }
        else if (y < -1)
        {
            Down = true;
        }
        if (x > 1)
        {
            Right = true;
        }
        else if (x < -1)
        {
            Left = true; ;
        }
    }

    public void printOutCode()
    {
        Debug.Log("Up :" + this.Up);
        Debug.Log("Down :" + this.Down);
        Debug.Log("Left :" + this.Left);
        Debug.Log("Right :" + this.Right);
    }

    public static Outcode operator& (Outcode oc1, Outcode oc2)
    {
        Outcode tmp = new Outcode();

        tmp.Up = oc1.Up && oc2.Up;
        tmp.Down = oc1.Down && oc2.Down;
        tmp.Left = oc1.Left && oc2.Left;
        tmp.Right = oc1.Right && oc2.Right;

        return tmp;
    }
    public static bool operator ==(Outcode oc1, Outcode oc2)
    {
        return (oc1.IsZero() && oc1.IsZero());
    }

    public static bool operator !=(Outcode oc1, Outcode oc2)
    {
        return (oc1.IsZero() || oc1.IsZero());
    }


    public bool IsZero()
    {
        return !(Up || Down || Left || Right);
    }


    /*
    void Start ()
    {
        //TEST 

        Vector3 V0 = new Vector3 ( 0.4f, -0.5f);

        Outcode OCV0 = new Outcode(V0);

        OCV0.printOutCode();

        Vector3 V1 = new Vector3(-0.3f, 1 );

        Outcode OCV1 = new Outcode(V1);

        OCV1.printOutCode();

        Vector3 V2 = new Vector3(1.2f, 0.5f );

        Outcode OCV2 = new Outcode(V2);

        OCV2.printOutCode();

        Vector3 V3 = new Vector3(2.3f, -3 );

        Outcode OCV3 = new Outcode(V3);

        OCV3.printOutCode();



        Vector3 V4 = new Vector3(2, 0.5f );

        Outcode OCV4 = new Outcode(V4);

        OCV4.printOutCode();
        Vector3 V5 = new Vector3(0.5f, 1.3f );

        Outcode OCV5 = new Outcode(V5);

        OCV5.printOutCode();






        //Additions 
        Outcode add = new Outcode();

        add = OCV0 & OCV1;
            
        add.printOutCode();

        add = OCV2 & OCV3;

        add.printOutCode();

        add = OCV4 & OCV5;

        add.printOutCode();

    }*/

    public override string ToString()
    {
        return base.ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }
}
