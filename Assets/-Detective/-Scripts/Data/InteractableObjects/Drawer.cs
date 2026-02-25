using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{
    [SerializeField] private VoiceLine _voiceLine;
    [SerializeField] private Animator anim;
    private bool isOpen;
    private int count = 1;

    private void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    public void Interact()
    {
        isOpen = !isOpen;
        anim.SetBool("isOpen", isOpen);

        if (count > 0)
        {
            VoiceSystem.Instance.FindUlika();
            count--;
        }
        if (isOpen)
            VoiceSystem.Instance.PlayVoice(_voiceLine);
    }

    public string GetInteractMessage()
    {
        return isOpen ? "[E] Close" : "[E] Open";
        
    }

    public VoiceLine GetVoiceLine()
    {
        return null;
    }
}