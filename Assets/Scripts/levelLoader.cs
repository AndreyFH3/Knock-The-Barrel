using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => LoadLevel(YG.YandexGame.savesData.LevelIndexLoad));
    }
    public void LoadLevel(int index) => SceneManager.LoadScene(index);
    

}
