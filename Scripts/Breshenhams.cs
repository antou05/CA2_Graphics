using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breshenhams : MonoBehaviour
{
    public Breshenhams(Vector2 start, Vector2 end)
    {
        LinkedList<Vector2> l = this.BreshenhamsAlgo(start, end);
        int j = l.Count;
        for (int k=0; k<j; k++)
        {
            print(l.First.Value.ToString());
            l.RemoveFirst();
        }
    }

    private LinkedList<Vector2> BreshenhamsAlgo(Vector2 start, Vector2 end)
    {

        float[] tabX = new float[500];
        float[] tabY = new float[500];


        LinkedList<Vector2> vectList = new LinkedList<Vector2>();        
        

        tabX[0] = start.x;
        tabY[0] = start.y;

        float dx = end.x - start.x;
        if (dx < 0)
            return BreshenhamsAlgo(end, start);

        float dy = end.y - start.y;
        if (dy < 0)
            return NegateYs(BreshenhamsAlgo(NegateY(start), NegateY(end)));
        if (dy > dx)
            return SwapXYs(BreshenhamsAlgo(SwapXY(start), SwapXY(end)));
        float neg;
        float pos;
        int i, j = 0; 

        pos = 2 * dy;
        neg = 2 * (dy - dx);
        print(neg +"/"+pos);
        
        for (i = 0; i <= (int)end.x; i++)
        {
            tabX[i] = i;
        }

        j = 1;

        tabY[0] = start.y;
        vectList.AddFirst(new Vector2(tabX[3], tabY[0]));
        
        float P = 2 * dy - dx;
        for (i = (int)start.x+1; i <= (int)end.x; i++)
        {
            print("p" + i + "///" +P);
            if (P >= 0)
            {
                tabY[j] = tabY[j-1] + 1;
                vectList.AddLast(new Vector2(tabX[i], tabY[j]));
                P = P + neg;
                j++;
            }
            else
            {
                tabY[j] = tabY[j-1];
                vectList.AddLast(new Vector2(tabX[i], tabY[j]));
                P = P + pos;
                j++;
            }
        }
        return vectList;
    }

    private LinkedList<Vector2> SwapXYs(LinkedList<Vector2> list)
    {
        LinkedList<Vector2> newList = new LinkedList<Vector2>();
        int j = list.Count;
        for (int k = 0; k <=j ; k++)
        {
            newList.AddLast(new Vector2(list.First.Value.y,list.First.Value.x));
            list.RemoveFirst();
        }
        return newList;
    }

    private Vector2 SwapXY(Vector2 start)
    {
        return new Vector2(start.y, start.x);
    }

    private LinkedList<Vector2> NegateYs(LinkedList<Vector2> list)
    {
        int j = list.Count;
        LinkedList<Vector2> newList = new LinkedList<Vector2>();
        for (int i = 0; i<= j; i++)
        {
            newList.AddLast(new Vector2(list.First.Value.x, - list.First.Value.y));
            list.RemoveFirst();
        }
        return newList;
    }

    private Vector2 NegateY(Vector2 start)
    {
        return new Vector2(start.x, - start.y);
    }

  /*  public void Start() //test method
    {
        print("BRESHENHAMS");
        Breshenhams b = new Breshenhams(new Vector2(3,2),new Vector2(8,5));

    }
    */
}
