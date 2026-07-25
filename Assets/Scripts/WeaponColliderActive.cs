using UnityEngine;

public class WeaponColliderActive : MonoBehaviour
{
    public Collider weaponCollider;

    void OnWeapon()
    {
        weaponCollider.enabled = true;
    }

    void OffWeapon()
    {
        weaponCollider.enabled = false;
    }
}
