using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string CharID;
        public string Name;
        public int HP;
        public int Attack;
    }

    [System.Serializable]
    public class CharacterListWrapper
    {
        public List<CharacterData> characters;
    }
    
    public List<CharacterData> characters = new List<CharacterData>();

    private void Start()
    {
        var dataFile = Resources.Load<TextAsset>("jsonData");
        var data = dataFile.text;
        
        ParsingCharacterJsonData(data);
    }

    void ParsingCharacterJsonData(string data)
    {
        CharacterListWrapper wrapper = JsonUtility.FromJson<CharacterListWrapper>(data);

        foreach (var cData in wrapper.characters)
        {
            characters.Add(cData);
            Debug.Log($"{cData.CharID} / {cData.Name}/ {cData.HP} / {cData.Attack}");
        }
    }
}
