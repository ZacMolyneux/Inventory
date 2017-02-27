using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory inv;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(inv.items[id].ID == -1)
        {
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.slot = id;
        }
        else if(droppedItem.slot != id)
        {
            Transform itemInSlot = transform.GetChild(0);
            itemInSlot.GetComponent<ItemData>().slot = droppedItem.slot;
            itemInSlot.transform.SetParent(inv.slots[droppedItem.slot].transform);
            itemInSlot.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(transform);
            droppedItem.transform.position = transform.position;

            inv.items[droppedItem.slot] = itemInSlot.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }
    }

}
