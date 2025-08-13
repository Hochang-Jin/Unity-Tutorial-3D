using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;
    [SerializeField] private Button[] turnButtons; // 0 : Left / 1 : Right
    [SerializeField] private Button selectButton;
    [SerializeField] private Animator[] characterAnims;

    private bool isTurn;

    public int currentIndex = 0;

    private void Start()
    {
        turnButtons[0].onClick.AddListener(()=>Turn(true));
        turnButtons[1].onClick.AddListener(()=>Turn(false));
        selectButton.onClick.AddListener(Select);
    }

    public void Turn(bool isLeft)
    {
        float rot = isLeft ? -90 : 90;
        var targetRot = centerPivot.rotation * Quaternion.Euler(0, rot, 0);

        if (isTurn) return;
        isTurn = true;
        ChangeIndex(isLeft);
        StartCoroutine(TurnRoutine(targetRot));
    }

    IEnumerator TurnRoutine(Quaternion targetRot)
    {
        while (true)
        {
            yield return null;
            
            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 5f * Time.deltaTime);
            
            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);

            if (angle < 0.5f)
            {
                isTurn = false;
                centerPivot.rotation = targetRot;
                yield break;
            }
        }
    }

    private void ChangeIndex(bool isLeft)
    {
        currentIndex += isLeft ? -1 : 1;
        if (currentIndex == -1) currentIndex = 3;
        if (currentIndex == 4) currentIndex = 0;
    }
    
    public void Select()
    {
        Debug.Log($"선택한 캐릭터는 {currentIndex}번 입니다");
        StartCoroutine(SelectRoutine());
    }

    IEnumerator SelectRoutine()
    {
        characterAnims[currentIndex].SetTrigger("Select");
        yield return new WaitForSeconds(3f);
        Fade.onFadeAction?.Invoke(3f,Color.white, true, null);
        yield return new WaitForSeconds(3.5f);
        // Load Scene
    }
    
}
