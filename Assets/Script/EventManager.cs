using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public UnityEvent OnTriggerPlatformHit;
    public UnityEvent OnGameOver;
    public UnityEvent OnCoinCollect;
    public UnityEvent OnPause;
    public UnityEvent OnResume;
    public UnityEvent OnJump;
    public UnityEvent OnSlide;

    public void TriggerPlatformHit()
    {
        OnTriggerPlatformHit?.Invoke();
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
    public void CoinCollect()
    {
        OnCoinCollect?.Invoke();
    }
    public void Pause()
    {
        OnPause?.Invoke();
    }
    public void Resume()
    {
        OnResume?.Invoke();
    }
    public void Jump()
    {
        OnJump?.Invoke();
    }
    public void Slide()
    {
        OnSlide?.Invoke();
    }
}
