using System;
using UnityEngine;

namespace Data.SO
{
    public class Player : MonoBehaviour
    {
        public GameObject[] weaponObjs;
        public WeaponData[] weaponDatas;

        public string currWeaponName;
        public int currWeaponDMG;
        public int currWeaponRange;

        private void Start()
        {
            currWeaponName = weaponDatas[0].name;
            currWeaponDMG = weaponDatas[0].damage;
            currWeaponRange = weaponDatas[0].range;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
                SwapWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SwapWeapon(1);
        }

        private void SwapWeapon(int p0)
        {
            foreach (var VARIABLE in weaponObjs)
            {
                VARIABLE.SetActive(false);
            }
            
            weaponObjs[p0].SetActive(true);
            
            currWeaponName = weaponDatas[p0].name;
            currWeaponDMG = weaponDatas[p0].damage;
            currWeaponRange = weaponDatas[p0].range;
        }
    }

}
