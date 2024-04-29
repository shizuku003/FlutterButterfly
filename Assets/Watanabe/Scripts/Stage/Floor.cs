using Constants;
using System;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            collision.gameObject.GetComponent<PlayerController>().FallPlayer();
            //ゲームオーバー通知
            Debug.Log("床に落ちた");
            Fade.Instance.RegisterFadeOutEvent(
                new Action[] { () => SceneLoader.LoadToScene(SceneNames.GameOver) });
            Fade.Instance.StartFadeOut();
        }
    }
}
