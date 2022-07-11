using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayersList
    {
        public Dictionary<ushort, GameObject> list { get; } = new();
    }
}