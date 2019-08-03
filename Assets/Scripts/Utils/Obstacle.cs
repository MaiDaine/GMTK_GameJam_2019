using UnityEngine;

namespace GameJam
{
    public class Obstacle : MonoBehaviour
    {
        public GameEvent gameOverEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                gameOverEvent.Raise();
        }
    }
}