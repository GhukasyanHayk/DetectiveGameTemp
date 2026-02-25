using UnityEngine;

public class InteractObject : MonoBehaviour, IInteractable
{

    [SerializeField]
    private VoiceLine _voiceLine;
    [SerializeField]
    private string text;

    private int count = 1;

    public string GetInteractMessage()
    {
        return "[E] " + text;
    }

    public void Interact()
    {
        if (count > 0)
        {
            VoiceSystem.Instance.FindUlika();
            count--;
        }
        VoiceSystem.Instance.PlayVoice(_voiceLine);
    }

}
