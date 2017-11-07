using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicMovement : MonoBehaviour {

    // place on WIM object
    public GameObject otherObject; // the object in the room
    public float scale = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        otherObject.transform.localPosition = this.transform.localPosition / scale;
        otherObject.transform.localRotation = this.transform.localRotation;
	}
}
