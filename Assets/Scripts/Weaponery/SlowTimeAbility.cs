using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SlowTimeAbility : MonoBehaviour
{
    private float _timeMax = 100f;
    private float _time;

    public static bool isStateChanging = false;
    [SerializeField]private PostProcessVolume postProcess;

    public AudioClip slowMoEffectClip;

    private void Awake()
    {
        _time = _timeMax;
    }

    private void Update()
    {
        if (_time != _timeMax)
        {
            UISetup.Instance.UpdateVirtualTime(_time,_timeMax);
        }

        TimeLimiter();
        
        if (Input.GetMouseButtonDown(1))
        {
            if (Mathf.Approximately(Time.timeScale, 1.0f))
            {
                stTime(0.4f,true);
            }
            else 
            {
                stTime(1f,false);
            }
        }

        if (isStateChanging)
        {
            _time -= 0.30f;
            AudioPlay.clip = slowMoEffectClip;
            AudioPlay.isPlaying = true;
            postProcess.enabled = true;
        }
        else
        {
            _time += 0.10f;
            postProcess.enabled = false;
        }
    }

    void TimeLimiter()
    {
        if (_time > _timeMax)
        {
            _time = _timeMax;
        }

        if (_time <= 0)
        {
            _time = 0f;
            stTime(1f,false);
        }
    }

    void stTime(float timeVal,bool stateVal)
    {
        Time.timeScale = timeVal;
        isStateChanging = stateVal;
    }

    
}
