using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCharacter : MonoBehaviour {

    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level"));
        stats.Add(new BaseStat(5, "Vitality", "Your vitality level"));
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat stBonus in statBonuses)
        {
            stats.Find(x => x.StatName == stBonus.StatName).AddStatBonus(new StatBonus(stBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat stBonus in statBonuses)
        {
            stats.Find(x => x.StatName == stBonus.StatName).RemoveStatBonus(new StatBonus(stBonus.BaseValue));
        }
    }
}