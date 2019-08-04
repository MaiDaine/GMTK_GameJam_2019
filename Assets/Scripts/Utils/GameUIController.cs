using UnityEngine.UI;
using UnityEngine;

namespace GameJam
{
    public class GameUIController : MonoBehaviour
    {
        public Button soundButton;
        public Sprite[] soundButtonImages;

        private void Start()
        {
            soundButton.image.sprite = soundButtonImages[MusicPlayer.instance.volume];
        }

        public void OnVolumeChange()
        {
            MusicPlayer.instance.ChangeVolume();
            soundButton.image.sprite = soundButtonImages[MusicPlayer.instance.volume];
        }
    }
}