
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropPool : MonoBehaviour
{
   public static DropPool instance;
   private readonly List<GameObject> _pooledWood = new();
   private const int WoodAmount = 100;
   [SerializeField] private GameObject woodPrefab;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   private void Start()
   {
      for (var i = 0; i < WoodAmount; i++)
      {
         var obj = Instantiate(woodPrefab);
         obj.SetActive(false);
         _pooledWood.Add(obj);
      }
   }

   public GameObject GetPooledWood()
   {
      return _pooledWood.FirstOrDefault(t => !t.activeInHierarchy);
   }
}
