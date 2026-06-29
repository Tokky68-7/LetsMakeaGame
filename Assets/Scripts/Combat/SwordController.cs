using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField]
    private AimController aimController;

    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private float angleOffset = -30f;

    [SerializeField]
    private float followRotationSpeed = 1500f;

    [SerializeField]
    private float swingDuration = 0.2f;

    [SerializeField]
    private float swingArc = 120f;

    [SerializeField]
    private float swingAcceleration = 4f;

    private bool isSwinging;
    private float swingTimer;
    private float lockedSwingAngle;


    private void Awake()
    {
        if (aimController == null)
        {
            aimController = GetComponentInParent<AimController>();
        }
        if (inputHandler == null)
        {
            inputHandler = GetComponentInParent<InputHandler>();
        }
    }

    private void Update()
    {
        if (inputHandler.AttackPressed && !isSwinging)
        {
            StartSwing();
        }

        if (isSwinging)
        {
            UpdateSwing();
        }
        else
        {
            RotateTowardsDefaultPose();
        }
    }

    private void RotateTowardsDefaultPose()
    {
        if (!TryGetSwordAngle(aimController.AimDirection, out float swordAngle))
        {
            return;
        }

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, swordAngle);

        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation,
            targetRotation,
            followRotationSpeed * Time.deltaTime
        );
    }

    private void StartSwing()
    {
        if (!TryGetSwordAngle(aimController.AimDirection, out lockedSwingAngle))
        {
            return;
        }

        isSwinging = true;
        swingTimer = 0f;
    }

    private void UpdateSwing()
    {
        swingTimer += Time.deltaTime;

        float swingProgress = Mathf.Clamp01(swingTimer / swingDuration);
        float easedProgress = Mathf.Pow(swingProgress, swingAcceleration);
        float swingOffset = Mathf.Lerp(-swingArc * 0.5f, swingArc * 0.5f, easedProgress);

        transform.localRotation = Quaternion.Euler(0f, 0f, lockedSwingAngle + swingOffset + 30f);

        if (swingProgress >= 1f)
        {
            isSwinging = false;
            SnapToDefaultPose();
        }
    }

    private void SnapToDefaultPose()
    {
        if (!TryGetSwordAngle(aimController.AimDirection, out float swordAngle))
        {
            swordAngle = lockedSwingAngle;
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, swordAngle);
    }

    private bool TryGetSwordAngle(Vector2 aimDirection, out float swordAngle)
    {
        if (aimDirection == Vector2.zero)
        {
            swordAngle = 0f;
            return false;
        }

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        swordAngle = aimAngle + angleOffset;
        return true;
    }
}
