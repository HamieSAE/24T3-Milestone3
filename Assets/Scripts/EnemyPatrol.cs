using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Chase
    }

    public State currentState;
    public Transform[] patrolPoints;
    public Transform player;
    public float chaseRange = 10f;
    public float loseChaseRange = 15f;
    public string sceneToLoad; // Name of the scene to load on collision

    private int currentPatrolPointIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = State.Patrol;
        SetDestinationToNextPatrolPoint();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                CheckForChase();
                break;

            case State.Chase:
                Chase();
                CheckForPatrol();
                break;
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.1f)
        {
            SetDestinationToNextPatrolPoint();
        }
    }

    void Chase()
    {
        agent.SetDestination(player.position);
    }

    void CheckForChase()
    {
        if (Vector3.Distance(transform.position, player.position) < chaseRange)
        {
            currentState = State.Chase;
        }
    }

    void CheckForPatrol()
    {
        if (Vector3.Distance(transform.position, player.position) > loseChaseRange)
        {
            currentState = State.Patrol;
            SetDestinationToNextPatrolPoint();
        }
    }

    void SetDestinationToNextPatrolPoint()
    {
        agent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
        currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
