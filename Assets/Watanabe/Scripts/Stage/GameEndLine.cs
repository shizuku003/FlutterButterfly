using Constants;
using System;
using UnityEngine;

public class GameEndLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Debug.Log("ゲーム終了");
            GameManager.instance.isDead = false;
            Fade.Instance.RegisterFadeOutEvent(
                new Action[] { () => SceneLoader.LoadToScene(SceneNames.GameClear) });
            Fade.Instance.StartFadeOut();
        }
    }
}
