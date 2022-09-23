using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {   Debug.Log(other.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Enter");
        }
    }
}
