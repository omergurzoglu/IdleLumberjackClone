
using System;
using System.Collections;
using DG.Tweening;

using UnityEngine;

public class DropArea : MonoBehaviour
{
    private readonly WaitForSeconds _waitForSeconds = new (0.1f);
    private void OnEnable()
    {
        
        GameEvents.instance.OnDropArea += OnDropAreaCollectWood;
        GameEvents.instance.OffDropArea += OffDropAreaStop;
    }

    private void OnDisable()
    {
        
        GameEvents.instance.OnDropArea -= OnDropAreaCollectWood;
        GameEvents.instance.OffDropArea -= OffDropAreaStop;
    }

    private void OffDropAreaStop()
    {
        
        StopCoroutine(CollectWood());
    }

    private void OnDropAreaCollectWood()
    {
        
        StartCoroutine(CollectWood());
    }

    private IEnumerator CollectWood()
    {
        while (CarryManager.instance.logsInBack.Count > 0)
        {
            
            for (var i =CarryManager.instance.logsInBack.Count-1 ; i >= 0; i--)
            {
                    var currentWood = CarryManager.instance.logsInBack[i];
                    CarryManager.instance.logsInBack.Remove(currentWood.transform);
                    currentWood.transform.parent = null;
                    currentWood.transform.DOJump(transform.position, 4f, 1, 0.5f)
                        .OnComplete(() => currentWood.gameObject.SetActive(false));
                    GameEvents.instance.UpdateWoodScore();
                    GameEvents.instance.MoneyScorePlus(1);
                    yield return _waitForSeconds;
            }
        }
    }
}
