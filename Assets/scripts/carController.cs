using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] private float CarSpeed;
    [SerializeField] private float maxspeed;
    [SerializeField] private float steerAngle;
    [SerializeField] private float traction;

    public Transform lw, rw;

    private float DragAmount = 0.99f;
    private Vector3 vecmove;
    private Vector3 vecrot;
    public float driftScore = 0f;
    private bool isDrifting = false;

    private void Update()
    {
        vecmove += transform.forward * CarSpeed * Time.deltaTime;
        transform.position += vecmove * Time.deltaTime;

        vecrot += new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * vecmove.magnitude);

        vecmove *= DragAmount;
        vecmove = Vector3.ClampMagnitude(vecmove, maxspeed);
        vecmove = Vector3.Lerp(vecmove.normalized, transform.forward, traction * Time.deltaTime) * vecmove.magnitude;

        vecrot = Vector3.ClampMagnitude(vecrot, steerAngle);
        lw.localRotation = Quaternion.Euler(vecrot);
        rw.localRotation = Quaternion.Euler(vecrot);

        CalculateDriftScore();
    }

    private void CalculateDriftScore()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 )
        {
            if (!isDrifting)
            {
                isDrifting = true;
            }

            driftScore += Time.deltaTime;
        }
        else
        {
            if (isDrifting)
            {
                isDrifting = false;
                // Burada drift tamamlandığında ne yapmak istediğinizi belirleyebilirsiniz.
                // Örneğin, drift skorunu kaydedebilir, efektler ekleyebilir veya puanlama yapabilirsiniz.
            }
        }
    }
}

