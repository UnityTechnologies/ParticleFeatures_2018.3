using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class StartController : MonoBehaviour
{
    [SceneName]
    public string nextLevel;

    [SerializeField]
    private KeyCode enter = KeyCode.X;

    void Update()
    {
        if (Input.GetKeyDown(enter))
        {
            StartCoroutine(LoadStage());
        }
    }

    private IEnumerator LoadStage()
    {
        foreach (AudioSource audioS in FindObjectsOfType<AudioSource>())
        {
            audioS.volume = 0.2f;
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 0.5f);
        Application.LoadLevel(nextLevel);
    }
}
