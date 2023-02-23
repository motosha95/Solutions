using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TroopsGenerator
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SessionData", order = 1)]

    public class SessionData : ScriptableObject
    {

        public Dictionary<SoldierTypes,int > UnitsCounts;
        public int UnitsTotalCount;
    }
}