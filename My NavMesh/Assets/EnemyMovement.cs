using UnityEngine.AI;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemyAgent;

    public GameObject player;

    private void Start()
    {
        enemyAgent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        enemyAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            ClickToMove.lives--;
            Debug.Log("Collided with: " + other.name);
        }
    }
}
