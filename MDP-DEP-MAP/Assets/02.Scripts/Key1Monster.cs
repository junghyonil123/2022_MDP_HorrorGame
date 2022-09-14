using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class Key1Monster : MonoBehaviour
{
    public Transform playerTransform;
    public Transform target;
    public Transform playerKillPos;
    public Transform foodTransform;

    public NavMeshAgent navAgent;

    private Rigidbody rigid;

    private Animator animator;

    private AudioSource audioSourece;

    public AudioClip catchAudio;
    public AudioClip walkAudio;
    public AudioClip haulAudio;

    public GameObject mainCamera;
    public GameObject subCamera;
    public GameObject food;

    public bool stun = false;
    public bool can_stun = false;
    public bool isCanFindFood = true;
    public int brain_count = 0;

    float timer;
    int waitingTime;

    private void Awake()
    {
        target = playerTransform;
        animator = GetComponent<Animator>();
        audioSourece = GetComponent<AudioSource>();
        navAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();

        navstop(); // 시작할때 플레이어 추적을 멈춤

        timer = 0f;
        waitingTime = 3;
        animator.SetBool("IsStun", false);

    }

    public IEnumerator Eat(Transform target)
    {
        transform.position -= new Vector3(0f, -1.5f, 0f);

        for (int i = 0; i < 100; i++)
        {
            target.position = foodTransform.position;
            yield return null;
        }
        yield return new WaitForSeconds(2f);
    }

    public void EatFinish()
    {
        Debug.Log("실행되쩌염");
        Destroy(food);
        isCanUseEat = true;
        isCanFindFood = true;
        brain_count += 1;
        if(brain_count == 3)
        {
            animator.SetBool("brain",true);
            animator.SetBool("CatchKey", false);
            navstop();
        }
        target = playerTransform;
    }

    public void navgo()
    {
        Debug.Log("출발합니다");
        navAgent.isStopped = false;
        can_stun = true;
    }

    public void navstop()
    {
        navAgent.isStopped = true;
    }

    public void AudioSet_Houl()
    {
        //하울링 

        audioSourece.clip = haulAudio;
        if(!audioSourece.isPlaying)
            audioSourece.Play();
        HeadLotate.instance.HeadRotate_Finish();
    }

    public void AudioSet_Walk()
    {
        // 걷는소리

        audioSourece.clip = walkAudio;
        if (!audioSourece.isPlaying)
            audioSourece.Play();
    }

    public void AudioSet_catch()
    {
        //플레이어 kill 소리

        audioSourece.clip = catchAudio;
        if (!audioSourece.isPlaying)
            audioSourece.Play();
    }

    void freezevelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    float stunCoolTime = 0f;

    void Update()
    {
        stunCoolTime += Time.deltaTime;
        if (can_stun)
        {
            if (stun == false)
            {
                //스턴 상태가 아니라면 플레이어를 추적

                //freezevelocity();
                    navAgent.SetDestination(target.position);
            }
            else if (stun == true)
            {
                if (stunCoolTime >= 10f)
                {
                    //스턴 상태라면 정지, WaitingTime후 움직임


                    navAgent.isStopped = true;
                    animator.SetBool("IsStun", true);
                    audioSourece.Stop();

                    timer += Time.deltaTime;
                    if (timer > waitingTime)
                    {
                        timer = 0;
                        stun = false;
                        animator.SetBool("IsStun", false);
                    }
                }
            }
        }
    }

    public bool isCanUseEat = true;
    public bool isCanKill = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCanKill)
        {
            //플레이어와 닿았다면 killPlayer를 실행
            isCanKill = false;
            audioSourece.Stop();
            animator.SetTrigger("CatchPlayer");
            AudioSet_catch();
            StartCoroutine("killPlayer");
        }
        if (other.gameObject.tag == "Food" && isCanUseEat)
        {
            isCanUseEat = false;
            audioSourece.Stop();
            animator.SetTrigger("Eat");
            StartCoroutine(Eat(other.transform));
            food = other.gameObject;
        }
        else if (other.gameObject.tag == "Flash")
        {
            stun = true;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Food")
    //    {
    //        Debug.Log("뇌만졋어용");
    //    }
    //}

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
        subCamera.SetActive(false);
    }

   
}



