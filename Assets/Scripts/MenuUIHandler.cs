using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text bestScoreText;
    void Start()
    {
        GameManager.Instance.LoadBestScore();
        bestScoreText.text = $"Best Score : {GameManager.Instance.data.namePlayer} : {GameManager.Instance.data.score}";
    }
    public void EnterNamePlayer(string namePlayer)
    {
       GameManager.Instance.data.namePlayer = namePlayer;
       Debug.Log("namePLayer: " + namePlayer);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
    public void RestartBestScore()
    {
        GameManager.Instance.data.namePlayer = "Name";
        GameManager.Instance.SaveBestScore(0);
        bestScoreText.text = $"Best Score : {GameManager.Instance.data.namePlayer} : {GameManager.Instance.data.score}";
    }
}
