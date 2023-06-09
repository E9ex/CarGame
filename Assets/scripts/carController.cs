using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    [SerializeField] private float CarSpeed;
    [SerializeField] private float maxspeed;
    [SerializeField] private float steerAngle;
    [SerializeField] private float traction;
    [SerializeField] private Text scoretext;

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

        hesaplaDriftScore();
    }

    private void hesaplaDriftScore()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 )
        {
            if (!isDrifting)
            {
                isDrifting = true;
            }
            driftScore += Time.deltaTime;
            float roundedScore = Mathf.Round(driftScore * 100) / 100; // Skoru noktadan sonra 2 basamağa yuvarlama
            scoretext.text = "Score: " + roundedScore.ToString("0.00"); 
        }
        else
        {
            if (isDrifting)
            {
                isDrifting = false;
            }
        }
    }
}

