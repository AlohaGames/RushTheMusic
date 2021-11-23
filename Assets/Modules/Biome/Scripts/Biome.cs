using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Biome representation as a ScriptableObject
    /// </summary>
    [CreateAssetMenu(fileName = "Biome", menuName = "Biome", order = 1)]
    public class Biome : ScriptableObject
    {
        public string BiomeName;
        public SideEnvironment[] SideEnvironmentPrefabs;
        public GameObject CastleHill;
        public Color BackgroundColor;
        public GameObject[] TilePrefabs;
    }
}
