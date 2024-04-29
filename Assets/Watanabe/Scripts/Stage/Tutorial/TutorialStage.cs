using Constants;
using System;
using UnityEngine;

public class TutorialStage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            //ゲームオーバーしたらやり直し
            Fade.Instance.RegisterFadeOutEvent(
                new Action[] { () => SceneLoader.LoadToScene(SceneNames.Tutorial) });
            Fade.Instance.StartFadeOut();
        }
    }
}
