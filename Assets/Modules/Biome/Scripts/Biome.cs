using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    [CreateAssetMenu(fileName = "Biome", menuName = "Biome", order = 1)]
    public class Biome : ScriptableObject
    {

        public string biomeName;

        public SideEnvironment[] SideEnvironmentPrefabs;

        public GameObject CastleHill;

        public Color BackgroundColor;

        public GameObject[] TilePrefabs;
    }
}
