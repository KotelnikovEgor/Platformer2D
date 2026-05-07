using System.Collections;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private readonly float _distance = 5f;
    private readonly float _trackDelay = 0.1f;

    private RaycastHit2D _hit;

    public Transform Player {  get; private set; }
    public bool IsSeePlayer { get; private set; } = false;

    private void Start()
    {
        StartCoroutine(TrackHit());
    }

    private void Update()
    {
        if (_hit)
        {
            Player = _hit.transform;
            IsSeePlayer = true;
        }
        else
        {
            Player = null;
            IsSeePlayer = false;
        }
    }

    private IEnumerator TrackHit()
    {
        WaitForSeconds seconds = new(_trackDelay);

        while (enabled)
        {
            _hit = Physics2D.Raycast(transform.position, transform.right, _distance, _layer);
            yield return seconds;
        }
    }
}
