using UnityEngine;
using UnityEngine.UI;

public class ImageSelector : MonoBehaviour
{
    public Transform content; 
    private GameObject selectedItem;

    public Color normalBorderColor = Color.black; 
    public Color selectedBorderColor = Color.yellow; 

    public void SelectItem(GameObject item)
    {
        // Deselect the currently selected item
        if (selectedItem != null)
        {
            SetBorderColor(selectedItem, normalBorderColor);
        }

        // Select the new item
        selectedItem = item;
        SetBorderColor(selectedItem, selectedBorderColor);
        SceneTransitionManager.singleton.currentRecipe = GetRecipeFromButton(selectedItem);

    }

    private void SetBorderColor(GameObject item, Color color)
    {
        // Assumes the border is the Image component of the parent or another sibling
        Outline border = item.GetComponent<Outline>();
        if (border != null)
        {
            border.effectColor = color;
        }
    }
    private SceneTransitionManager.Recipe GetRecipeFromButton(GameObject item)
    {
        string buttonName = item.name;
        if (buttonName == "BistecPobre")
        {
            return SceneTransitionManager.Recipe.BistecPobre;
        }
        else if (buttonName == "Spaghetti")
        {
            return SceneTransitionManager.Recipe.Spaghetti;
        }

        return SceneTransitionManager.Recipe.None;
    }
}
