using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{

    public int saved_score;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }


    public void LoadFromJson(string some_Jsontext)
    {
        JsonUtility.FromJsonOverwrite(some_Jsontext, this);
    }

}

public interface ISaveable
{
    void PopulateSaveData(SaveData gameSaveData);
    void LoadDataFromFile(SaveData readSaveData);
}
