using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ScaleObject : MonoBehaviour {

    public GameObject otherObject; // the object in the room

    public VRTK_ControllerEvents controller;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (controller.touchpadAxisChanged)
        {
            otherObject.transform.localScale = this.transform.localScale + new Vector3(0, 0.01f, 0);
        }
    }
}
