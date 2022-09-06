using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorOpen : MonoBehaviour
{
    public GameObject obj;
    public float last_state = 1;
    public bool is_Open_Door = true;
    public void Open()
    {
        if (is_Open_Door == true)
        {
            Debug.Log("Open");
            obj.GetComponent<XRGrabInteractable>().enabled = false;
            StartCoroutine("DoorOff");
        }
    }

    IEnumerator DoorOff()
    {
        is_Open_Door = false;
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(0, 1 * last_state, 0));
            GetComponent<AudioSource>().Play();
            yield return null;
        }
        last_state *= -1;
        is_Open_Door = true;
        obj.GetComponent<XRGrabInteractable>().enabled = true;
        GetComponent<AudioSource>().Stop();
    }


}