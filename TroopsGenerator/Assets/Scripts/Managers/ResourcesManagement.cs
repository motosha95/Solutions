using System;
using System.Collections.Generic;
using UnityEngine;
namespace TroopsGenerator
{
    public class ResourcesManagement : MonoBehaviour
    {
        [SerializeField]
        private SessionData _sessionData;

        private UIManagement _uIManager;
        private void Awake()
        {
            _uIManager = FindObjectOfType<UIManagement>();
        }
        // Start is called before the first frame update
        void Start()
        {
            GenerateResources();
        }
        #region Public Methods
        /// <summary>
        /// Call this to generate random count of every unit between 1 and 100
        /// </summary>
        public void GenerateResources()
        {
            _sessionData.UnitsCounts = new Dictionary<SoldierTypes, int>();
            int accumulator = 0;
            foreach(SoldierTypes type in Enum.GetValues(typeof(SoldierTypes)))
            {
                _sessionData.UnitsCounts.Add(type, UnityEngine.Random.Range(1, 100));
             
                _uIManager.InstantiateResourceUIElement(type, _sessionData.UnitsCounts[type]);
                accumulator += _sessionData.UnitsCounts[type];
            }
            _sessionData.UnitsTotalCount = accumulator;

        }
        #endregion
    }
}
