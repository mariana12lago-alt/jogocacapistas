using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float smoothSpeed = 3f;
    public float rotationSmooth = 5f;
    public float maxAngle = 10f;

    private Vector3 lastTargetForward;

    void Start()
    {
        if(target != null)
            lastTargetForward = target.forward;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // MOVIMENTO SUAVE
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // DIREÇÃO PARA OLHAR
        Vector3 targetDirection = target.forward;

        // LIMITE DE ROTAÇÃO
        float angle = Vector3.SignedAngle(lastTargetForward, targetDirection, Vector3.up);
        if (Mathf.Abs(angle) > maxAngle)
        {
            targetDirection = Quaternion.AngleAxis(maxAngle * Mathf.Sign(angle), Vector3.up) * lastTargetForward;
        }

        // ROTAÇÃO SUAVE
        if (targetDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmooth * Time.deltaTime);
        }

        lastTargetForward = target.forward;
    }
}
