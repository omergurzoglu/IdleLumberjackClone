

using DG.Tweening;
using TMPro;

using UnityEngine;

public  class WoodScore : MonoBehaviour
{
    private TextMeshProUGUI _thisText;
    private void Awake()
    {
        _thisText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameEvents.instance.IncrementWoodScore += CurrentScore;
    }

    private void OnDisable()
    {
        GameEvents.instance.IncrementWoodScore -= CurrentScore;
    }

    private void CurrentScore()
    {
        _thisText.text = CarryManager.instance.logsInBack.Count.ToString();
        transform.DORewind ();
        transform.DOPunchScale (new Vector3 (1, 1, 1), .25f);
    }
    

}