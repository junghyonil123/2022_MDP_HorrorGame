using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Action : MonoBehaviour
{
    public GameObject girlToiletLight;
    public GameObject girlDoll;
    public GameObject girlToiletDoor;

    public bool IsPlayerIn = false;
    public bool IsLightOn = false;
    public bool isTricked = false;
    public float coolTime = 3f;

    public float substractValue = 0.2f;
    private void Update()
    {
        if(coolTime <= 0)
        {
            gameObject.SetActive(true);
            girlDoll.SetActive(true);
        }
        else if (IsPlayerIn)
        {
            Invoke("LightOnOff", coolTime);
            coolTime -= 0.1f;
        }
    }

    //IEnumerator void DoorOff()
    //{
      //  if(girlToiletDoor.transform.rotation.y <= -90)
      //  {
     //       girlToiletDoor.transform.Rotate(new Vector3(0, -(90f/60), 0));
     //       yield return WaitForSeconds(0.1f);
      //  }
  //  }

    public void LightOnOff()
    {
        IsLightOn = !IsLightOn;
        girlToiletLight.SetActive(IsLightOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("실행됫어염");
        if (other.gameObject.tag == "Player" && !isTricked)
        {
            Debug.Log("지나갓어염");
            isTricked = true; //한번이라도 트리거enter를 했다면 실행안되게하는 함수
            IsPlayerIn = true; //플레이어가 들어옴을 알려줌
        }
        
    }

}
