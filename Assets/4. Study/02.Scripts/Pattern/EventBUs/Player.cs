using System.Collections.Generic;
using UnityEngine;

namespace Pattern.EventBus
{
    public class Player : ISubject
    {
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void AddScore(int score)
        {
            this.score += score;
            NotifyObservers();
        }

        private void CheckQuest()
        {
            
        }

        public List<IObserver> Observers { get; set; }
        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                observer.Notify(score);
            }
        }
    }
}
