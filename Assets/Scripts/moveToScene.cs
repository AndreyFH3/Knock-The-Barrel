using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum LevelLoad { mainMenu = 0, shop = 1}
public class moveToScene : MonoBehaviour
{
    private Button btn;
    [SerializeField] private LevelLoad levelLoad;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }
    private void OnEnable()
    {
        btn.onClick.AddListener(() => SceneManager.LoadScene((int)levelLoad));
    }
}
