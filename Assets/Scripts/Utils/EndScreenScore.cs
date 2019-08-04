using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class EndScreenScore : MonoBehaviour
    {
        public FloatVariable totalTime;
        public Text text;

        private void Start()
        {
            int minutes = Mathf.RoundToInt(totalTime.value / 60f);
            int seconds = Mathf.RoundToInt(totalTime.value % 60f);
            text.text = "Final score: " + minutes.ToString() + ":" + seconds.ToString();
        }
    }
}
