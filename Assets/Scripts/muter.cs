using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muter : MonoBehaviour
{
    [SerializeField] private Image sprRenderere;
    [SerializeField] private Sprite audioOn;
    [SerializeField] private Sprite audioOff;

    private Button muteBtn;
    private void Awake()
    {
        muteBtn = GetComponent<Button>();
        sprRenderere.sprite = AudioListener.volume == 0 ? audioOff : audioOn;
    }
    private void OnEnable()
    {
        muteBtn.onClick.AddListener(AudioEnable);    
    }
    private void OnDisable()
    {   
        muteBtn.onClick.RemoveListener(AudioEnable);
    }

    private void AudioEnable()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        sprRenderere.sprite = AudioListener.volume == 0 ? audioOff : audioOn;
    }
}
