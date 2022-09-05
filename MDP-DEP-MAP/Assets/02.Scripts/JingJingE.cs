using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingJingE : MonoBehaviour
{
    public GameObject jingjing2;


    public void move()
    {
        StartCoroutine(MoveCoroutine());
    }
    public IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < 200; i++)
        {
            transform.position += new Vector3(0.02f, 0f, 0f);
            yield return null;
        }
        jingjing2.SetActive(true);
    }
}
