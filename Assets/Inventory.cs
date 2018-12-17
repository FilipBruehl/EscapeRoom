using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<GameObject> items = new List<GameObject>();

    void Start()
    {

    }

    public void AddItem(GameObject newItem)
    {
        if(!this.HasItem(newItem))
        {
            items.Add(newItem);
            Debug.Log(string.Format("{0} addet to inventory.", newItem.name));
        }
    }

    public void DeleteItem(GameObject removeItem)
    {
        items.Remove(removeItem);
        Debug.Log(string.Format("{0} removed from inventory", removeItem.name));
    }

    public bool DeleteItem(int pos)
    {
        if(pos > items.Count)
        {
            return false;
        } else
        {
            items.RemoveAt(pos);
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

    public bool HasItemName(string name)
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

    public override string ToString()
    {
        string ausgabe = "Elemente im Inventar:\n";
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i] != null)
            {
                ausgabe += string.Format("{0} - {1}\n", i, items[i].name);
            }
        }
        return ausgabe;
    }

}
