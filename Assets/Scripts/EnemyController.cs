using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 8f;
    //set health
    public float health = 3f;
    //Patrol routes
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;


    private GameBehavior _gameManager;

    Transform target;
    NavMeshAgent agent;

    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource enemyHitSound;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius )
        {
            agent.SetDestination(target.position);
            //start shooting at player
        }
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }

    }

    //Patrol function
    void InitializePatrolRoute()
    {
        foreach(Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        agent.destination = Locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }

    //takes damage whenever player hits enemy
    public void TakeDamage(float amount)
    {
        enemyHitSound.Play();
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        _gameManager.kills += 1;
        
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Lost a health!");
            _gameManager.HP -= 1;
            hitSound.Play();
        }
    }

}
