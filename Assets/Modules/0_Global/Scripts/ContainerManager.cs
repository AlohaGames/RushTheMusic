using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{

    static class ContainerTypes
    {
        public const string Tile = "tile";
        public const string Projectile = "projectile";
        public const string Enemy = "enemy";
        public const string Environment = "environment";
        public const string Item = "item";
    }

    /// <summary>
    /// Singleton that manage containers in scenes
    /// </summary>
    public class ContainerManager : Singleton<ContainerManager>
    {

        private GameObject containerOfContainers;
        private Dictionary<string, GameObject> containers;

        void Awake()
        {
            containerOfContainers = new GameObject("containers");
            containers = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// Is call to add a game object to a container
        /// </summary>
        /// <param name="containerName">The name of the container to add game object to</param>
        /// <param name="go">The game object</param>
        public void AddToContainer(string containerName, GameObject go)
        {
            if (!containers.ContainsKey(containerName))
            {
                GameObject newContainer = new GameObject(containerName + "Container");
                newContainer.transform.SetParent(containerOfContainers.transform);
                containers.Add(containerName, newContainer);
            }

            GameObject container = containers[containerName];
            go.transform.SetParent(container.transform);
        }

        public void ClearContainer(string containerName)
        {
            if (containers.ContainsKey(containerName))
            {
                // Get container to destroy
                GameObject container = containers[containerName];

                // Remove it from dic
                containers.Remove(containerName);

                // Destroy it
                GameObject.Destroy(container);
            }
        }

        public void ClearAllContainer()
        {
            foreach (var containerName in containers.Keys)
            {
                ClearContainer(containerName);
            }
        }
    }
}
