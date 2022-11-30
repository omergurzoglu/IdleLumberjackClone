
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CarryManager : MonoBehaviour

{
    public List<Transform> logsInBack = new();
    public static CarryManager instance;
    public Transform playerBackPos;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Carry(Transform from, Transform to)
    {
        from.SetParent(to);
        from.DOLocalJump(new Vector3(0,(0.45f*logsInBack.Count),-0.5f), 3f, 1, 0.4f);
        from.localRotation = Quaternion.identity;
    }
}