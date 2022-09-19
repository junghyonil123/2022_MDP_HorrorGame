using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class Key2Monster : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navAgent;
    public Transform playerKillPos;
    private Rigidbody rigid;
    private Animator animator;
    private AudioSource audiosourece;
    public AudioClip catch_audio;
    public AudioClip laugh;
    public AudioClip cry_audio;
    public AudioClip landing;
    public GameObject mainCamera;
    public GameObject subCamera;
    public Avatar avatar;
    private bool isCanKill = true;

    public bool isKilling = false;
    public float dmg_Timer;
    public bool awakeSuccess = false;

    private void OnEnable()
    {
        
        audiosourece.Play();
        StartCoroutine("Wake");
    }

    IEnumerator Wake()
    {
        audiosourece.Play();
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < 100; i++)
        {

            transform.localScale += new Vector3(0f, 0f, 0.015f);
            transform.position += (new Vector3(0f, 0f, 0.004f));

            yield return null;

        }

        animator.avatar = avatar;
        animator.SetBool("isWalk", true);
        navAgent.isStopped = false;
        awakeSuccess = true;

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audiosourece = GetComponent<AudioSource>();
        navAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        navAgent.isStopped = true;
    }

    float stun_Timer = 0;
    public float stunTime = 3;
    public bool stun = false;

    void freezevelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        if (stun == false)
        {
            freezevelocity();
            navAgent.SetDestination(target.position);
        }

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && isCanKill)
        {
            isKilling = true;
            isCanKill = false;
            audiosourece.clip = catch_audio;
            audiosourece.Play();
            StartCoroutine(killPlayer());
            animator.SetBool("isWalk", false);
            navAgent.isStopped = true;
        }
    }



    IEnumerator killPlayer()
    {
        mainCamera.SetActive(false);
        subCamera.SetActive(true); //subCamera사용

        //subCamera를 지속적으로 몬스터의 앞으로 이동시킴, 몬스터가 플레이어를 무는듯한 효과

        for (int i = 0; i < 150; i++)
        {
            subCamera.transform.position = playerKillPos.position + new Vector3(0f, 0f, 0f);
            subCamera.transform.eulerAngles = new Vector3(0, playerKillPos.eulerAngles.y, 0);
            yield return null;
        }
        GameOverCanvas.instance.die();
        Destroy(gameObject);
    }

    public  bool is_can_hit = true;

    public void CanHit()
    {
       is_can_hit = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Flash" && awakeSuccess && !isKilling)
        {
            navAgent.isStopped = true;

            dmg_Timer += Time.deltaTime;
            if (dmg_Timer >= 3)
            {
                Destroy(gameObject);
            }

            if (is_can_hit)
            {
                is_can_hit = false; //flag
                audiosourece.clip = cry_audio;      //오디오 우는걸로변경 
                audiosourece.Play();
                animator.avatar = null;         //애니메이션 동작을 위한 아바타 삭제
                animator.SetTrigger("isDamaged");
            }
        }
    }

    public void NotDie()
    {
        dmg_Timer = 0;
        audiosourece.clip = laugh;  //오디오 원래대로 돌리기
        audiosourece.Play();
        animator.avatar = avatar;
        animator.SetBool("isWalk", true);
        navAgent.isStopped = false;
        is_can_hit = true;
    }
}
