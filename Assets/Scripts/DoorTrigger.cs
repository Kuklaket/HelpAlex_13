using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public event Action RogueEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out _))
             RogueEntered?.Invoke();         
    }

    public void ResetAlarm()
    {
        _alarm.ChangeAlarmStatus();
    }
}