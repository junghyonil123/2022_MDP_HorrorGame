using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class flash : MonoBehaviour
{ 
    BoxCollider col;
    Enemy enemy;

    public InputActionReference toggleReferenc = null;

    public GameObject batteryBar;

    public float currentEnergy;
    public float maxEnergy = 30;

    public bool isLightOn = false;

    int waitingTime;

    void Awake()
    {
        currentEnergy = maxEnergy;
        toggleReferenc.action.started += Toggle;
        gameObject.SetActive(false);
        col = GetComponent<BoxCollider>();
        enemy = FindObjectOfType<Enemy>();
    }


    void OnEnable()
    {
        isCoroutineUsed = false;
        StartCoroutine(useEnergy());
    }

    public bool isCoroutineUsed = false;
    IEnumerator useEnergy()
    {
        while (true)
        {
            if (isLightOn)
            {
                currentEnergy -= 0.01f;
                batteryBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30 * currentEnergy / maxEnergy, 0f);
                
            }

            if (currentEnergy <= 0)
            {
                isLightOn = false;
                gameObject.SetActive(false);
            }
            else if(currentEnergy <= 10)
            {
                if (!isCoroutineUsed)
                {
                    StartCoroutine("blink");
                }
                
                batteryBar.GetComponent<Image>().color = new Color(255, 0, 0); //빨간색
            }
            else if (currentEnergy <= 20)
            {
                batteryBar.GetComponent<Image>().color = new Color(255, 255, 0); //노란색
            }
            else
            {
                batteryBar.GetComponent<Image>().color = new Color(0, 255, 0); //초록색
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator blink()
    {
        while (true)
        {
            isCoroutineUsed = true;
            if (currentEnergy > 10)
            {
                isCoroutineUsed = false;
                yield break;
            }
                

            batteryBar.GetComponent<Image>().color = new Color(255, 0, 0, 0);
            yield return new WaitForSeconds(0.5f);
            batteryBar.GetComponent<Image>().color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void Toggle(InputAction.CallbackContext context)
    {
       
        isLightOn = !gameObject.activeSelf;
        gameObject.SetActive(!gameObject.activeSelf);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemy.stun = true;
        }
    }


}
