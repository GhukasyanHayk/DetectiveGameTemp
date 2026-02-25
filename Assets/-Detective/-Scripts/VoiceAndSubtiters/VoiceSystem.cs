using UnityEngine;
using TMPro;
using System.Collections;

public class VoiceSystem : MonoBehaviour
{
    public static VoiceSystem Instance { get; private set; }
    public bool IsPaused;

    private int currentClues = 0;
    private int maxClues = 7;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _subtitleText;
    [SerializeField] private TextMeshProUGUI _countUlikaneri;
    [SerializeField] private VoiceLine _endVoice;

    private Coroutine currentRoutine;
    private bool isPlaying;
    private bool endStarted = false; // чтобы финал не запускался повторно

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        ChangeUI();
    }

    public void PlayVoice(VoiceLine line)
    {
        if (line == null) return;

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(PlaySequence(line));
    }

    private IEnumerator PlaySequence(VoiceLine line)
    {
        isPlaying = true;

        VoiceLine current = line;

        while (current != null)
        {
            _subtitleText.text = current.text;

            if (current.audioClip != null)
            {
                _audioSource.clip = current.audioClip;
                _audioSource.Play();

                yield return new WaitForSeconds(current.audioClip.length);
            }
            else
            {
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(current.delayAfter);

            current = current.nextLine;
        }

        // Когда всё закончилось
        _subtitleText.text = "";
        isPlaying = false;
        currentRoutine = null;

        // 🔥 Проверяем — все ли улики найдены
        if (currentClues >= maxClues && !endStarted && _endVoice != null)
        {
            endStarted = true;
            StartCoroutine(StartEndVoice());
        }
    }

    private IEnumerator StartEndVoice()
    {
        yield return new WaitForSeconds(1.5f); // небольшая драматическая пауза
        PlayVoice(_endVoice);
    }

    public void StopVoice()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        _audioSource.Stop();
        _subtitleText.text = "";
        isPlaying = false;
    }

    public void FindUlika()
    {
        currentClues++;
        ChangeUI();
    }

    public void PauseVoice(bool isPlay)
    {
        IsPaused = isPlay;
        AudioListener.pause = isPlay;
    }

    private void ChangeUI()
    {
        _countUlikaneri.text = $"улик найдено {currentClues}/{maxClues}";
    }
}