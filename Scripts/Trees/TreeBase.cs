
using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;


public abstract class TreeBase : MonoBehaviour,ITakeDamage
{
    protected int treeHealth;

    private void Start()
    {
        GameEvents.instance.ReduceTreeHealth += PowerUpReduceTreeHealth;
    }

    private void OnDisable()
    {
        GameEvents.instance.ReduceTreeHealth -= PowerUpReduceTreeHealth;
    }


    public void TakeDamage()
    {
        transform.DOShakeScale(0.3f, 0.9f, 20);
        treeHealth--;
        if (treeHealth <= 0)
        {
            transform.DOScale(Vector3.zero, 0.65f).SetEase(Ease.InBounce).OnComplete(KillTreeAndDrop);
            
        }
    }

    private void KillTreeAndDrop()
    {
        var drop =DropPool.instance.GetPooledWood();
        if (drop != null)
        {
            drop.SetActive(true);
            drop.transform.position = transform.position + Vector3.up;
            CarryManager.instance.Carry(drop.transform,CarryManager.instance.playerBackPos);
            CarryManager.instance.logsInBack.Add(drop.transform);
        }
        Player.DetectedTrees.Remove(transform);
        gameObject.SetActive(false);
        GameEvents.instance.UpdateWoodScore();
    }

    private void PowerUpReduceTreeHealth()
    {
        treeHealth--;
    }
}
