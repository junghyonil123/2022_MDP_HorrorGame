using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Action : MonoBehaviour
{
    public GameObject girlToiletLight;
    public GameObject girlDoll;
    public GameObject girlToiletDoor;
    public AudioSource audio;

    public bool IsPlayerIn = false;
    public bool isTricked = false;
    public float coolTime = 1f;
    public float substractValue = 0.4f;

    public AudioClip kkkwang;
    IEnumerator DoorOff()
    {
        
        while (girlToiletDoor.transform.rotation.y > -0.70f)
        {Debug.Log(girlToiletDoor.transform.rotation.y);
            girlToiletDoor.transform.Rotate(new Vector3(0, -(100f / 60f), 0));
            yield return null;
        }
    }

    IEnumerator LightControl()
    {
        LightOn();
        yield return new WaitForSeconds(5f);

        StartCoroutine("DoorOff");
        girlToiletDoor.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        girlToiletDoor.GetComponent<AudioSource>().clip = kkkwang;
        girlToiletDoor.GetComponent<AudioSource>().Stop();
        girlToiletDoor.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(3f);
        LightOff();
        yield return new WaitForSeconds(1f);
        LightOn();
        yield return new WaitForSeconds(0.7f);
        LightOff();
        yield return new WaitForSeconds(0.7f);
        LightOn();
        yield return new WaitForSeconds(0.7f);
        LightOff();
        yield return new WaitForSeconds(0.7f);
        LightOn();
        yield return new WaitForSeconds(0.3f);
        LightOff();
        yield return new WaitForSeconds(0.3f);
        LightOn();
        yield return new WaitForSeconds(0.3f);
        LightOff();
        yield return new WaitForSeconds(0.3f);
        LightOn();
        yield return new WaitForSeconds(0.1f);
        LightOff();
        yield return new WaitForSeconds(0.1f);


        for (int i = 0; i < 13; i++)
        {
            LightOn();
            yield return new WaitForSeconds(0.05f);
            LightOff();
            yield return new WaitForSeconds(0.05f);
        }

        girlDoll.SetActive(true);
        girlToiletLight.SetActive(true);


    }
    public void LightOn()
    {
        girlToiletLight.SetActive(true);
        audio.Stop();
        audio.Play();
    }

    public void LightOff()
    {
        girlToiletLight.SetActive(false);
        audio.Stop();
        audio.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && !isTricked)
        {
            isTricked = true; //한번이라도 트리거enter를 했다면 실행안되게하는 함수
            IsPlayerIn = true; //플레이어가 들어옴을 알려줌
            
            StartCoroutine("LightControl");
        }
        
    }

}
