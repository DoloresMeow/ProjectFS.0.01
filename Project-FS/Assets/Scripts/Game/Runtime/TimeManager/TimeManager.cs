using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//sealed 防继承
public sealed class TimeDisplay
{
    public int Year;
    public int Month;
    public int Day;
    public int Hour;
    public int Minute;
}

public enum GameTimeState:byte
{
    TimeNomral,
    TimeSpeedUp,
    TimePause
}
public class TimeManager : Singleton<TimeManager>
{
    private GameTimeState gameTimeState;
    private bool gameTimeStart;
    private float realStartTime;
    private static float gameTime;
    private float preChangeTime;
    private static TimeDisplay displayTime;

    private static int realTimeToMin;
    private static int minToHour;
    private static int hourToDay;

    public float GameTime
    {
        get
        {
            return gameTime;
        }
    }

    public TimeDisplay DisplayTime
    {
        get { return displayTime; }
    }

    public override void Init()
    {
        displayTime = new TimeDisplay();
        gameTimeStart = true;
        realStartTime = Time.time;//先用最简单的time来记录
        gameTime = 0;
        preChangeTime = 0;

        realTimeToMin = 1;
        minToHour = 6;//10-6,5-12
        hourToDay = 24;
    }

    private void TimeGrow()
    {
        preChangeTime = Time.time;
        gameTime++;
        //Debug.Log("Now Time is : " + gameTime);
        displayTime.Minute = Mathf.FloorToInt( gameTime / realTimeToMin) *10 %60;
        displayTime.Hour = Mathf.FloorToInt(gameTime / (realTimeToMin * minToHour))%24;
        displayTime.Day = Mathf.FloorToInt(gameTime / (realTimeToMin * minToHour * hourToDay))%31;

    }

    public void TimePause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            gameTimeState = GameTimeState.TimePause;
        }
        else
        {
            Time.timeScale = 10;
            gameTimeState = GameTimeState.TimeNomral;
        }
    }

    public void TimeSpeedUp(bool speedup)
    {
        if (speedup)
        {
            Time.timeScale = 30;
            gameTimeState = GameTimeState.TimeSpeedUp;
        }
        else
        {
            Time.timeScale = 10;
            gameTimeState = GameTimeState.TimeNomral;
        }
    }

    private void Update()
    {
        if(gameTimeStart)
        {
            if (displayTime.Hour > -1 && displayTime.Hour < 7 && gameTimeState == GameTimeState.TimeNomral)
                TimeSpeedUp(true);
            else
                TimeSpeedUp(false);
            if (Time.time - realStartTime > 0 && Time.time - preChangeTime > 1f)
            {
                TimeGrow();
            }
        }
    }
}
