using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public GameObject gameObject;
    public AudioClip runSound;
    public AudioClip runGrassSound;
    bool isGround = false;
    

    public void Steps()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            isGround = true;

            if(hit.transform.tag == "grass")
            {
                audio.PlayOneShot(runGrassSound);
            }else
                audio.PlayOneShot(runSound);


        }
        else
            isGround = false;

        
    }
}
