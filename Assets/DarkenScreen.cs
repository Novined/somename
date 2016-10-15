using UnityEngine;
using System.Collections;

public class DarkenScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
			Debug.Log("Wohoo!");
			GetComponent<Light>().intensity =0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
