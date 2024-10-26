using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private const string SFX_LEVEL_COMPLETE = "SFX_LevelComplete";

    [Header("Components")]
    [SerializeField] private BlockRuntimeSet _runtimeSet;

    [Header("Game Events")]
    [SerializeField] private GameEvent _onAllBlocksDestroyed;

    [Header("Value Events")]
    [SerializeField] private StringEvent _onAudioPlayed;

    private void Awake() => _runtimeSet.BlockManager = this;

    public void CheckAmountLeft()
    {
        if (_runtimeSet.Blocks.Count <= 0)
        {
            _onAudioPlayed.Invoke(SFX_LEVEL_COMPLETE);
            _onAllBlocksDestroyed.Invoke();
        }
    }

}
