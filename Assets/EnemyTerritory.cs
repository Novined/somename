using UnityEngine;
using System.Collections;

public class EnemyTerritory : MonoBehaviour
 {
         public BoxCollider2D territory;
         GameObject player;
         bool playerInTerritory;
 
         public GameObject enemy;
		 Enemy basicenemy;
 
         // Use this for initialization
         void Start ()
         {
             player = GameObject.FindGameObjectWithTag ("Player");
             basicenemy = enemy.GetComponent <Enemy> ();
             playerInTerritory = false;
         }
     
         // Update is called once per frame
         void Update ()
         {
             if (playerInTerritory = true)
             {
                 basicenemy.MoveToPlayer ();
             }
 
             if (playerInTerritory = false)
             {
                 basicenemy.Rest ();
             }
         }
 
         void OnTriggerEnter (Collider other)
         {
             if (other.gameObject == player)
             {
                 playerInTerritory = true;
             }
         }
     
         void OnTriggerExit (Collider other)
         {
             if (other.gameObject == player) 
             {
                     playerInTerritory = false;
             }
         }
 }
 