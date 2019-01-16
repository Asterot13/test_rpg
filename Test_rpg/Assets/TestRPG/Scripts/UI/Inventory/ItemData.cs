using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Item item;
        public int amount;
        public int slot;

        private Inventory inv;
        private Vector2 offset;

        void Start()
        {
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
                transform.SetParent(transform.parent.parent);
                transform.position = eventData.position - offset;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                transform.position = eventData.position - offset;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(inv.slots[slot].transform);
            transform.position = inv.slots[slot].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
