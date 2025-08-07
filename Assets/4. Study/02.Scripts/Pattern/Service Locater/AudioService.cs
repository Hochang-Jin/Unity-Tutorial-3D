using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    public void PlaySound()
    {
        Debug.Log("play sound");
    }

    public void StopSound()
    {
        UnityEngine.Debug.Log("stop sound");
    }
}
