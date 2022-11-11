using UnityEngine;

public class Timer : UIElements
{
    private void Start()
    {
        timerText.text = "Времени прошло: " + currentTime.ToString();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = "Времени прошло: " + Mathf.Round(currentTime).ToString();
    }
}