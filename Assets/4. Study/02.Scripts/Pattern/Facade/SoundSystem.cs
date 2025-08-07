using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public void StartSound(string soundName)
    {
        Debug.Log(soundName + "시작");
    }

    public void PauseSound(string soundName)
    {
        Debug.Log(soundName + "중지");
    }

    public void StopSound(string soundName)
    {
        Debug.Log(soundName + "정지");
    }
}
