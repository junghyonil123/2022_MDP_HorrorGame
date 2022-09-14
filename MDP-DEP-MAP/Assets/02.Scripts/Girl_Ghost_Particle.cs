using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_Ghost_Particle : MonoBehaviour
{
    private ParticleSystem particle;
    public GameObject obj;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(obj != null)
            transform.position = obj.transform.position;
    }

    public IEnumerator Particle_Start()
    {
        Debug.Log("Çª¿Í¿À¿Í¾Ç");
        particle.Play();
        yield return new WaitForSeconds(3f);
        particle.Stop();
    }
}
