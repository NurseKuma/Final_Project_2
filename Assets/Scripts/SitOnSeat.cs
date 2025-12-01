using UnityEngine;

public class SitOnSeat : MonoBehaviour
{
    [Header("Targets")]
    public Transform seatPoint;
    public Transform playerRig;

    [Header("Buttons")]
    public OVRInput.Button enterButton = OVRInput.Button.One;
    public OVRInput.Button exitButton = OVRInput.Button.Two;

    private bool canEnter = false;
    private bool isSitting = false;
    private Transform trackingSpace;

    void Start()
    {
        trackingSpace = playerRig.Find("TrackingSpace");
        if (trackingSpace == null)
            Debug.LogError("TrackingSpace ไม่พบ!");
    }

    void Update()
    {
        if (canEnter && !isSitting && OVRInput.GetDown(enterButton))
            Sit();

        if (isSitting && OVRInput.GetDown(exitButton))
            ExitSeat();
    }

    void Sit()
    {
        isSitting = true;

        // Parent TrackingSpace ไปยัง SeatPoint
        trackingSpace.SetParent(seatPoint);
        trackingSpace.localPosition = Vector3.zero;
        trackingSpace.localRotation = Quaternion.identity;
    }

    void ExitSeat()
    {
        isSitting = false;

        // ปล่อย parent
        trackingSpace.SetParent(null);

       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            canEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            canEnter = false;
    }
}