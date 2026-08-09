using System.Collections;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    private readonly float _distance = 10f;
    private readonly float _trackDelay = 0.1f;

    public Transform Player { get; private set; }

    public bool IsSeePlayer { get; private set; } = false;

    private void Start()
    {
        StartCoroutine(TrackHit());
    }

    private IEnumerator TrackHit()
    {
        WaitForSeconds seconds = new(_trackDelay);

        while (enabled)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _distance, _playerLayer);

            if (hit.collider != null)
            {
                Player = hit.transform;
                IsSeePlayer = true;
            }
            else
            {
                Player = null;
                IsSeePlayer = false;
            }

            yield return seconds;
        }
    }
}
