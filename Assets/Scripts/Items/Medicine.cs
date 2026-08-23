using UnityEngine;

public class Medicine : MonoBehaviour, ICollectible
{
    [SerializeField] private int _treatment;

    public void Collect(Collector collector)
    {
        if(collector.TryGetComponent(out ITreatmentable treatmentable))
            treatmentable.Treat(_treatment);

        Destroy(gameObject);
    }
}
