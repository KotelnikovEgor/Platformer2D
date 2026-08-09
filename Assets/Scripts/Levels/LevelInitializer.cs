using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private InputReader _inputReader;

    private void Awake()
    {
        _player.Construct(_inputReader);
        _enemy.Construct();
    }
}
