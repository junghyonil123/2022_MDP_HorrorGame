using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magicleake : MonoBehaviour
{
    public Text txet1;
    public Text trashText;

    private void OnCollisionEnter(Collision collision)
    {
        int trashCount = 0;

        if(collision.gameObject.tag == "Key1")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            txet1.text = "Á¤ÇöÀÏ 1/1";
        }
        
    }
}
