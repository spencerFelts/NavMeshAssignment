using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class ClickToMove : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public Text livesLeft;
    public Text scoreText;
    private int count = 0;
    public static int lives = 3;

    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }

        if (lives <= 0)
        {
            livesLeft.text = "Lives: 0";
        } else
        {
            livesLeft.text = "Lives: " + lives.ToString();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Points")
        {
            other.gameObject.SetActive(false);
            count += 10;
            scoreText.text = "Score: " + count;
        }
    }

}
