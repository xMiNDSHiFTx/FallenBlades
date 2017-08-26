using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventroy/Item")]

public class Item : ScriptableObject
{
    #region Variables
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
	#endregion
	
	#region Unity Methods
    public virtual void Use ()
    {
        Debug.Log("Using " + name);
    }

	#endregion
}
