using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected float speed;

    protected Vector3 target;
    protected Vector3 velocity;
    protected Vector3 previousPosition;
    protected bool flipped = true;
    protected bool settingTarget = false;
    [SerializeField] protected Transform[] wayPoints;
    [SerializeField] protected float waitTime;
    [SerializeField] protected bool patrolling = true;

   // private Rigidbody2D rb;

    private WaitForSeconds waitCooldown;
    // [SerializeField]protected Camera cam;
    //[SerializeField] protected float sightRange;

    //protected GameObject player;
    /*void Start()
    {
        Init();
        Debug.Log("test");
    }*/

   

    public virtual void Init()
    {
        // Debug.Log("targetSet");

        waitCooldown = new WaitForSeconds(waitTime);
        target = wayPoints[0].position;
        
    }

    // Update is called once per  voidframe
    


    public virtual IEnumerator SetTarget(Vector3 position)
    {
       // Debug.Log("set target wait");
        settingTarget = true;
        yield return waitCooldown;
       // Debug.Log("ended wait");
        settingTarget = false;
        target = position;
        FaceTowards();
    }

    public virtual void FaceTowards()
    {
        if (flipped)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }else transform.localEulerAngles = new Vector3(0, 0, 0);
    }


    
    public virtual void Movement()
    {
        if (!settingTarget)
        {

            

            previousPosition = transform.position;

            if (transform.position.x != target.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

               
            }
            
            else
            {
                
                if (target == wayPoints[0].position)
                {
                    if (flipped)
                    {
                        //Debug.Log("hit left waypoint");
                        flipped = !flipped;
                        StartCoroutine("SetTarget", wayPoints[1].position);
                    }
                }
                else if (!flipped)
                {
                    //Debug.Log("Hit right waypoint");
                    flipped = !flipped;
                    StartCoroutine("SetTarget", wayPoints[0].position);
                }

            }
        }
    }

    public virtual void Spawned(Transform[] wayPointSet) 
    {
        wayPoints = wayPointSet;
    }
   
    public virtual void Die()
    {
        Debug.Log("whaaa");
        Destroy(gameObject);
    }
  
    
}
