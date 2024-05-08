using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Transform player;
    public Transform minimapOverlay;
    public float angle;
   // private GameObject[] otherPlayers;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //otherPlayers = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + Vector3.up * 5f;
        RotateOverlay();
    }

    private void HandlePlayerVisible()
    {
        //for(int i =0; i < otherPlayers.Length; i++)
        {

        }
    }

    private void RotateOverlay()
    {
        minimapOverlay.localRotation = Quaternion.Euler(0, 0, -player.eulerAngles.y - angle);
    }
}
