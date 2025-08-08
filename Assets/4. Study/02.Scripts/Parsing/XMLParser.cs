using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLParser : MonoBehaviour
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
    [XmlRoot("Characters")]
    public class CharacterList
    {
        [XmlElement("Character")]
        public List<CharacterData> characters;
    }
    
    public List<CharacterData> characterDatas = new List<CharacterData>();

    private void Start()
    {
        var dataFile = Resources.Load<TextAsset>("xmlData");
        string data = dataFile.text;
        
        ParsingCharacterXmlData(data);
    }

    void ParsingCharacterXmlData(string data)
    {
        Debug.Log(data);
        
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data))
        {
            CharacterList loaded = (CharacterList)serializer.Deserialize(reader);
            characterDatas = loaded.characters;
        }

        foreach (var cData in characterDatas)
        {
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.HP} / {cData.Attack}");
        }
    }
}
