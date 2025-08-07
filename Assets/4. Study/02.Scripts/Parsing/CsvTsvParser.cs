using System;
using System.Collections.Generic;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }

    public List<CharacterData> characterDatas = new List<CharacterData>();

    private void Start()
    {
        // var dataFile = Resources.Load<TextAsset>("CsvData");
        var dataFile = Resources.Load<TextAsset>("TsvData");
        string data = dataFile.text;
        
        ParsingCharacterData(data);
    }

    private void ParsingCharacterData(string data)
    {
        string[] lines = data.Split('\n');
        for (int i = 1; i < lines.Length; i++) // 0번째 인덱스 줄은 실제 데이터 값이 아님
        {
            // string[] line = lines[i].Split(',');
            string[] line = lines[i].Split('\t');
            CharacterData cd = new CharacterData(line[0], line[1], int.Parse(line[2]), int.Parse(line[3]));
            characterDatas.Add(cd);
        }
    }
}
