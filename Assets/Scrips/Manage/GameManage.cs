using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManage : MonoBehaviour
{
    
    public event EventHandler OnStateChange;
    // Start is called before the first frame update
    private enum State{
        waitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }
    State state;
    float CountDownToStartTimer=3f;
    float gamePlayingTimer;
    float gamePlayingTimerMax=60f;
   
     public static GameManage Instance {get; private set;}
    private void Awake(){
        Instance = this;
        state=State.waitingToStart;

    }


    private void Update() {
        switch(state){
            case State.waitingToStart:
            state=State.CountDownToStart;
                break;
            case State.CountDownToStart:
                CountDownToStartTimer-=Time.deltaTime;
                if(CountDownToStartTimer<0){
                    state = State.GamePlaying;
                    gamePlayingTimer=gamePlayingTimerMax;
                    OnStateChange?.Invoke(this,EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer-=Time.deltaTime;
                if(gamePlayingTimer<0){
                    state=State.GameOver;
                    OnStateChange?.Invoke(this,EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;   
        }
    }

    public bool IsGamePlaying(){
        return state==State.GamePlaying;
    }
    public bool IsCountdownToStartActive()
    {
        return state == State.CountDownToStart;
    }

    public float getCountDownToStartTime(){
        return CountDownToStartTimer;
    }
    
    public bool isGameOver(){
        return state==State.GameOver;
    }

    public float getGamePlayingTime(){
        return 1-(gamePlayingTimer/gamePlayingTimerMax);
    }
}
