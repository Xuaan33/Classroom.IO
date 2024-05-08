using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }


    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;

    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
             Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRB.MovePosition(newPosition);
        }
    }

    

}
