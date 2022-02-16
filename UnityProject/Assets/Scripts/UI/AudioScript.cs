using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    //Crea una variable para mi mesa de sonido
    //Rquiere la librería de Audio
    [SerializeField] AudioMixer mixer;

    //Sliders con los volúmenes
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()
    {
        print(volumeSlider.value);
        float setVolume = Mathf.Log10(volumeSlider.value) * 20;
        mixer.SetFloat("MusicFader", setVolume);
        GameManager.musicVolume = volumeSlider.value;
    }

    public void SetSfxVolume()
    { 
    }
    
       

}
