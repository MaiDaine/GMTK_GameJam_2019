using UnityEngine;

namespace GameJam
{
    public class VictoryTrigger : MonoBehaviour
    {
        public GameEvent victoryEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                victoryEvent.Raise();
        }
    }
}