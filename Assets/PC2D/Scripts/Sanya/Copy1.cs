using UnityEngine;
using System.Collections;

public class Copy1 : MonoBehaviour
{

 float speed;
  Vector3 target;
  Vector3 start;
  Vector3 pos;

    void  Start()
    {
        start = transform.position;
        pos = transform.position;
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
    }
}