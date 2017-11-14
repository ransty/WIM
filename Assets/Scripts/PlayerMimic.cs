using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * NO ROTATION
 * Rotation gives me a slight motion sickness, therefore for the player there is no rotation update, you have to rotate yourself
 */
public class PlayerMimic : MonoBehaviour
{

    // place on WIM object
    public GameObject otherObject; // the object in the room

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        otherObject.transform.localPosition = this.transform.localPosition;
    }
}
