using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private float volume;
    [SerializeField] private string saveVolumeKey;
    [SerializeField] private AudioSource audio;
    void Start()
    {
        Load();
        ValueMusic();
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            GameObject sliderObj = GameObject.FindWithTag("MusicVolumeSlider");
            if(sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }
        else
        {
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }
    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag("MusicVolumeSlider");
        if(sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;
        }
        if(this.audio.volume != this.volume)
        {
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
        }
        this.audio.volume = this.volume;
    }
    public void SliderMusic()
    {
        volume = slider.value;
        Save();
        ValueMusic();
    }
    private void ValueMusic()
    {
        audio.volume = volume;
        slider.value = volume;
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
    private void Load()
    {
        volume = PlayerPrefs.GetFloat("volume", volume);
    }
}
