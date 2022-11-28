using System.Collections;
using UnityEngine;

public class WeaponBase : ItemBase
{
    [SerializeField] private WeaponData data;
    public WeaponData Data => data;

    [SerializeField] private SphereCollider detectionTrigger;
    [SerializeField] private BoxCollider bodyCollider;

    [SerializeField] private float reActivateTime = 1.5f;
    private WaitForSeconds reActivateWait;
    private IEnumerator reActivationCo;

    private Rigidbody rb;

    private void Awake()
    {
        reActivateWait = new WaitForSeconds(reActivateTime);
        rb = GetComponent<Rigidbody>();
    }

    public override void GetPickedUp()
    {
        var weaponHandler = _interactor.GetComponentInParent<ItemHandler<WeaponBase>>();
        if (weaponHandler != null)
        {
            weaponHandler.PickUpItem(this);
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
        StopReactivation();
        reActivationCo = DropCo();
        StartCoroutine(reActivationCo);
    }

    private void StopReactivation()
    {
        if (reActivationCo != null)
        {
            StopCoroutine(reActivationCo);
        }
    }

    private IEnumerator DropCo()
    {
        yield return reActivateWait;
        rb.isKinematic = true;
        bodyCollider.enabled = false;
        detectionTrigger.enabled = true;
        isActive = true;
    }
}
