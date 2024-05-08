using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsInputController : MonoBehaviour
{
    public Vector2 getMoveAxis()
    {
        // Use the names you set up in the Input Manager for your joystick axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector2(horizontal, vertical).normalized;
    }

    public Vector2 getMouseAxis()
    {
        return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
