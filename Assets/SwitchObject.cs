using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SwitchObject : MonoBehaviour {

    bool isMenu;

    public VRTK_InteractableObject menu;
    public VRTK_InteractableObject wim;

    private VRTK_ObjectAutoGrab script;
    private VRTK_InteractGrab grabScript;
    private VRTK_InteractTouch interactTouch;

    private bool lastUsePressedState = false;
    private bool menuActive = false;

    private void Awake()
    {
        script = this.GetComponent<VRTK_ObjectAutoGrab>();
        grabScript = this.GetComponent<VRTK_InteractGrab>();
        interactTouch = this.GetComponent<VRTK_InteractTouch>();
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
            if (!menuActive)
            {
                if (controller.buttonOnePressed)
                {
                    Debug.Log("MENU ACTIVATE");
                    grabScript.ForceRelease(); // release WIM
                    wim.transform.position = new Vector3(-999, -999, -999); // get that shit out of here fam
                    menu.transform.position = transform.position; // bring the menu to the controller
                    interactTouch.ForceStopTouching();
                    interactTouch.ForceTouch(menu.gameObject); // force touch
                    grabScript.AttemptGrab(); // grab it
                    menuActive = true;
                }
            } else if (menuActive)
            {
                if (controller.buttonTwoPressed)
                {
                    Debug.Log("WIM ACTIVATE");
                    grabScript.ForceRelease();
                    menu.transform.position = new Vector3(-999, -999, -999);
                    wim.transform.position = transform.position;
                    interactTouch.ForceStopTouching();
                    interactTouch.ForceTouch(wim.gameObject);
                    grabScript.AttemptGrab();
                    menuActive = false;
                }
            }
            lastUsePressedState = controller.buttonOnePressed;
        }
    }
}
