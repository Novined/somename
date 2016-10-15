using UnityEngine;
using System.Collections;

 
 public class Enemy : MonoBehaviour
 {
         public Transform target;
         public float speed = 3f;
         public float attack1Range = 1f;
         public int attack1Damage = 1;
         public float timeBetweenAttacks;
 
 
         // Use this for initialization
         void Start ()
         {
             Rest ();
         }
     
         // Update is called once per frame
         void Update ()
         {
             
         }
 
         public void MoveToPlayer ()
         {
             //rotate to look at player
             transform.LookAt (target.position);
             //transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
         
             //move towards player
             if (Vector3.Distance (transform.position, target.position) > attack1Range) 
             {
				 var dir = target.position - transform.position;
				 dir = dir / dir.magnitude;
                     transform.Translate (dir*speed * Time.deltaTime);
             }
         }
 
         public void Rest ()
         {
 
         }
 }