using UnityEngine;

namespace GameJam
{
    public class GameRules : MonoBehaviour
    {
        public GameObject player;
        public GameObject startPosition;
        public GameObject blBound;
        public GameObject trBound;

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.R))
                OnGameOver();
            else
                CheckMapBounds();
        }

        public void OnGameOver()
        {
            player.GetComponent<SpaceShipPhysics>().ResetState();
            player.transform.position = startPosition.transform.position;
            player.GetComponentInChildren<TrailRenderer>().Clear();
            player.GetComponentInChildren<TrailRenderer>().AddPosition(transform.position);
            Camera.main.GetComponent<CameraController>().ResetCamera();
        }

        public void OnVictory()
        {
            Debug.Log("WIN");
            OnGameOver();//TODO
        }

        private void CheckMapBounds()
        {
            if (player.transform.position.x > trBound.transform.position.x 
                || player.transform.position.x < blBound.transform.position.x
                || player.transform.position.y > trBound.transform.position.y 
                || player.transform.position.y < blBound.transform.position.y)
                OnGameOver();
        }
    }
}