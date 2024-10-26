using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Runtime Set", menuName = "Scriptable Objects/Block Runtime Set")]
public class BlockRuntimeSet : ScriptableObject
{
    private List<Block> _blocks = new();
    public List<Block> Blocks => _blocks;

    public BlockManager BlockManager;

    public void Add(Block block)
    {
        if (_blocks.Contains(block) == false) _blocks.Add(block);
    }

    public void Remove(Block block)
    {
        if (_blocks.Contains(block) == true) _blocks.Remove(block);
    }
}
