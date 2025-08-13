using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
   private enum PlantState { Level1, Level2, Level3 }
   private PlantState plantState;

   private DateTime startTime, growthTime, harvestTime; // 레벨이 변하는 시간 설정

   public int plantIndex;
   public bool isHarvest = false;

   void Awake()
   {
      startTime = DateTime.Now;
      growthTime = startTime.AddSeconds(5);
      harvestTime = startTime.AddSeconds(10);
      
      // DateTime.Now : 현재 시간을 활용한 방법
      // Time.time : 게임 실행 시간
      // Time.deltaTime : 시간 조각
   }

   private void OnEnable()
   {
      WeatherSystem.weatherAction += SetGrowth;
   }

   private void OnDisable()
   {
      WeatherSystem.weatherAction -= SetGrowth;
   }

   IEnumerator Start()
   {
      SetState(PlantState.Level1);

      while (plantState != PlantState.Level3)
      {
         if (DateTime.Now >= harvestTime)
         {
            SetState(PlantState.Level3);
            isHarvest = true;
         }
         else if (DateTime.Now >= growthTime)
         {
            SetState(PlantState.Level2);
         }
         
         yield return new WaitForSeconds(1f);
      }
   }
   
   private void SetState(PlantState newState)
   {
      if (plantState != newState || plantState == PlantState.Level1)
      {
         plantState = newState;
         
         for (int i = 0; i <  3; i++)
            transform.GetChild(i).gameObject.SetActive(false);

         transform.GetChild((int)plantState).gameObject.SetActive(true);
      }
   }

   private void SetGrowth(WeatherSystem.WeatherType weatherType)
   {
      switch (weatherType)
      {
         case WeatherSystem.WeatherType.SUN:
            break;
         case WeatherSystem.WeatherType.RAIN:
            break;
         case WeatherSystem.WeatherType.SNOW:
            break;
         default:
            throw new ArgumentOutOfRangeException(nameof(weatherType), weatherType, null);
      }
   }
}