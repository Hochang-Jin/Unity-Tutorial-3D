using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetCSVParser : MonoBehaviour
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

    private string URL;
    
    IEnumerator Start()
    {
        URL = "https://docs.google.com/spreadsheets/d/1d9xcoORI9_nVHiDDdWdc9RsT3ktz9BXCB6TJSxNosS0/export?format=csv&range=A2:D5";
        UnityWebRequest www = UnityWebRequest.Get(URL);
        
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        
        Debug.Log(data);
        
        ParsingCharacterData(data);
    }

    private void ParsingCharacterData(string data)
    {
        string[] rows=data.Split('\n');

        for (int i = 0; i < rows.Length; i++)
        {
            string[] cols = rows[i].Split(',');
            CharacterData cd = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));
            characterDatas.Add(cd);
        }
    }

}
