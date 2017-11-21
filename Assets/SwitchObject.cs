using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SwitchObject : MonoBehaviour {

    bool isMenu;

    public VRTK_InteractableObject menu;
    public VRTK_InteractableObject wim;

    private VRTK_ObjectAutoGrab script;

    private bool lastUsePressedState = false;

    private void Awake()
    {
        script = this.GetComponent<VRTK_ObjectAutoGrab>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        VRTK_ControllerEvents controller;
        controller = this.GetComponent<VRTK_ControllerEvents>();
        if (controller != null)
        {
            if (lastUsePressedState == true && !controller.buttonOnePressed && script.objectToGrab != menu)
            {
                Debug.Log("MENU ACTIVATE");
                script.objectToGrab = menu;
            } else if (lastUsePressedState == false && controller.buttonOnePressed && script.objectToGrab != wim)
            {
                script.objectToGrab = wim;
                Debug.Log("WIM ACTIVATE");
            }
            lastUsePressedState = controller.buttonOnePressed;
        }
    }
}
