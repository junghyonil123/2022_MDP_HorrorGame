using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Key4Action : MonoBehaviour
{
    public List<GameObject> portraitLightList = new List<GameObject>();
    public bool isPass = false;
    public GameObject jingjing1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isPass)
        {
            isPass = true;
            LightOn();
            jingjing1.GetComponent<AudioSource>().Play();
        }
    }

    public void LightOn()
    {
        foreach (var item in portraitLightList)
        {
            item.SetActive(true);
        }
    }

    public void LightOff()
    {
        foreach (var item in portraitLightList)
        {
            item.SetActive(false);
        }
    }
}
