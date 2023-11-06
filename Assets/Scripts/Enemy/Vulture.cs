using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulture : MonoBehaviour
{
    [SerializeField] private Rigidbody2D coconut;
    [SerializeField] private SpriteRenderer vultureRenderer;
    [SerializeField] private float coolDown;
    [SerializeField] private float timeBetweenRounds;
    [SerializeField] private Transform[] throwPoints = new Transform[3];
    private Vector2 dir;
    private int speed = 2;
    private int throwCount = 0;


    private void Start()
    {
        dir = Vector2.left;
        Throw();
        
    }

    private void Throw()
    {
        Debug.Log("throw");
       Rigidbody2D  thrownCoconut = Instantiate(coconut,throwPoints[throwCount].position, throwPoints[throwCount].rotation);
        thrownCoconut.gameObject.GetComponent<Coconut>().SetDirection(dir * speed, throwCount);
        thrownCoconut.AddForce((dir + Vector2.up*3) * speed, ForceMode2D.Impulse);
        throwCount++;
        if(throwCount <= 2)
        {
            Debug.Log("call corutine");
            StartCoroutine("ChangeDirection");
        }
        else
        {
            StartCoroutine("WaitNextRound");
        }
    }

    public IEnumerator ChangeDirection()
    {
        Debug.Log("corutine start");
        switch (throwCount)
        {
            case 0:
                dir = (Vector2.left);
                break;
            case 1:
                dir = Vector2.up;
                break;
            case 2:
                dir = Vector2.right;
                break;
        }

        yield return new WaitForSeconds(coolDown);
        Debug.Log("corutine end");
        Throw();

    }

    public IEnumerator WaitNextRound()
    {
        throwCount = 0;
        dir = Vector2.left;
        yield return new WaitForSeconds(timeBetweenRounds);
        Throw();
    }
}
