using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;
public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navAgent;
    public Transform player_kill_pos;
    private Rigidbody rigid;
    private Animator animator;
    private AudioSource audiosourece;
    public AudioClip catch_audio;
    public GameObject mainCamera;
    public GameObject subCamera;

    float timer;
    int waitingTime;

    public bool isStartStop;

    public bool stun=false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audiosourece = GetComponent<AudioSource>();
        navAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        if(isStartStop)
        navstop();
    }

    private void Start()
    {
        
        timer = 0f;
        waitingTime = 3;
        animator.SetBool("IsStun", false);

    }

    public void Houl()
    {
        audiosourece.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stun == false)
        {
        
            freezevelocity();
            navAgent.SetDestination(target.position);
        }
        //else if (stun == true){
        //    navAgent.Stop();
        //    //animator.SetBool("IS_STUN", true);
        //    timer += Time.deltaTime;
        //    if (timer > waitingTime)
        //    {
        //        timer = 0;
        //        stun = false;
        //        //animator.SetBool("IS_STUN", false);
        //    }
        //}
    }

    void freezevelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    public void navstop()
    {
        this.navAgent.isStopped = true;
    }

    public void navgo()
    {
        Debug.Log("출발합니다");
        this.navAgent.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //animator.settrigger("catch");
            //audiosourece.clip = catch_audio;
            //audiosourece.play();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("잡았당");
            kill_player();
        }
    }


    public void kill_player()
    {
        mainCamera.SetActive(false);
        subCamera.SetActive(true);
        transform.localScale = new Vector3(1.5f, 1.5f, 0f);
        subCamera.transform.position = player_kill_pos.position + new Vector3(0f,0f,0.5f);
        subCamera.transform.eulerAngles = new Vector3(0, player_kill_pos.eulerAngles.y - 200.0f, 0);
    }
}
