using UnityEngine;

public class Timer : UIElements
{
    private void Start()
    {
        timerText.text = "������� ������: " + currentTime.ToString();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = "������� ������: " + Mathf.Round(currentTime).ToString();
    }
}