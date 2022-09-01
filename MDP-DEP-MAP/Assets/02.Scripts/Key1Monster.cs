using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class Key1Monster : MonoBehaviour
{
    public Transform playerTransform;
    public Transform target;
    public NavMeshAgent navAgent;
    public Transform playerKillPos;
    public Transform foodTransform;
    private Rigidbody rigid;
    private Animator animator;
    private AudioSource audioSourece;

    public AudioClip catchAudio;
    public AudioClip walkAudio;
    public AudioClip haulAudio;

    public GameObject mainCamera;
    public GameObject subCamera;
<<<<<<< Updated upstream
=======
    public GameObject food;
>>>>>>> Stashed changes

    public bool stun = false;
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

    IEnumerator Eat(Transform target)
    {
        
        transform.position -= new Vector3(0f, -1.5f, 0f);

        for (int i = 0; i < 100; i++)
        {
            target.position = foodTransform.position;
            yield return null;
        }
<<<<<<< Updated upstream
=======


        yield return new WaitForSeconds(2f);
        EatFinish();
>>>>>>> Stashed changes
    }

    public void EatFinish()
    {
<<<<<<< Updated upstream
        //뇌를 다먹었을때 진행되는 함수
        //뇌를 제거하고 플래그를 활성화시킴 
        //타겟을 플레이어로 바꿈
=======
        Debug.Log("실행되쩌염");
        Destroy(food);
        target = playerTransform;
>>>>>>> Stashed changes
    }

    public void navgo()
    {
        Debug.Log("출발합니다");
        navAgent.isStopped = false;
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

    void Update()
    {

        if (stun == false)
        {
            //스턴 상태가 아니라면 플레이어를 추적

            //freezevelocity();
            navAgent.SetDestination(target.position);
        }
        else if (stun == true)
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

    private bool isCanUseEat = true;
<<<<<<< Updated upstream
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //플레이어와 닿았다면 killPlayer를 실행

=======
    private bool isCanKill = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isCanKill)
        {
            //플레이어와 닿았다면 killPlayer를 실행
            isCanKill = false;
>>>>>>> Stashed changes
            animator.SetTrigger("CatchPlayer");
            AudioSet_catch();
            StartCoroutine("killPlayer");

        }

        if(other.gameObject.tag == "Food" && isCanUseEat)
        {
            isCanUseEat = false;
            animator.SetTrigger("Eat");
            StartCoroutine(Eat(other.transform));
<<<<<<< Updated upstream
=======
            food = other.gameObject;
>>>>>>> Stashed changes
        }
    }

    IEnumerator killPlayer()
    {
        mainCamera.SetActive(false);
        subCamera.SetActive(true); //subCamera사용

        //subCamera를 지속적으로 몬스터의 앞으로 이동시킴, 몬스터가 플레이어를 무는듯한 효과

        for (int i = 0; i < 20000; i++)
        {  
            subCamera.transform.position = playerKillPos.position + new Vector3(0f, 0f, 0f);
            subCamera.transform.eulerAngles = new Vector3(0, playerKillPos.eulerAngles.y, 0);
            yield return null;
        }
        
    }
}



