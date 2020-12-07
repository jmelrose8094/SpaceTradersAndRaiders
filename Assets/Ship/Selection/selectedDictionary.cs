using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();
    
    public void addSelected(GameObject go)
    {
      int id = go.GetInstanceID();
      
      if(!(selectedTable.ContainsKey(id)))
      {
        selectedTable.Add(id, go);
        go.AddComponent<selectionsComponent>();
        Debug.Log("Added " + id + " to selected dictionary");
      }
    }
    
    public void deselect(int id)
    {
      Destroy(selectedTable[id].GetComponent<selectionsComponent>());
      selectedTable.Remove(id);
    }
    
    public void deselectAll()
    {
      foreach(KeyValuePair<int, GameObject> pair in selectedTable)
      {
        if(pair.Value != null)
        {
          Destroy(selectedTable[pair.Key].GetComponent<selectionsComponent>());
        }
      }
      selectedTable.Clear();
    }
}
