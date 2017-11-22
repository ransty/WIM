using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode6 : MonoBehaviour {

    public GameObject otherObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        otherObject.transform.localRotation = this.transform.localRotation;
        otherObject.transform.localEulerAngles = this.transform.localEulerAngles;
    }
}
