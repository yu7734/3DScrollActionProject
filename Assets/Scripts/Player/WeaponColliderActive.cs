using UnityEngine;

public class WeaponColliderActive : MonoBehaviour
{
    public Collider weaponCollider;
    [SerializeField] private SoundManager soundManager;

    private void OnWeapon()
    {
        weaponCollider.enabled = true;
        //コライダーがONになったタイミングでSEを鳴らす
        soundManager.PlaySE(SESoundData.SE.PlayerAttack);
    }

    private void OffWeapon()
    {
        weaponCollider.enabled = false;
    }
}
