
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
   [HideInInspector]public  Animator animator;
   [HideInInspector]public Rigidbody rb;
   public static readonly List<Transform> DetectedTrees = new();
   protected static readonly int IsMoving = Animator.StringToHash("IsMoving");
   protected static readonly int IsChopping = Animator.StringToHash("IsChopping");
   public Collider[] results;
   
   private void Awake()
   {
      results = new Collider[8];
      rb = GetComponent<Rigidbody>();
      animator = GetComponent<Animator>();
   }
}
