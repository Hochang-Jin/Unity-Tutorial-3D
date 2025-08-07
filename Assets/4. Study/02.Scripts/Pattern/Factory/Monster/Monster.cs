using UnityEngine;

namespace Pattern.Factory
{
    public abstract class Monster : MonoBehaviour
    {
        public string Name { get; protected set; }
        public int Hp { get; protected set; }
        public int Attack { get; protected set; }

        protected virtual void Initialize(string name, int hp, int attack)
        {
            Name = name;
            Hp = hp;
            Attack = attack;
            Debug.Log($"{Name} / {Hp} / {Attack} 생성");
        }
    }

}

