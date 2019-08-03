using UnityEngine.UI;
using UnityEngine;

namespace GameJam
{
    public class GameRules : MonoBehaviour
    {
        public GameObject player;
        public GameObject startPosition;
        public GameObject blBound;
        public GameObject trBound;
        public Text timerText;

        private float timer;

        private void Start()
        {
            timer = 0f;
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.R))
                OnGameOver();
            else
                CheckMapBounds();
            UpdateTimer();
        }

        public void OnGameOver()
        {
            player.GetComponent<SpaceShipPhysics>().ResetState();
            player.transform.position = startPosition.transform.position;
            player.gameObject.GetComponentInChildren<TrailRenderer>().Clear();
            player.gameObject.GetComponentInChildren<TrailRenderer>().AddPosition(transform.position);
            Camera.main.GetComponent<CameraController>().ResetCamera();
            timer = 0f;
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

        private void UpdateTimer()
        {
            timer += Time.deltaTime;
            timerText.text =  timer.ToString("F2");
        }
    }
}