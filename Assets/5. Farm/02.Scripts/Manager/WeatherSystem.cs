using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeatherSystem : MonoBehaviour
{
    public enum WeatherType
    {
        SUN,
        RAIN,
        SNOW
    }

    public WeatherType type = WeatherType.SUN;
    [SerializeField] private GameObject[] weatherParticles;

    public static event Action<WeatherType> weatherAction;
    
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            
            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;
            
            int randInt = Random.Range(0,weatherCount);
            type = (WeatherType)randInt;
            Debug.Log($"현재 날씨는 {type}");

            foreach (var particle in weatherParticles)
            {
                particle.gameObject.SetActive(false);
            }
            
            weatherParticles[randInt].gameObject.SetActive(true);
            
            // 날씨에 따라 이벤트 발생
            weatherAction?.Invoke(type);
        }
    }
}
