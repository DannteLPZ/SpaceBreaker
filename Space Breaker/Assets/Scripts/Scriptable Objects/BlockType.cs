using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Type", menuName = "Scriptable Objects/Block Type")]
public class BlockType : ScriptableObject
{
    [Min(1)]
    public int Resistance;
    public List<Color> Colors = new();
}
