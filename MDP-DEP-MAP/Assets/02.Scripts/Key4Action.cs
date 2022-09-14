using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Key4Action : MonoBehaviour
{
    public List<GameObject> portraitLightList = new List<GameObject>();
    
    public bool isPass = false;
    public bool isPass_2 = false;

    public GameObject jingjing_1;
    public GameObject jingjing_2;
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
            jingjing_2.SetActive(true);
            jingjing_2.GetComponent<AudioSource>().Play();
            StartCoroutine(DestroyJingJing2());
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
        yield return new WaitForSeconds(5f);
        

        for (int i = 0; i < 200; i++)
        {
            jingjing_2.transform.position -= new Vector3(0f, -0.05f, 0f);
            yield return null;
        }

        Destroy(jingjing_2);
    }
}
