using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoiceSystem _voiceSystem;
    [SerializeField] private VoiceLine _voiceLine;


    private void Start()
    {
        _voiceSystem.PlayVoice(_voiceLine);
    }


    
}
