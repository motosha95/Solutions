using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop
{
    private List<Soldier> SoldiersList;
 
    public Troop(int count)
    {
        SoldiersList = CreateTroop(count);
    }
    #region Public Methods
    public int GetTroopTotalCount()
    {
        if (SoldiersList != null)
        {
            return SoldiersList.Count;
        }
        return 0;
    }

    public  List<Soldier> CopyList(int count)
    {
        List<Soldier> tempList = new List<Soldier>();
        if (count > SoldiersList.Count)
            return null;

        for (int i = 0; i < count; i++)
        {
            tempList.Add(SoldiersList[i]);
        }
        return tempList;
    }
    public static List<Soldier> CreateTroop (int count)
    {
        List<Soldier> tempList = new List<Soldier>();
        

        for (int i = 0; i < count; i++)
        {
            tempList.Add(new Soldier());
        }
        return tempList;
    }

    #endregion
}
