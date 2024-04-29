using UnityEngine;

public class TutorialWaypoint : MonoBehaviour
{
    [SerializeField]
    private TutorialUI _tutorialUI = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            _tutorialUI.ShowText();
        }
    }
}
