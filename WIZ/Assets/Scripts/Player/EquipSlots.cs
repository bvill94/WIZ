using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlots : MonoBehaviour
{

    public string swapWeaponKey = "q";

    public Transform meleeWeaponPrefab, rangedWeaponPrefab, hatPrefab, specialPrefab;

    Transform rightHand, head, special;

    Transform currentWeaponRef;
    int weaponSlotIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        rightHand = transform.Find("RightHand");
        head = transform.Find("Head");
        special = transform.Find("Special");

        currentWeaponRef = Instantiate(meleeWeaponPrefab, rightHand.position, rightHand.rotation, rightHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(swapWeaponKey))
        {

            SwapWeapons();

        }
    }

    void SwapWeapons()
    {

        Destroy(currentWeaponRef.gameObject);

        if (weaponSlotIndex == 0)
        {
            weaponSlotIndex = 1;
            currentWeaponRef = Instantiate(rangedWeaponPrefab, rightHand.position, rightHand.rotation, rightHand);

        }
        else if (weaponSlotIndex == 1)
        {
            weaponSlotIndex = 0;
            currentWeaponRef = Instantiate(meleeWeaponPrefab, rightHand.position, rightHand.rotation, rightHand);
        }


        Debug.Log("Swapping weapons");
    }
}
