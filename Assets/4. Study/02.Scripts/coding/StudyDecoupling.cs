using UnityEngine;


// // 커플링이 잡힌 상황
// public class StudyDecoupling : MonoBehaviour
// {
//     public class Player
//     {
//         public Enemy enemy;
//
//         public void AttackEnemy()
//         {
//             enemy.TakeDamage(10);
//         }
//     }
//
//     public class Enemy
//     {
//         public float health = 10;
//         
//         public void TakeDamage(float damage)
//         {
//             health -= damage;
//             Debug.Log("damage만큼 공격 받음");
//         }
//     }
// }


// 디커플링  
public interface IDamageable
{
    void TakeDamage(float damage);
}

public class StudyDecoupling2 : MonoBehaviour
{
    public class Player
    {
        public void AttackEnemy(IDamageable target, float damage)
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        public float health = 10;
        
        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}