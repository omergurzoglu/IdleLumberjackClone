

using System.Linq;
using JetBrains.Annotations;

using UnityEngine;

public class PlayerInteractions : Player
{
    private readonly Vector3 _colliderSize = Vector3.one * 3.4f;
    [SerializeField]private Transform hitArea;
   

    private void FixedUpdate()
    {
       Chop();
    }

    private void Chop()
    {
        if (DetectedTrees.Count > 0&& !animator.GetBool(IsMoving))
        {
            animator.SetBool(IsChopping,true);
            transform.LookAt(DetectedTrees.First());
        }
        else
        {
            animator.SetBool(IsChopping,false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DropArea>(out _))
        {
            GameEvents.instance.EnterDropArea();
        }
        if (!DetectedTrees.Contains(other.transform)&&other.CompareTag("Tree"))
        {
            DetectedTrees.Add(other.transform);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<DropArea>(out _))
        {
            GameEvents.instance.ExitDropArea();
        }
        if (other.CompareTag("Tree"))
        {
            DetectedTrees.Remove(other.transform);
        }
    }
    
   
    [UsedImplicitly]
    private void ChopTreeAnimEvent()
    {
        var size = Physics.OverlapBoxNonAlloc(hitArea.position, _colliderSize, results,Quaternion.identity,3);
        for (var i = 0; i < size; i++)
        {
            if (results[i].gameObject.TryGetComponent<ITakeDamage>(out var tree))
            {
                   tree.TakeDamage();
            }
        }
    }
   
}
  
    

