using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    public float currentTime = 0;
    public int collusionCount = 0;
    public Text timerText, collusionText;

    public void ResetText()
    {
        timerText.GetComponent<Timer>().currentTime = 0;
        collusionText.GetComponent<CollisionCount>().collusionCount = 0;
        timerText.text = "Времени прошло: " + currentTime.ToString();
        collusionText.text = "Столкновений: " + collusionText.GetComponent<CollisionCount>().collusionCount;
    }
}