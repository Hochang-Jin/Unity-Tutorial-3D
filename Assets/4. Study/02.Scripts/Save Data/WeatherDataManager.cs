using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherDataManager : MonoBehaviour
{
    public enum WeatherType
    {
        SUN,
        CLOUD,
        RAIN,
        SNOW
    }
    public WeatherType weatherType;

    private string URL = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst?";

    public string key;
    public string numOfRows;
    public string pageNo;
    public string dataType;
    public string base_date;
    public string base_time;
    public string nx;
    public string ny;

    public List<WeatherData.Root> weatherDatas = new List<WeatherData.Root>();
    private int curPTY;
    private int curSKY;
    
    IEnumerator Start()
    {
        URL += $"serviceKey={key}&numOfRows={numOfRows}&pageNo={pageNo}&dataType={dataType}&base_date={base_date}&base_time={base_time}" +
               $"&nx={nx}&ny={ny}";
        
        Debug.Log(URL);
        UnityWebRequest www = UnityWebRequest.Get(URL);
        
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        string data = www.downloadHandler.text;
        
        Debug.Log(data);
        
        WeatherData.Root weatherData = JsonUtility.FromJson<WeatherData.Root>(data);
        weatherDatas.Add(weatherData);

        foreach (var item in weatherData.response.body.items.item)
        {
            if (item.category == "PTY")
            {
                curPTY = int.Parse(item.fcstValue);
            }
            else if (item.category == "SKY")
            {
                curSKY = int.Parse(item.fcstValue);
            }
        }
        
        SetWeatherType();
    }

    private void SetWeatherType()
    {
        if (curPTY is 1 or 2 or 4)
        {
            weatherType = WeatherType.RAIN;
        }
        else if (curPTY == 3)
            weatherType = WeatherType.SNOW;

        if (curSKY == 1)
            weatherType = WeatherType.SUN;
        else if(curSKY is 3 or 4)
            weatherType = WeatherType.CLOUD;

        Debug.Log($"현재 날씨는 {weatherType}");
    }
}
