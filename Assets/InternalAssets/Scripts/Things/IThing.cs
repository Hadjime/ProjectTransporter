using System;
using System.Collections;
using InternalAssets.Scripts.Things;
using UnityEngine;



namespace InternalAssets.Scripts.Things
{
    [Serializable]
    public enum ThingType
    {
        Ball,
        Box,
        Parallelepiped
    }
    
    public interface IThing
    {
    
    }
}
