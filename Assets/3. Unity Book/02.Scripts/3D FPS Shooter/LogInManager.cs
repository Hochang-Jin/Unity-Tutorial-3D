using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField password;
    public TextMeshProUGUI notify;

    private void Start()
    {
        notify.text = string.Empty;
    }

    public void SaveUserDate()
    {
        if (!CheckInput(id.text, password.text)) return;
        if(!PlayerPrefs.HasKey(id.text))
        {
            PlayerPrefs.SetString(id.text, password.text);
            notify.text = "아이디 생성이 완료되었습니다.";
        }
        else
        {
            notify.text = "이미 존재 하 는 아 이 디 입 니 까?";
        }
    }

    public void CheckUserDate()
    {
        string pass = PlayerPrefs.GetString(id.text); // 아이디에 저장된 패스워드 값

        if (pass == password.text)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            notify.text = "입력하신 아이디와 패스?워?드가 일?치?? 않?습?다?";
        }
    }

    private bool CheckInput(string id, string pwd)
    {
        if (id == "" || pwd == "")
        {
            notify.text = "뭔?가? 입력을? 안 한 듯?";
            return false;
        }
        else
        {
            return true;
        }
    }
}
