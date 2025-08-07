using Pattern.Factory;
using UnityEngine;

public class OrcFactory : MonsterFactory
{
    protected override Monster CreateMonster(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Orc" ).AddComponent<NormalOrc>();
                break;
            case "Warrior":
                return new GameObject("Warrior Orc" ).AddComponent<WarriorOrc>();
                break;
            case "Archer":
                return new GameObject("Archer Orc" ).AddComponent<ArcherOrc>();
                break;
            default:
                Debug.LogError($"Unknown Monster Type : {type}");
                break;
        }
        return null;
    }
}
