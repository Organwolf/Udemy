using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    int doorType = 0;

    void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.GetComponent<AttributeManager>().attributes & doorType) != 0)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;
        other.gameObject.GetComponent<AttributeManager>().attributes &= ~doorType;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "PURPLE_DOOR") doorType = AttributeManager.BLACK_KEY;
        if (gameObject.tag == "RED_DOOR") doorType = AttributeManager.RED_KEY;
        if (gameObject.tag == "GREEN_DOOR") doorType = AttributeManager.GREEN_KEY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
