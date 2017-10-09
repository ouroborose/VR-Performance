using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public static BallSpawner current;

    public GameObject pooledBall; //the prefab of the object in the object pool
    public int ballsAmount = 20; //the number of objects you want in the object pool
    public List<GameObject> pooledBalls; //the object pool
    public static int ballPoolNum = 0; //a number used to cycle through the pooled objects

    private float cooldown;
    private float cooldownLength = 0.5f;
    private Rigidbody ballRigidBody;

    void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
    }

    void Start()
    {
        //Create Ball Pool
        pooledBalls = new List<GameObject>();
        for (int i = 0; i < ballsAmount; i++)
        {
            GameObject obj = Instantiate(pooledBall);
            obj.SetActive(false);
            pooledBalls.Add(obj);
        }
    }

public GameObject GetPooledBall()
{
    ballPoolNum++;
    if (ballPoolNum > (ballsAmount - 1)) // if we've reached the last ball in the pool, go back to first one
    {
        ballPoolNum = 0;
    }

        //Debug.Log(ballPoolNum);
        return pooledBalls[ballPoolNum];
}
   	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = cooldownLength;
            SpawnBall();
        }	
	}

    void SpawnBall()
    {

        // run the BallSpawner's Get function and create reference to returned object
        GameObject selectedBall = BallSpawner.current.GetPooledBall();

        //manipulate postion of object
        selectedBall.transform.position = transform.position;
        Rigidbody selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
        selectedRigidbody.velocity = Vector3.zero;
        selectedRigidbody.angularVelocity = Vector3.zero;
        selectedBall.SetActive(true);
        
    }

    void deactivateBall()
    {
        // run the BallSpawner's Get function and create reference to returned object
        GameObject selectedBall = BallSpawner.current.GetPooledBall();

        //deactivate to recycle ball
        selectedBall.SetActive(true);
    }
}
