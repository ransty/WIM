using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class ModeSwitch : MonoBehaviour
    {
        public static int currentMode = 1;

        public Material lightOn;
        public Material lightOff;

        public GameObject controller;

        private GameObject player;

        public GameObject[] modeList;

        bool isColliding = false;
        public bool multipleLights = false;

        bool isLightOn = false;
        private bool lastUsePressedState = false;

        private void Awake()
        {
            this.modeList = GameObject.FindGameObjectsWithTag("Modes");
            this.player = GameObject.Find("WIM Player");
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
                            // Mode 1 is default mode, will add later
                            currentMode = 1;
                            Debug.Log(currentMode);
                        } else if (this.name.Equals("Mode 2"))
                        {
                            // Wait for user to place replica of them, then update camera (no animation)
                            currentMode = 2;
                            // Get the script
                            PlayerMimic script = player.GetComponent<PlayerMimic>();
                            // Set the new mode on the WIM object
                            script.EnableMode2();
                        } else if (this.name.Equals("Mode 3"))
                        {
                            // Wait for user to place replica of them, then update camera (with animation)
                            currentMode = 3;
                            Debug.Log(currentMode);
                        } else if (this.name.Equals("Mode 4"))
                        {
                            currentMode = 4;
                            Debug.Log(currentMode);
                            GameObject[] wimObjects = GameObject.FindGameObjectsWithTag("WIM");
                            foreach (GameObject wim in wimObjects)
                            {
                                if (wim.GetComponent<MimicMovement>() != null)
                                {
                                    wim.GetComponent<MimicMovement>().enabled = true;
                                    wim.GetComponent<Mode6>().enabled = false;
                                    wim.GetComponent<Mode8>().enabled = false;
                                }
                            }

                        } else if (this.name.Equals("Mode 5"))
                        {
                            currentMode = 5;
                            Debug.Log(currentMode);
                            GameObject[] wimObjects = GameObject.FindGameObjectsWithTag("WIM");
                            foreach (GameObject wim in wimObjects)
                            {
                                if (wim.GetComponent<MimicMovement>() != null)
                                {
                                    wim.GetComponent<MimicMovement>().enabled = true;
                                    wim.GetComponent<Mode6>().enabled = false;
                                    wim.GetComponent<Mode8>().enabled = false;
                                }
                            }
                        } else if (this.name.Equals("Mode 6"))
                        {
                            currentMode = 6;
                            Debug.Log(currentMode);
                            GameObject[] wimObjects = GameObject.FindGameObjectsWithTag("WIM");
                            foreach (GameObject wim in wimObjects)
                            {
                                if (wim.GetComponent<Mode6>() != null)
                                {
                                    wim.GetComponent<Mode6>().enabled = true;
                                    wim.GetComponent<Mode8>().enabled = false;
                                    wim.GetComponent<MimicMovement>().enabled = false;
                                }
                            }
                        } else if (this.name.Equals("Mode 7"))
                        {
                            currentMode = 7;
                            Debug.Log(currentMode);

                            // Enable scripts in the room and disable wim scripts
                            GameObject[] roomObjects = GameObject.FindGameObjectsWithTag("Room");
                            GameObject[] wimObjects = GameObject.FindGameObjectsWithTag("WIM");

                            foreach (GameObject wim in wimObjects)
                            {
                                if (wim.GetComponent<MimicMovement>() != null)
                                {
                                    wim.GetComponent<MimicMovement>().enabled = false;
                                    wim.GetComponent<Mode6>().enabled = false;
                                    wim.GetComponent<Mode8>().enabled = false;
                                }
                            }

                            foreach (GameObject room in roomObjects)
                            {
                                if (room.GetComponent<MimicMovement>() != null)
                                {
                                    room.GetComponent<MimicMovement>().enabled = true;
                                }
                            }
                        } else if (this.name.Equals("Mode 8"))
                        {
                            currentMode = 8;

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
