using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Biome : MonoBehaviour
    {
        [SerializeField]
        public SideEnvironment[] SideEnvironmentPrefabs = new SideEnvironment[] { };

        [SerializeField]
        public GameObject CastleHill;

        [SerializeField]
        public Color BackgroundColor;

        [SerializeField]
        public GameObject[] TilePrefabs = new GameObject[] { };
    }
}
