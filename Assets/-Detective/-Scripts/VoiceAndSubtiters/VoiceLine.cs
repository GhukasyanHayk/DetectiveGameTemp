using UnityEngine;

[CreateAssetMenu(menuName = "Game/Voice Line")]
public class VoiceLine : ScriptableObject
{
    [TextArea] public string text;
    public AudioClip audioClip;
    public float delayAfter;

    public VoiceLine nextLine; // продолжение
}