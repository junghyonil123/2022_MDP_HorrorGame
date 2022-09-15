using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Key4Action : MonoBehaviour
{
    public List<GameObject> portraitLightList = new List<GameObject>();
    
    public bool isPass = false;
    public bool isPass_2 = false;

    public GameObject jingjing_1;
    public List<GameObject> jingjing_23456 = new List<GameObject>();
    public bool jingjing_1Touch = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isPass)
        {
            isPass = true;
            LightOn();
            jingjing_1.GetComponent<AudioSource>().Play();
        }

        if (jingjing_1Touch && !isPass_2)
        {
            isPass_2 = true;
            foreach (var item in jingjing_23456)
            {
                item.SetActive(true);
                item.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroyJingJing2());
            }
            
        }
    }

    public void LightOn()
    {
        foreach (var item in portraitLightList)
        {
            item.SetActive(true);
            item.GetComponent<AudioSource>().Play();
        }
    }

    public void LightOff()
    {
        foreach (var item in portraitLightList)
        {
            item.SetActive(false);
        }
    }
    
    public IEnumerator DestroyJingJing2()
    {
        yield return new WaitForSeconds(2f);
        

        for (int i = 0; i < 200; i++)
        {
            foreach (var item in jingjing_23456)
            {
                item.transform.position -= new Vector3(0f, -0.05f, 0f);
            }
            yield return null;
        }
        foreach (var item in jingjing_23456)
        {
            Destroy(item);
        }

    }
}
