using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Mode8 : MonoBehaviour {

    public GameObject otherObject; // the object in the room

    public VRTK_ControllerEvents controller;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            otherObject.transform.localScale = this.transform.localScale;
    }
}
