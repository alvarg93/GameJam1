using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

	public GameObject spawnPoint;
	public float patrolSpeed = 2;
	public float chaseSpeed = 5;
	public float sightAngle = 30;
	public List<GameObject> route;

	private int currDest;
	private Rigidbody2D rbody;
	private float epsilon = 1E-2f;
	private GameObject player;

	void Start()
	{
		rbody = this.gameObject.GetComponent<Rigidbody2D>();
		currDest = 0;
		player = GameObject.FindGameObjectsWithTag("Player")[0];
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = this.gameObject.GetComponent<SpriteRenderer>().bounds.center;
		float dist = Vector2.Distance(pos, route[currDest].transform.position);

		if (dist < epsilon)
		{
			currDest = (currDest + 1) % route.Count;
		}

		Vector2 dirCurr = this.rbody.velocity.normalized;
		Vector2 dirOnRoute = (route[currDest].transform.position - pos).normalized;
		Vector2 dirToPlayer = (player.transform.position - pos).normalized;

		float angle = Vector2.Angle(dirCurr, dirToPlayer);
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dirToPlayer, Vector2.Distance(this.transform.position, dirToPlayer));

		if (Mathf.Abs(angle) <= sightAngle && (hit.collider == null || hit.collider.gameObject.tag == "Player"))
		{
			this.rbody.velocity = chaseSpeed * dirToPlayer;
		}
		else
		{
			this.rbody.velocity = patrolSpeed * dirOnRoute;
		}
	}
}
