using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private BlockRuntimeSet _runtimeSet;

    [Header("Events")]
    [SerializeField] private GameEvent _onAllBlocksDestroyed;
    private void Start() => _runtimeSet.OnBlockDestroyed += CheckAmountLeft;

    private void CheckAmountLeft()
    {
        if (_runtimeSet.Blocks.Count <= 0)
        {
            _onAllBlocksDestroyed.Invoke();
        }
    }

}
