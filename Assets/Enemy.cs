using UnityEngine;
using System.Collections;

 
 public class Enemy : MonoBehaviour
{
		public GameObject target1;
		public Transform target;
         public float speed = 3000f;
         public float attack1Range = 1f;
         public int attack1Damage = 1;
         public float timeBetweenAttacks;
	public float Repulsion = 3;
		private int lifes;		// сколько раз босс задел игрока
		private bool ryadom;	// был ли рядом на предыдущей секунде игрок
 
 
         // Use this for initialization
         void Start ()
         {
             Rest ();
			 lifes = 3;
			 ryadom = false;
         }
     
         // Update is called once per frame
         void Update ()
         {
         }
 
         public void MoveToPlayer ()
         {
              //rotate to look at player
             //transform.LookAt (target.position);
			Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
			transform.rotation = new Quaternion(0, 0, 0, 0);
             //transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
         
             //move towards player
             if (Vector3.Distance (transform.position, target.position) > attack1Range) 
             {
				if (ryadom)
					ryadom = false;
				 var dir = target.position - transform.position;
				 dir = dir / dir.magnitude;
			Vector3 v = dir * speed * Time.deltaTime;
			Debug.DrawLine (gameObject.transform.position, transform.position + v);
			v.y = 0;
			gameObject.GetComponent<Rigidbody2D> ().AddForce ((Vector2)v, ForceMode2D.Impulse);
			} else {
			if (!ryadom) {
				if (lifes == 0) {
						// СМЕЕЕЕРТЬ ТВОЯ НАСТААААЛААААААААААА
				}
				ryadom = true;
				lifes--;
				Debug.Log ("рш");
				//target1.GetComponent<Rigidbody2D>().velocity *= - 2;
			}
	         }
		}
 
         public void Rest ()
         {
 
         }

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("Player")) {

			var dir = coll.transform.position - gameObject.transform.position;
			dir = dir / dir.magnitude;
			GetComponent<Rigidbody2D>().AddForce (-dir * coll.relativeVelocity.magnitude * Repulsion, ForceMode2D.Impulse);
		}
	}

 }