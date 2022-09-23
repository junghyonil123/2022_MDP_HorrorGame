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

    public bool isLightOn = false;

    int waitingTime;

    void Awake()
    {
        toggleReferenc.action.started += Toggle;
        gameObject.SetActive(false);
        col = GetComponent<BoxCollider>();
        enemy = FindObjectOfType<Enemy>();
    }
    void OnEnable()
    {
        isCoroutineUsed = false;
    }

    public bool isCoroutineUsed = false;
   
    private void Toggle(InputAction.CallbackContext context)
    {
        isLightOn = !gameObject.activeSelf;
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
