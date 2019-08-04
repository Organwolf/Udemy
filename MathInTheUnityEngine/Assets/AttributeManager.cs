using System;
using UnityEngine;
using UnityEngine.UI;

public class AttributeManager : MonoBehaviour
{
    // Attributes
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    // Key values
    static public int BLACK_KEY = 16;
    static public int RED_KEY = 0;
    static public int GREEN_KEY = 4;


    public Text attributeDisplay;
    public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MAGIC")
        {
            attributes |= MAGIC;
        }
        else if (other.gameObject.tag == "CHARISMA")
        {
            attributes |= CHARISMA;
        }
        else if (other.gameObject.tag == "INVISIBLE")
        {
            attributes |= INVISIBLE;
        }
        else if (other.gameObject.tag == "MULTIADD")
        {
            attributes |= (INVISIBLE | MAGIC | CHARISMA);
        }
        else if (other.gameObject.tag == "MULTIREMOVE")
        {
            attributes &= (INVISIBLE | MAGIC | CHARISMA);
        }
        else if (other.gameObject.tag == "BLACK_KEY")
        {
            attributes |= BLACK_KEY;
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
