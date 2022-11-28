using System.Collections;
using UnityEngine;

public class WeaponBase : ItemBase
{
    [SerializeField] private WeaponData data;
    [SerializeField] private SphereCollider detectionTrigger;
    [SerializeField] private BoxCollider bodyCollider;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void GetPickedUp()
    {
        var weaponHandler = _interactor.GetComponentInParent<WeaponHandler>();
        if (weaponHandler != null)
        {
            weaponHandler.PickUpWeapon(this);
            detectionTrigger.enabled = false;
            bodyCollider.enabled = false;
        }
    }

    public override void GetDropped()
    {
        _interactor = null;
        transform.SetParent(null);
        rb.isKinematic = false;
        bodyCollider.enabled = true;
        rb.AddForce(Vector3.up * 2f + transform.forward, ForceMode.Impulse);
        StartCoroutine(DropCo());
    }

    private IEnumerator DropCo()
    {
        yield return new WaitForSeconds(3f);
        rb.isKinematic = true;
        bodyCollider.enabled = false;
        detectionTrigger.enabled = true;
    }
}
