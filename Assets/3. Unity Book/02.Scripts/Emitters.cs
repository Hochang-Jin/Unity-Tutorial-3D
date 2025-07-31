using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Emitters : MonoBehaviour
{
    public PlayableDirector timeline;
    public SignalReceiver receiver;
    public SignalAsset signal;

    private void Start()
    {
        SetSignalEvent();
    }

    public void OnTimelineSpeed(float speed)
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    public void SetSignalEvent()
    {
        UnityEvent eventContainer = new UnityEvent();
        
        eventContainer.AddListener(() =>
        {
            Debug.Log("이벤트 등록");
            OnTimelineSpeed(0.2f);
            Debug.Log("Timeline 속도 0.2 설정");
        });
        
        receiver.AddReaction(signal,eventContainer);
    }
}
