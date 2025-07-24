using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FPSPlayerFire : MonoBehaviour
{
    private enum WeaponMode{ NORMAL, SNIPER}
    private WeaponMode wMode;
    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;
    
    
    public GameObject firePosition;
    private Animator anim;
    
    public GameObject bombFactory;

    public float throwPower = 15f;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    private ParticleSystem ps;
    
    private bool zoomMode = false;

    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.NORMAL;
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.RUN)
            return;
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo =  new RaycastHit();

            StartCoroutine(ShootEffectOn(0.1f));

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // 대상이 enemy
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // 대상이 enemy가 아닌 경우
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;
                    
                    ps.Play();
                }  
            }
        }
        
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
        {
            switch (wMode)
            {
                case WeaponMode.NORMAL: // 일반 모드 일 때 수류탄 
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.SNIPER: // 스나이퍼 모드 일 때 줌
                    Camera.main.fieldOfView = zoomMode ? 60f : 15f;
                    zoomMode = !zoomMode;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1번 키를 누르면
        {
            wMode = WeaponMode.NORMAL;
            zoomMode = false;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "NORMAL MODE";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.SNIPER;
            wModeText.text = "SNIPER MODE";
        }
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);
        eff_Flash[num].SetActive(true);
        
        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
        
    }
}