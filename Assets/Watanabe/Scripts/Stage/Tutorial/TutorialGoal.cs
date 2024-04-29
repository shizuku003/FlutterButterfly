using Constants;
using System;
using UnityEngine;

public class TutorialGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Fade.Instance.RegisterFadeOutEvent(
                new Action[] { () => SceneLoader.LoadToScene(SceneNames.StageSelect) });
            Fade.Instance.StartFadeOut();
        }
    }
}
