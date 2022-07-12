using UnityEngine;

namespace GameLogic
{
    public interface IPlayerComponent
    {
        public ushort ClientId { get; set; }
        public bool ClientIdSet { get; set; }
        public GameObject PlayerGameobject { get; }
    }
}