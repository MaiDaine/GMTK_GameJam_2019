using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
