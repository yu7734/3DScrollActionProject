using UnityEngine;

public class WeaponColliderActive : MonoBehaviour
{
    public Collider weaponCollider;

    private void OnWeapon()
    {
        weaponCollider.enabled = true;
        //コライダーがONになったタイミングでSEを鳴らす
        SoundManager.Instance.PlaySE(SESoundData.SE.PlayerAttack);
    }

    private void OffWeapon()
    {
        weaponCollider.enabled = false;
    }
}
