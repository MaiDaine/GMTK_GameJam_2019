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
        public AudioClip explosionSound;
        public AudioClip outOfReachSound;
        public FloatVariable totalTimer;

        private AudioSource audioSource;
        private float timer;

        private void Start()
        {
            timer = 0f;
            audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnGameOver();
            else
                CheckMapBounds();
            UpdateTimer();
        }

        public void OnVictory()
        {
            totalTimer.SetValue(totalTimer.value + timer);
        }

        public void OnGameOver()
        {
            player.GetComponent<SpaceShip>().ResetState();
            player.transform.position = startPosition.transform.position;
            player.gameObject.GetComponentInChildren<TrailRenderer>().Clear();
            player.gameObject.GetComponentInChildren<TrailRenderer>().AddPosition(transform.position);
            totalTimer.SetValue(totalTimer.value + timer);
            timer = 0f;
        }

        public void OnShipCrash()
        {
            PlayAudioClip(explosionSound);
            OnGameOver();
        }

        private void CheckMapBounds()
        {
            if (player.transform.position.x > trBound.transform.position.x
                || player.transform.position.x < blBound.transform.position.x
                || player.transform.position.y > trBound.transform.position.y
                || player.transform.position.y < blBound.transform.position.y)
            {
                OnGameOver();
                PlayAudioClip(outOfReachSound);
            }
        }

        private void UpdateTimer()
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2");
        }

        private void PlayAudioClip(AudioClip clip)
        {
            audioSource.volume = MusicPlayer.instance.volume * 0.4f;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}