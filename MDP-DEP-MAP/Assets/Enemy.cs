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
    public Camera mainCamera;

    float timer;
    int waitingTime;

    public bool stun=false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audiosourece = GetComponent<AudioSource>();
        navAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
        timer = 0f;
        waitingTime = 3;
        animator.SetBool("IS_STUN", false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (stun == false)
        {
            freezevelocity();
            navAgent.SetDestination(target.position);
        }else if (stun == true){
            navAgent.Stop();
            animator.SetBool("IS_STUN", true);
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                timer = 0;
                stun = false;
                animator.SetBool("IS_STUN", false);
            }
        }
    }

    void freezevelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void navstop()
    {
        this.navAgent.isStopped = true;
    }

    void navgo()
    {
        this.navAgent.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("CATCH");
            audiosourece.clip = catch_audio;
            audiosourece.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("¿‚æ“¥Á");
            kill_player();
        }
    }

    public void kill_player()
    {

        mainCamera.transform.position = player_kill_pos.position;
        mainCamera.transform.eulerAngles = new Vector3(0, player_kill_pos.eulerAngles.y -200.0f, 0);

    }
}
