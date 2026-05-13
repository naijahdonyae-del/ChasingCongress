using UnityEngine;
using UnityEngine.AI;

public class NPCRunning : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;

    [SerializeField] private Animator _animator;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        

      //  Debug.Log("Distance " + distance);

        if(distance > EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;


            Vector3 newPos = transform.position + dirToPlayer;

           

            _agent.SetDestination(newPos);  
        }

        if (EnemyDistanceRun == 4.0f)
        {
            _animator.SetBool("OnRun1", true);
        }
        else if (EnemyDistanceRun == 8.0f)
        {
            _animator.SetBool("OnRun1", false);
        }
    }
}
