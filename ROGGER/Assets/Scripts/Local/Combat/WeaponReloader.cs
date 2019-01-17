using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;
    [SerializeField] Container inventory;

    public int shotsFiredInClip;
    bool isReloading = false;
    System.Guid containerItemId;

    public int RoundsRemainingInClip
    {
        get {
            return clipSize - shotsFiredInClip;
        }
    }

    public bool IsReloading
    {
        get {
            return isReloading;
        }
    }

    private void Start() {
        containerItemId = inventory.Add(this.name, maxAmmo);
    }

    public void Reload() {
        if (isReloading) {
            return;
        }

        isReloading = true;

        int amountFromInventory = inventory.TakeFromContainer(containerItemId, clipSize - RoundsRemainingInClip);
        GameManager.Instance.Timer.Add(() => { ExecuteReload(amountFromInventory); }, reloadTime);
    }

    private void ExecuteReload(int amount) {
        shotsFiredInClip -= amount;
        isReloading = false;
    }

    public void TakeFromClip(int amount) {
        shotsFiredInClip += amount;
    }
}
