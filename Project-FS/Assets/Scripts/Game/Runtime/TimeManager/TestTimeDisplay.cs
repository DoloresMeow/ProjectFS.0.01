using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestTimeDisplay : MonoBehaviour
{
    private Text displayText;
    private static string showText = "Now Time is : ";
    private string updateText = "";
    private TimeDisplay timeDisplay;
    private void Awake()
    {
        displayText = GetComponent<Text>();
        timeDisplay = new TimeDisplay();
        
    }

    private void FixedUpdate()
    {
        timeDisplay = TimeManager.GetInstance().DisplayTime;
        updateText = showText + "Day: " + timeDisplay.Day + " Hour :"+timeDisplay.Hour + " Minutes: " +timeDisplay.Minute;
        displayText.text = updateText;
    }
}
