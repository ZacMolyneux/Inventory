using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private Item item;
    private string data;
    private GameObject tooltip;


    void Start()
    {
        tooltip = GameObject.Find("ToolTip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if(tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    //fill this out in a way that it displays all information about the item, can set up to check what type of item to change what info is displayed (eg. potions)
    //can change color based on rarity ect.
    public void ConstructDataString()
    {
        data = "<color=#000000><b>" + item.Title + "</b></color>\n\n" + "Power: " + item.Power + "\n\n<i>" + item.Description + "</i>";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;

    }
}
