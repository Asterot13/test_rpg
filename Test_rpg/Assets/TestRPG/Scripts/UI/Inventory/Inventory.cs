using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        GameObject inventoryPanel;
        GameObject slotPanel;
        ItemDatabase database;
        int slotAmount;

        public GameObject inventorySlot;
        public GameObject inventoryItem;

        public List<Item> items = new List<Item>();
        public List<GameObject> slots = new List<GameObject>();

        void Start()
        {
            database = GetComponent<ItemDatabase>();

            slotAmount = 12;
            inventoryPanel = GameObject.Find("InventoryPanel");
            slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
            for (int i = 0; i < slotAmount; i++)
            {
                items.Add(new Item());
                slots.Add(Instantiate(inventorySlot));
                slots[i].transform.SetParent(slotPanel.transform);
            }

            AddItem(0);
            AddItem(1);
        }

        public void AddItem(int id)
        {
            Item itemToAdd = database.FetchItemByID(id);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    break;
                }
            }
        }
    }
}