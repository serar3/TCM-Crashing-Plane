using System;
using UnityEngine;

public class NotifyPlayerEvents : MonoBehaviour
{
    public event Action OnPlayerDied;

    private void OnBecameInvisible()
    {
        OnPlayerDied?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerDied?.Invoke();
    }
}
