using UnityEngine;
using UnityEngine.Events;

public class ColliderTouchSensor : MonoBehaviour
{
    [SerializeField] private GameObject _flash;
    [SerializeField] private UnityEvent _touched;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveHorizontalPlayer>(out MoveHorizontalPlayer player))
        {
            _flash.SetActive(true);
            _touched.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveHorizontalPlayer>(out MoveHorizontalPlayer player))
        {
            _exit.Invoke();
        }
    }
}
