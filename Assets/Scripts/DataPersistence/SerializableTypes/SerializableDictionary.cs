/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 29/01/2023
/// Purpose : defining how to serialize a dictionary
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{

    [SerializeField]
    private List<TKey> keys = new List<TKey>();
    [SerializeField]
    private List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        //make sure lists are clear
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this) //loop though each pair in dictionary
        {
            //add to list
            keys.Add(pair.Key); 
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
        {
            Debug.LogError("Tried to deserialise a serializeable dictionary however keys and values dont match. Keys:" + keys.Count
                + " Values:" + values.Count);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
