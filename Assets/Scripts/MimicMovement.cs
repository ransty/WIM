using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MimicMovement : MonoBehaviour {

    // place on WIM object
    public GameObject otherObject; // the object in the room

    public int currentMode = 1;
    
    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
          otherObject.transform.localPosition = this.transform.localPosition;
          //otherObject.transform.localRotation = this.transform.localRotation;
          //otherObject.transform.localEulerAngles = this.transform.localEulerAngles;
	}

}
