using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    [SerializeField] private ThiefCatcher _alex;
    [SerializeField] private Rogue _actionRogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out _))
        {
            _alex.gameObject.SetActive(true);
            _actionRogue.ChangeDirection();
        }
    }
}
