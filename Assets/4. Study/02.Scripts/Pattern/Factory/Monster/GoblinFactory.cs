using Pattern.Factory;
using UnityEngine;

public class GoblinFactory : MonsterFactory
{
    protected override Monster CreateMonster(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Goblin" ).AddComponent<NormalGoblin>();
                break;
            case "Warrior":
                return new GameObject("Warrior Goblin" ).AddComponent<WarriorGoblin>();
                break;
            case "Archer":
                return new GameObject("Archer Goblin" ).AddComponent<ArcherGoblin>();
                break;
            default:
                Debug.LogError($"Unknown Monster Type : {type}");
                break;
        }
        return null;
    }
}
