
using UnityEngine;
using UnityEngine.AI;
public class enemyController : MonoBehaviour
{
    public NavMeshAgent agent;

    Transform target;

    public LayerMask whatIsGround, whatIsPlayer;

    //timer
    float timer =0f;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //shoot
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public GameObject projectile;
    public Transform firePoint;

    
    private void Awake()
    {
        //target = playerManager.instance.player.transform;
        target =GameObject.Find("fpsPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        timer = timer + Time.deltaTime;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f || timer >=5f)
        {
            walkPointSet = false;
            timer = 0;
        }
            
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        Transform _target = target.GetChild(0).transform;
        transform.LookAt(_target);

        if(fireCountDown<=0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }

        fireCountDown -= Time.deltaTime;
        
    }

    void Shoot()
    {
       GameObject bulletG0=(GameObject) Instantiate(projectile, firePoint.position, firePoint.rotation);
        bullet bullet = bulletG0.GetComponent<bullet>();
        if (bullet != null)
            bullet.seek();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}