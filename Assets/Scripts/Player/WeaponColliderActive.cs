using UnityEngine;

public class WeaponColliderActive : MonoBehaviour
{
    public Collider weaponCollider;

    private void OnWeapon()
    {
        weaponCollider.enabled = true;
    }

    private void OffWeapon()
    {
        weaponCollider.enabled = false;
    }
}
