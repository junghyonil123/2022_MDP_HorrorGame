using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Action : MonoBehaviour
{
    public static Key2Action instanse;

    private void Awake()
    {
        if(instanse == null)
        {
            instanse = this;
        }
    }

    public GameObject girlToiletLight;
    public GameObject girlToiletSpotLight;
    public GameObject girlGhost;
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

       
        girlToiletLight.SetActive(false);
        girlToiletSpotLight.SetActive(true);
        girlGhost.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine("GhostGirlAwake");

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

    IEnumerator GhostGirlAwake()
    {
        for (int i = 0; i < 100; i++)
        {
            girlGhost.transform.localScale += new Vector3(0f, 0f, 0.015f);
            girlGhost.transform.Rotate(new Vector3(0f, 0f, 0.02f));
            yield return null;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && !isTricked)
        {
            isTricked = true; //�ѹ��̶� Ʈ����enter�� �ߴٸ� ����ȵǰ��ϴ� �Լ�
            IsPlayerIn = true; //�÷��̾ ������ �˷���
            
            StartCoroutine("LightControl");
        }
        
    }

}
