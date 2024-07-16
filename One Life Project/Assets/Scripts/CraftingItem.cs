using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Item", menuName = "Crafting/Crafting Item")]
public class CraftingItem : ScriptableObject
{
    public string itemName;
    public ResourceType resourceType;
    public Sprite icon;
    public GameObject prefab;
    public int quantity;
}
