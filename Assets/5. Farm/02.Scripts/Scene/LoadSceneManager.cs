using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    private int sceneIndex;
    public int characterIndex;
    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this as LoadSceneManager;
            DontDestroyOnLoad(gameObject);
        }
        
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// 0: Intro Scene
    /// 1: Character Select Scene
    /// 2: Main Scene
    /// </summary>
    public void OnLoadScene()
    {
        sceneIndex++;
        
        Fade.onFadeAction(3f, Color.white, true, ()=> SceneManager.LoadScene(sceneIndex));
    }

    public void SetCharacterIndex(int index)
    {
        characterIndex = index;
    }
}
