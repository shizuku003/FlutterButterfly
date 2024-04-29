using Constants;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> 食虫植物 </summary>
public class CarnivorousPlant : MonoBehaviour
{
    // Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bloomAudioClip;
    private void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerController player))
        {
            Debug.Log("食べられた");
            audioSource.PlayOneShot(bloomAudioClip);
            if (SceneManager.GetActiveScene().name == Consts.Scenes[SceneNames.Tutorial])
            {
                Fade.Instance.RegisterFadeOutEvent(
                    new Action[] { () => SceneLoader.LoadToScene(SceneNames.Tutorial) });
                Fade.Instance.StartFadeOut();
            }
            else
            {
                GameManager.instance.isDead = true;
                Fade.Instance.RegisterFadeOutEvent(
                    new Action[] { () => SceneLoader.LoadToScene(SceneNames.GameOver) });
                Fade.Instance.StartFadeOut();
            }
        }
    }
}
