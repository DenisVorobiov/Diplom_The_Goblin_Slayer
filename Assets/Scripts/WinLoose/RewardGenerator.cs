using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardGenerator : MonoBehaviour
{
    
    public GameObject objectToClose;

    private void Start()
    {
        
        //  if (objectToClose == null)
        //{
         //   Debug.LogError("Object to close is not assigned to the button!");
       // }

    }
    public void GetReward(string lootKey)
    {
        LootCollection[] lootCollections = Context.Instance.DataSystem.LootData;
        LootItem[] loot = lootCollections.First(lc => lc.key == lootKey).Items;
        LootItem rewardItem = default;

        float sum = loot.Select(l => l.Weight).Sum();
        float rng = Random.Range(0, sum);

        for (int i = 0; i < loot.Length; ++i)
        {
            if (rng < loot[i].Weight)
            {
                rewardItem = loot[i];
                break;
            }

            rng -= loot[i].Weight;
        }


        ItemData[] allItems = Context.Instance.DataSystem.ItemsData;
        ItemData winItem = allItems.FirstOrDefault(i => i.Name == rewardItem.ItemKey);

        if (winItem != null)
            Context.Instance.InventorySystem.AddItem(new InventoryItem(winItem));
    }

    public void ClosedRewardPanel ()
    {
        if (objectToClose != null)
        {
            objectToClose.SetActive(false);
        }
    }
}