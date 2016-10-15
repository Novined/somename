using UnityEngine;
using System.Collections;

public class Magic2 : MonoBehaviour
{
    public GameObject ground;
    public ParticleSystem snow;
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            Instantiate(ground);
            Vector3 temp = Input.mousePosition;
            temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
            ground.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
        if (Input.GetKeyDown("s"))
        {
                Instantiate(snow);
                snow.transform.position = gameObject.transform.position + new Vector3(0, 10, 2);
        }
    }
}
