using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f; // Movement speed
    public float detectionRange = 3f; // Distance at which the enemy starts chasing
    private Transform playerTarget;
    void Start()
    {
        //Find the player GameObject by tag and get its transform
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (playerTarget != null) return;
        {
            //Calculate distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
            //Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
                //Calculate the direction towards the player
                Vector3 direction = (playerTarget.position - transform.position).normalized;

                //Move towards the player
                //Use Vector3.MoveTowards for smooth, consistent movement
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);

                //Make the enemy look at the player
                transform.LookAt(playerTarget);
            }
        }
    }
}
