using System;
using UnityEngine;
using Pattern.EventBus;

namespace Pattern
{
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            EventBus.Player player = new EventBus.Player();
            
            player.AddScore(100);
            player.AddScore(500);
            player.AddScore(1000);

        }
    }
}
