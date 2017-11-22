using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NO ROTATION
 * Rotation gives me a slight motion sickness, therefore for the player there is no rotation update, you have to rotate yourself
 */
public class PlayerMimic : MonoBehaviour
{

    // place on WIM object
    public GameObject otherObject; // the object in the room
    public Vector3 oldPosition;
    public int currentMode = 1;

    // Use this for initialization
    void Start()
    {
        Vector3 oldPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMode == 1)
        {
            otherObject.transform.localPosition = this.transform.localPosition;
        } else if (currentMode == 2)
        {
            //
        }
    }

    public void EnableMode2()
    {
        currentMode = 2;
    }

    // Wait for user to place replica of them, then update camera (no animation)
    public void SetMode2()
    {
        oldPosition = this.transform.localPosition;
        currentMode = 2;
        // So if the user moves the object, delay the camera movement (wait till the user has let go of it)
        Debug.Log("STARTING");
        StartCoroutine(MyCoroutine());

    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("WAINTING");
        yield return 360;    //Wait one frame
        otherObject.transform.localPosition = this.transform.localPosition;
    }
}
