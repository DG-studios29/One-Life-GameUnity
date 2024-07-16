using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public List<CraftingRecipe> recipes;

    public bool CraftItem(PlayerInventory inventory, CraftingRecipe recipe)
    {
        foreach (var item in recipe.requiredItems)
        {
            if (!inventory.HasResource(item.resourceType, item.quantity))
            {
                Debug.Log("Not enough resources to craft " + recipe.resultItem.itemName);
                return false;
            }
        }

        foreach (var item in recipe.requiredItems)
        {
            inventory.RemoveResource(item.resourceType, item.quantity);
        }

        inventory.AddResource(recipe.resultItem.resourceType, recipe.resultItem.quantity);
        Debug.Log("Crafted " + recipe.resultItem.itemName);
        return true;
    }
}
