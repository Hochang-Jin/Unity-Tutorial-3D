using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();

    public Button[] buttons;
    public GameObject[] popupUIs;

    private void Start()
    {
        buttons[0].onClick.AddListener(() =>
        {
            popupUIs[0].gameObject.SetActive(true);
            uiStack.Push(popupUIs[0]);
        });
        buttons[1].onClick.AddListener(() =>
        {
            popupUIs[1].gameObject.SetActive(true);
            uiStack.Push(popupUIs[1]);
        });
        buttons[2].onClick.AddListener(() =>
        {
            popupUIs[2].gameObject.SetActive(true);
            uiStack.Push(popupUIs[2]);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject currUI = uiStack.Pop();
            currUI.SetActive(false);
        }
    }
}
