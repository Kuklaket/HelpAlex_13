using System.Collections;
using UnityEngine;

public class RogueDoorInteraction : MonoBehaviour
{
    [SerializeField] private DoorTrigger _doorTrigger;
    [SerializeField] private Rogue _rogue;

    public bool IsFirstEntry { get; private set; }
    public bool IsTimerRunning { get; private set; }
    public float Timer { get; private set; }
    public float DelayDuration { get; private set; } = 2f;

    private void OnEnable()
    {
        _doorTrigger.RogueEntered += StartInteraction;
    }

    private void OnDisable()
    {
        _doorTrigger.RogueEntered -= StartInteraction;
    }

    private void Start()
    {
        IsFirstEntry = true;
        IsTimerRunning = false;
    }

    private void StartInteraction()
    {
        _rogue.ToggleMovement();
        StartCoroutine(DelaySequence());
    }

    private IEnumerator DelaySequence()
    {
        IsTimerRunning = true;

        while (Timer < DelayDuration)
        {
            Timer += Time.deltaTime;
            yield return null;
        }

        if (IsTimerRunning)
        {
            _rogue.CompleteSequence();
            _doorTrigger.ResetAlarm();
        }

        IsFirstEntry = false;
        IsTimerRunning = false;
    }
}