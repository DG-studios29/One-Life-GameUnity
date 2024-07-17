using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    Animator anim; // Assuming you have an animator for enemy animations

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>(); // Initialize your animator
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // Check if the player is within the look radius
        if (distance <= lookRadius)
        {
            // Check if the player is visible to the enemy
            if (IsPlayerVisible())
            {
                agent.SetDestination(target.position);
                anim.SetBool("isWalking", true);

                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    // Attack code here
                    // Example: Trigger attack animation
                    //anim.SetTrigger("Attack"); // Adjust "Attack" to your animation trigger name
                }
            }
            else
            {
                // Player is not visible, stop chasing
                agent.ResetPath(); // Stop moving towards the player
                anim.SetBool("isWalking", false);
            }

            
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
    }

    bool IsPlayerVisible()
    {
        // Implement your visibility check logic here
        // Example: Use Raycasting to check line of sight
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit, lookRadius))
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true; // Player is visible
            }
        }
        return false; // Player is not visible

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
