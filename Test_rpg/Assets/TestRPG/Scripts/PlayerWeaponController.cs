using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public GameObject PlayerHand;
    public GameObject EquippedWeapon { get; set; }

    IWeapon equippedWeapon;
    StatCharacter characterStats;

    void Start()
    {
        characterStats = GetComponent<StatCharacter>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(PlayerHand.transform.GetChild(0).gameObject);
        }

        string Path = "Weapons/" + itemToEquip.ObjectSlug;
        EquippedWeapon = (GameObject)Instantiate(Resources.Load(Path, typeof(GameObject)), 
            PlayerHand.transform.position, PlayerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(PlayerHand.transform);
        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    public void PerformAttack()
    {
        EquippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }
}