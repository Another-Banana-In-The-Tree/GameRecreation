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

    protected GameObject player;
    /*void Start()
    {
        Init();
        Debug.Log("test");
    }*/

    public virtual void Init()
    {
       // Debug.Log("targetSet");
        target = wayPoints[0].position;
        player = GameObject.Find("Player");
    }

    // Update is called once per  voidframe
    


    public virtual IEnumerator SetTarget(Vector3 position)
    {
       // Debug.Log("set target wait");
        settingTarget = true;
        yield return new WaitForSeconds(waitTime);
       // Debug.Log("ended wait");
        settingTarget = false;
        target = position;
        FaceTowards(position - transform.position);
    }

    public virtual void FaceTowards(Vector3 direction)
    {
        if (direction.x > 0f)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }else transform.localEulerAngles = new Vector3(0, 0, 0);
    }


    
    public virtual void Movement()
    {
        if (patrolling)
        {
            Patrolling();
        }
        else
        {
            LinearPath();
        }
    }

    public virtual void StopPatrolling()
    {
        patrolling = !patrolling;
    }
    public virtual void Patrolling()
    {
        if (!settingTarget)
        {
            velocity = ((transform.position - previousPosition) / Time.deltaTime);
            previousPosition = transform.position;

            if (transform.position.x != target.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            }
            else
            {
                //Debug.Log("Reached Target");
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

    public virtual void LinearPath()
    {

    }
    
}