using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class ModeSwitch : MonoBehaviour
    {

        public Material lightOn;
        public Material lightOff;

        public GameObject controller;

        public GameObject[] modeList;

        bool isColliding = false;
        public bool multipleLights = false;

        bool isLightOn = false;
        private bool lastUsePressedState = false;

        private void Awake()
        {
            this.modeList = GameObject.FindGameObjectsWithTag("Modes");
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerStay(Collider collider)
        {
            VRTK_ControllerEvents controller;
            controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
            if (controller != null)
            {
                if (lastUsePressedState == true && !controller.triggerPressed)
                {
                    isLightOn = !isLightOn;
                    if (isLightOn)
                    {
                        this.GetComponent<Renderer>().material = lightOn;
                        if (this.name.Equals("Mode 1"))
                        {
                            Debug.Log("REEEEEEEEEEEE");
                        } else if (this.name.Equals("Mode 2"))
                        {

                        } else if (this.name.Equals("Mode 3"))
                        {

                        } else if (this.name.Equals("Mode 4"))
                        {

                        } else if (this.name.Equals("Mode 5"))
                        {

                        } else if (this.name.Equals("Mode 6"))
                        {

                        } else if (this.name.Equals("Mode 7"))
                        {

                        } else if (this.name.Equals("Mode 8"))
                        {

                        }

                    }
                    else
                    {
                        this.GetComponent<Renderer>().material = lightOff;

                    }
                }
                lastUsePressedState = controller.triggerPressed;
            }
        }
    }
}
