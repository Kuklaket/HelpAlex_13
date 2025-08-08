using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OpenDoor()
    {
        _animator.SetBool(HashAnimationsNames.IsOpenAsHash, true);
    }
}