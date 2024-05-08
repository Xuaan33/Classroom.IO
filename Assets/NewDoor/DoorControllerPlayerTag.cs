using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerPlayerTag : MonoBehaviour
{
    Animator _Anim;
    public AudioSource DoorSound;
    public AudioSource DoorClose;



    // Start is called before the first frame update
    void Start()
    {
        _Anim = this.GetComponent<Animator>();

       //DoorSound = GetComponent<AudioSource>();
       // DoorClose = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Anim.SetTrigger("DoorTrigger");
            DoorSound.Play();
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Anim.SetTrigger("DoorTrigger");
            DoorClose.Play();
        }
    }
}
