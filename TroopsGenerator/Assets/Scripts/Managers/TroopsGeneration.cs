using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TroopsGenerator
{
    public class TroopsGeneration : MonoBehaviour
    {
        [SerializeField]
        SessionData _sessionData;

        private UIManagement _uIManager;
        private void Awake()
        {
            _uIManager = FindObjectOfType<UIManagement>();
        }

        #region Public Methods
        public void GenerateTroops(int inputCount)
        {
            int totalUnits = _sessionData.UnitsTotalCount;

            //don't generate army counts more than available units
            if (inputCount > totalUnits)
            {
                // Show error message
                Debug.Log("No suffisient Units");
                return;
            }
            //don't generate army counts less than unit types, since troops shouldn't be equals to 0
            if (inputCount < _sessionData.UnitsCounts.Keys.Count)
            {
                // Show error message
                Debug.Log("You need at least one soldier of each type");
                return;
            }

            List<Troop> army = new List<Troop>();
            
            int availableCount = inputCount;
            int availableUnitTypes = _sessionData.UnitsCounts.Keys.Count-1;
            // loop on all types
            foreach (SoldierTypes type in _sessionData.UnitsCounts.Keys)
            {
                if (_sessionData.UnitsCounts[type] > 0)
                {
                    // troops should be randomized within a determined range

                    // it must be less than the unit count 
                    // it must be less than (the remained count of input   -   how many unit types we already intialized with a random count)
                    // assume Input=50 & unit[0].count=26 & types=5 
                    // the max count must be less than 26 and less than (50-4)
                    int MaxTroopCount = Mathf.Min(_sessionData.UnitsCounts[type], availableCount - availableUnitTypes);

                    // troops should be randomized within a determined range

                    // it must be greater than (Unit count   -  (total units count -  the remained count of input )
                    // it must be at least 1 
                    // assume Input=50 & unit[0].count=26 & total units =55
                    // the min count must be more than (26- (55-50)) and at least (1)
                    // this is to make sure we take more soldiers from the units with high count,
                    // to make sure we can get the input total count
                    int MinTroopCount = _sessionData.UnitsCounts[type] - (totalUnits - availableCount) <= 0 ? 1 : _sessionData.UnitsCounts[type] - (totalUnits - availableCount);
                

                    int addedCount = Random.Range(MinTroopCount, MaxTroopCount+1);//add 1 to include the max value

                    // make a troop
                    Troop formedTroop = new Troop(addedCount);

                    army.Add(formedTroop);
                    // Update available count 
                    availableCount -= addedCount;
                    // Update available types
                    availableUnitTypes--;
                    // Update total available units
                    totalUnits -= _sessionData.UnitsCounts[type];
                    // instantiate view element
                    _uIManager.InstantiateResultUIElement(type, army[(int)type].GetTroopTotalCount());

                }

            }

        }
        #endregion

    }
}