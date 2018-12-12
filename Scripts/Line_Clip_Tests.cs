using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Clip_Tests : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 v1 = new Vector3(1,1);
        Vector3 v2 = new Vector3(0, 0);
        Vector3 v3 = new Vector3(8, 7);
        Vector3 v4 = new Vector3(5, 2);
        Vector3 v5 = new Vector3(2, 0.5f);
        Vector3 v6 = new Vector3(00.5f, 1.3f);
        Vector3 v7 = new Vector3(0, 1.5f);
        Vector3 v8 = new Vector3(1.5f, 0);

        Debug.Log("1rst Clipping : Acceptance");
        if(Assignment2.Line_Clipping(ref v1, ref v2))
        Debug.Log("-----------------------------");
        Debug.Log("2nd Clipping : Rejection");
        Assignment2.Line_Clipping(ref v3, ref v4);
        Debug.Log("-----------------------------");
        Debug.Log("3thd Clipping : WTO nothing");
        Assignment2.Line_Clipping(ref v5, ref v6);
        Debug.Log("-----------------------------");
        Debug.Log("4th Clipping : WTO + Vect");
        Assignment2.Line_Clipping(ref v7, ref v8);
        Debug.Log("-----------------------------");

    }
}
