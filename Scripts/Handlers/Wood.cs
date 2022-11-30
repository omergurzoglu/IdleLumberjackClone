
using UnityEngine;

public class Wood : MonoBehaviour
{
    private void OnDisable()
    {
        CarryManager.instance.logsInBack.Remove(transform);
    }
}
