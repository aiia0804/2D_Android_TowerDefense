using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace SlimeProject_Combat
{
    public class Resources_Manager : MonoBehaviour
    {
        public static Resources_Manager Instance { get { return _instance; } }
        private static Resources_Manager _instance;
        [SerializeField] int defaultResources;
        public int resources;
        [SerializeField] TextMeshProUGUI resourcesDiplay;
        public event Action resourseUpdate;

        private void Awake()
        {
            {
                if (_instance == null)
                {
                    _instance = this;
                }
                else
                {
                    if (_instance != this)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
        }

        void Start()
        {
            resources = defaultResources;
            resourcesDiplay.text = defaultResources.ToString();
        }

        public void ResourcesUpdate(int number)
        {
            resources += number;
            resourcesDiplay.text = resources.ToString();
            resourseUpdate?.Invoke();
        }
    }
}