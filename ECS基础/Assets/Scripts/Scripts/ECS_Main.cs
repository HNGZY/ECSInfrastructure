using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECS_Main : MonoBehaviour
{
    public Transform content;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            UIItem item = new UIItem("Item",content);
            item.SetItem(Item.CreateEntityByID(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
