

using UnityEngine;

public class BuyArea : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.OpenShopUI();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.instance.CloseShopUI();
    }
    
    private void OnEnable()
    {
        GameEvents.instance.EnableShopUI += OpenShop;
        GameEvents.instance.DisableShopUI += CloseShop;
    }

    private void OnDisable()
    {
        GameEvents.instance.EnableShopUI -= OpenShop;
        GameEvents.instance.DisableShopUI -= CloseShop;
    }

    private void OpenShop()
    {
        shopCanvas.SetActive(true);
    }

    private void CloseShop()
    {
        shopCanvas.SetActive(false);
    }
}
