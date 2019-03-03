using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatingDistance;
    public float timeBtwnShots;
    public float StartingTimeBtwnShots;

    public GameObject projectile;

    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwnShots = StartingTimeBtwnShots;

	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatingDistance)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, target.position) < retreatingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        if(timeBtwnShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwnShots = StartingTimeBtwnShots;
        }else
        {
            timeBtwnShots -= Time.deltaTime;
        }
    }
}
