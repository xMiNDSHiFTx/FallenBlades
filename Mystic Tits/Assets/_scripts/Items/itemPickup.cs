using UnityEngine;

public class itemPickup : Interactable 
{
    #region Variables
    public Item item;
    #endregion

    #region Unity Methods
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    void PickUp ()
    {
        
        Debug.Log("Picking up " + item.name);

        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }


    #endregion
}
