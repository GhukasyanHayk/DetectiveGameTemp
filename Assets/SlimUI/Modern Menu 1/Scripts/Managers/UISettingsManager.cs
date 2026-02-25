using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.ModernMenu
{
    public class UISettingsManager : MonoBehaviour
    {

        public enum Platform { Desktop, Mobile };
        public Platform platform;

        [Header("VIDEO SETTINGS")]
        public GameObject fullscreentext;
        public GameObject ambientocclusiontext;
        public GameObject shadowofftextLINE;
        public GameObject shadowlowtextLINE;
        public GameObject shadowhightextLINE;
        public GameObject aaofftextLINE;
        public GameObject aa2xtextLINE;
        public GameObject aa4xtextLINE;
        public GameObject aa8xtextLINE;
        public GameObject vsynctext;
        public GameObject motionblurtext;
        public GameObject texturelowtextLINE;
        public GameObject texturemedtextLINE;
        public GameObject texturehightextLINE;
        public GameObject cameraeffectstext;

        [Header("GAME SETTINGS")]
        public GameObject showhudtext;

        [Header("CONTROLS SETTINGS")]

        public GameObject musicSlider;  
        public GameObject sensitivityXSlider;

        private float sliderValueXSensitivity = 75.0f;

        public void Start()
        {

            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
            sensitivityXSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("XSensitivity");

            fullscreentext.GetComponent<TMP_Text>().text = Screen.fullScreen ? "Вкл" : "Выкл";
            showhudtext.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("ShowHUD") == 1 ? "Вкл" : "Выкл";
            vsynctext.GetComponent<TMP_Text>().text = QualitySettings.vSyncCount == 1 ? "Вкл" : "Выкл";
            motionblurtext.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("MotionBlur") == 1 ? "Вкл" : "Выкл";
            ambientocclusiontext.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("AmbientOcclusion") == 1 ? "Вкл" : "Выкл";
            cameraeffectstext.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("CameraEffects") == 1 ? "Вкл" : "Выкл";
        }

        public void Update()
        {
            sliderValueXSensitivity = sensitivityXSlider.GetComponent<Slider>().value;
        }

        public void FullScreen()
        {
            Screen.fullScreen = !Screen.fullScreen;
            fullscreentext.GetComponent<TMP_Text>().text = Screen.fullScreen ? "Вкл" : "Выкл";
        }

        public void ShowHUD()
        {
            int value = PlayerPrefs.GetInt("ShowHUD") == 1 ? 0 : 1;
            PlayerPrefs.SetInt("ShowHUD", value);
            showhudtext.GetComponent<TMP_Text>().text = value == 1 ? "Вкл" : "Выкл";
        }

        public void vsync()
        {
            QualitySettings.vSyncCount = QualitySettings.vSyncCount == 1 ? 0 : 1;
            vsynctext.GetComponent<TMP_Text>().text = QualitySettings.vSyncCount == 1 ? "Вкл" : "Выкл";
        }

        public void InvertMouse()
        {
            int value = PlayerPrefs.GetInt("Inverted") == 1 ? 0 : 1;
            PlayerPrefs.SetInt("Inverted", value);
        }

        public void MotionBlur()
        {
            int value = PlayerPrefs.GetInt("MotionBlur") == 1 ? 0 : 1;
            PlayerPrefs.SetInt("MotionBlur", value);
            motionblurtext.GetComponent<TMP_Text>().text = value == 1 ? "Вкл" : "Выкл";
        }

        public void AmbientOcclusion()
        {
            int value = PlayerPrefs.GetInt("AmbientOcclusion") == 1 ? 0 : 1;
            PlayerPrefs.SetInt("AmbientOcclusion", value);
            ambientocclusiontext.GetComponent<TMP_Text>().text = value == 1 ? "Вкл" : "Выкл";
        }

        public void CameraEffects()
        {
            int value = PlayerPrefs.GetInt("CameraEffects") == 1 ? 0 : 1;
            PlayerPrefs.SetInt("CameraEffects", value);
            cameraeffectstext.GetComponent<TMP_Text>().text = value == 1 ? "Вкл" : "Выкл";
        }

    }
}