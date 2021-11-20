using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillWithTime : MonoBehaviour
{
    [SerializeField] private Image countdownImage = null;
    [SerializeField] private Text countdownText = null;
    [SerializeField] private Button addButton = null;
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button decreaseButton = null;
    [SerializeField] private AudioSource audio = null;

    private bool started = false;
    private float time = 0f;
    private float initialTime = 0f;

    public void AddOneMinute()
    {
        time += 60f;
        countdownText.text = Mathf.RoundToInt(time / 60f).ToString();
    }

    public void DecreaseOneMinute()
    {
        time -= 60f;
        countdownText.text = Mathf.RoundToInt(time / 60f).ToString();
    }

    public void StartTime()
    {
        initialTime = time;
        started = true;
        addButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        decreaseButton.gameObject.SetActive(false);
    }

	private void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update ()
    {
		if (!started) { return; }

        time -= Time.deltaTime;

        if (time < 0f) { time = 0f; audio.Play(); }

        countdownText.text = Mathf.RoundToInt(time/60f).ToString();
        countdownImage.fillAmount = time / initialTime;        
	}
}
