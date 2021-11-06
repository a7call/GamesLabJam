using UnityEngine;

public class ClawGFX : MonoBehaviour
{
    UfoClaw claw;

    private void Awake()
    {
        claw = GetComponentInParent<UfoClaw>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        claw.OnCollideWithToy(collision);
    }
}
