using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
 {
     public Transform playerTr;
     private Transform zombieTr;
     public float distance = 3.0f;
     public float height = 3.0f;
     public float damping = 5.0f;
     private Vector3 followPosition;
 
     void Awake()
     {
         zombieTr = this.transform;
     }
     
     void Update () 
     {
        Follow();
     }
      
     private void Follow()
     {
         //Transforms the position x, y, z from local space to world space.
         followPosition = playerTr.TransformPoint(0, height, -distance);
         //Lerp the zombie towards the followPosition.
         zombieTr.position = Vector3.Lerp (zombieTr.position, followPosition, Time.deltaTime * damping);
      }
 }