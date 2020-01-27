using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject playerPoint;
    public GameObject roadPre;


    void Update() {
        /*
        Vector3 v = playerPoint.transform.localPosition;
        if ((int)v.x % 15.0 == 0)
        {
            GameObject newRoad = Instantiate(roadPre, new Vector3((int)v.x + 10, 0, 10), Quaternion.identity) as GameObject;
            //Destroy(this.gameObject);
        }
        */
        //Debug.Log(message: v.x);
    }
}
