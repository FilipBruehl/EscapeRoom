using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public GameObject[] items = new GameObject[5];
    public const int size = 5;

    void Start()
    {

    }

    public void AddItem(GameObject newItem)
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;
                Debug.Log(newItem.name + " addet to inventory");
            }
        }
    }

    public void DeleteItem(GameObject removeItem)
    {
        for(int i = 0; i < size; i++)
        {
            if (items[i] == removeItem)
            {
                items[i] = null;
            }
        }
    }

    public bool DeleteItem(int pos)
    {
        if(pos > size)
        {
            return false;
        } else
        {
            items[pos] = null;
            return true;
        }
    }

    public bool HasItem(GameObject other)
    {
        foreach(GameObject item in items)
        {
            if(item == other)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public bool HasItem(string name)
    {
        foreach(GameObject item in items)
        {
            if(item.name == name || item.tag == name)
            {
                return true;
            }
            return false;
        }
        return false;
    }

}
