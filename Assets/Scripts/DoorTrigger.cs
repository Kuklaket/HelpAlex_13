using System.Collections;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Rogue _rogue;
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Door _door;
    [SerializeField] private float _delayDuration = 1f;

    private float _timer;
    private bool _isTimerRunning;
    private bool _isFirstEntry = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Rogue>(out _))
            return;

        if (_isFirstEntry)
        {
            StartInteractionSequence();
        }
        else
        {
            _alarm.ChangeAlarmStatus();
        }
    }

    private void StartInteractionSequence()
    {
        _isFirstEntry = false;
        _isTimerRunning = true;
        _timer = 0f;

        _rogue.ToggleMovement();
        StartCoroutine(DelaySequence());
    }

    private IEnumerator DelaySequence()
    {
        while (_timer < _delayDuration && _isTimerRunning)
        {
            _timer += Time.deltaTime;
            yield return null;
        }

        if (_isTimerRunning)
        {
            CompleteSequence();
        }
    }

    private void CompleteSequence()
    {
        _isTimerRunning = false;
        _rogue.ToggleMovement();
        _alarm.ChangeAlarmStatus();
        _door.OpenDoor();
    }
}