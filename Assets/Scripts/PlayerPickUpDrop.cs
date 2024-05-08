using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    private ObjectGrabable objectGrabable;
    public Button pickDropButton; // Assign your button in the Unity Editor

    private void Start()
    {
        // Attach the button click event handler
        pickDropButton.onClick.AddListener(HandlePickDropButtonClick);
    }

    private void HandlePickDropButtonClick()
    {
        if (objectGrabable == null)
        {
            // not carrying object, try to grab
            float pickUpDistance = 2f;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, pickUpDistance, pickUpLayerMask))
            {
                if (hit.transform.TryGetComponent(out objectGrabable))
                {
                    objectGrabable.Grab(objectGrabPointTransform);
                }
            }
        }
        else
        {
            // currently grabbing things and drop
            objectGrabable.Drop();
            objectGrabable = null;
        }
    }
}