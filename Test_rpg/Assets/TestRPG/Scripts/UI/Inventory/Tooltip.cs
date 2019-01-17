using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Tooltip : MonoBehaviour
    {
        private Item item;
        private string data;
        private GameObject toolTip;

        private void Start()
        {
            toolTip = GameObject.Find("Tooltip");
            toolTip.SetActive(false);
        }

        private void Update()
        {
            if (toolTip.activeSelf)
            {
                toolTip.transform.position = Input.mousePosition;
            }
        }

        public void Activate(Item _item)
        {
            this.item = _item;
            ConstructDataString();
            toolTip.SetActive(true);
        }

        public void DeActivate()
        {
            toolTip.SetActive(false);
        }

        public void ConstructDataString()
        {
            data = "<color=#D4C902><b>" + item.Title + "</b></color>\n\n" + item.Description +
                "\nPower: " + item.Power;
            toolTip.transform.GetChild(0).GetComponent<Text>().text = data;
        }
    }
}
