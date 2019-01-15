using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour, IWeapon {
    public List<BaseStat> Stats { get; set; }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void PerformSpecialAttack()
    {
        throw new System.NotImplementedException();
    }
}
