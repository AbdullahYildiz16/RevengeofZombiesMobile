using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum ZombieState
{
    Idle = 0,
    Walk = 1,
    Dead = 2,
    Attack =3
}

public class ZombieAI : MonoBehaviour
{
    // Idle
    // Walk
    // Attack
    // Dead
    AudioSource audio;
    
    public AudioClip bite;
    public AudioClip dead;
    

    public GameObject gameManager;
    

    Animator animator;
    NavMeshAgent agent;
    ZombieState zombieState;
    GameObject playerObject;
    PlayerHealth playerHealth;
    ZombieHealth zombieHealth;
    public float attackDistance;

    public int deadZombieNumber;

    void Start()
    {
        deadZombieNumber = 0;
        zombieHealth = GetComponent<ZombieHealth>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        
        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        

        
        if (zombieHealth.GetHealth() <= 0)
        {
            
            SetState(ZombieState.Dead);
        }

        switch (zombieState)
        {
            case ZombieState.Dead:
                audio.clip = dead;
                audio.Play(2);
                killZombie();
                break;
            case ZombieState.Attack:
                
                Attack();
                break;
            case ZombieState.Walk:
                
                SearchForTarget();
                break;
            case ZombieState.Idle:
                
                SearchForTarget();
                break;
            default:
                break;
    
        }
    }

    private void Attack()
    {
        SetState(ZombieState.Attack);
        agent.isStopped = true;

    }
    void MakeAttack()
    {
        // buraya zombi saldırı sesi koy!
        audio.clip = bite;
        audio.Play();
        playerHealth.DeductHealth(10);
        SearchForTarget();
    }

    private void SearchForTarget()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        if(distance < 1.5f)
        {
            Attack();
        }
        else if (distance < attackDistance)
        {
            
            MovetoPlayer();
            

        }
        else
        {
            SetState(ZombieState.Idle);
            agent.isStopped = true;
            
        }
    }

    private void SetState(ZombieState state)
    {
        zombieState = state;
        animator.SetInteger("state", (int)state);
    }

    private void MovetoPlayer()
    {
        
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position);
        SetState(ZombieState.Walk);
        
    }

    public void killZombie()
    {

        SetState(ZombieState.Dead);
        agent.isStopped = true;
        
        Destroy(gameObject,3);
        
    }
}
