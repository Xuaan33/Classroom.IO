using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleports : MonoBehaviour
{
    FpsInputController fpsInputController;

    public GameObject player;
    public float speed = 5f;


    private void Awake()
    {
        fpsInputController = GetComponent<FpsInputController>();
    }
   /* void Update()
    {
        float x =  fpsInputController.getMoveAxis().x;
        float z =  fpsInputController.getMoveAxis().y;

        transform.position += new Vector3(x, 0f, z) * speed * Time.deltaTime;

    }*/

    public void OnCollisionEnter(Collision collision)
    {
        //Portal to lecture
        if(collision.gameObject.tag == "ToLecture")
        {
            player.transform.position = new Vector3(-1620, 1170, 1080);
        }

        //Portal To Class
        if (collision.gameObject.tag == "ToClass")
        {
            player.transform.position = new Vector3(189, 1170, 454);
        }

        if(collision.gameObject.tag == "ToClass2")
        {
            player.transform.position = new Vector3(-25, 1170, 344);
        }

        //Portal to Garden
        if (collision.gameObject.tag == "ToGarden")
        {
            player.transform.position = new Vector3(-1136, 1170, 561);
        }

    }

}
