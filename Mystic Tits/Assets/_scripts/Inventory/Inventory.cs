using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour 
{
    #region Variables
    public List<Item> items = new List<Item>();
    public int bagSpace = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    #endregion
    
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
        }
        instance = this;
    }
    #endregion

    #region Unity Methods
    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= bagSpace)
            {
                Debug.Log("Your Bags are Full.");
                return false;
            }

            items.Add(item);

            if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        }
        return true;
    }
    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    #endregion
}
