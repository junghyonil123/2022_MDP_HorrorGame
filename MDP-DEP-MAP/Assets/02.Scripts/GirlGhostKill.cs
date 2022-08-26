using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlGhostKill : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public GameObject mainCamera;
    public GameObject subCamera;

    IEnumerator KillPlayer()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 0f);
        transform.Translate(player.position + offset);
        mainCamera.SetActive(false);
        subCamera.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        //Destroy(gameObject);
        //mainCamera.SetActive(true);
        //subCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            StartCoroutine("KillPlayer");
    }
}
