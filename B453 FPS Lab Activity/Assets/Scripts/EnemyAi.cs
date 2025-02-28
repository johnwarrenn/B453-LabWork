using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAi : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float stoppingDistance = 5f;

    [SerializeField, Min(5)] float attackRange = 5f;

    public GameObject[] waypoints;
    private int waypointIndex = 0;

    private NavMeshAgent agent;
    private Transform player;
    private RaycastHit scan;
    private Coroutine walk;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * attackRange, Color.red, 0.1f);

        if (Physics.Raycast(transform.position, transform.forward, out scan, attackRange))
        {
            if (scan.collider.CompareTag("Player"))
            {
                Move();
                Attack();
            }
                
        }
        else
        {
            StartCoroutine(Patrol());
            
        }
    }

    private void Move()
    {
        agent.SetDestination(player.position);
    }

    private IEnumerator<int> Patrol() 
    {
        if (waypointIndex >= waypoints.Length)
                {
                waypointIndex = 0;
                }

        agent.SetDestination(waypoints[waypointIndex].transform.position);

        yield return waypointIndex++;
    }

    private void Attack()
    {
        transform.LookAt(player);

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * attackRange, Color.magenta, 0.1f);

        if(Physics.Raycast(transform.position,transform.forward, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Haha");
            }
        }
    }
}
