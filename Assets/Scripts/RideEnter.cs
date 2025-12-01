using UnityEngine;
using UnityEngine.InputSystem; // ถ้าใช้ Input System

public class RideEnter:MonoBehaviour
{
    public Transform queuePoint;  // จุดให้ผู้เล่นมายืน
    public Transform seatPoint;   // จุดนั่งบนเครื่องเล่น
    public Transform exitPoint;   // จุดลงจากเครื่อง
    public Transform player;      // XR Origin / OVRCameraRig

    public InputActionProperty buttonA; // ผูกกับ A (Press)
    public InputActionProperty buttonB; // ผูกกับ B (Press)

    bool inQueue = false;
    bool isSitting = false;

    void Update()
    {
        if (inQueue && !isSitting && buttonA.action.WasPressedThisFrame())
            SitOnRide();

        if (isSitting && buttonB.action.WasPressedThisFrame())
            ExitRide();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            inQueue = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            inQueue = false;
    }

    void SitOnRide()
    {
        player.position = seatPoint.position;
        player.rotation = seatPoint.rotation;
        player.SetParent(seatPoint.parent);
        isSitting = true;
    }

    void ExitRide()
    {
        player.SetParent(null);
        player.position = exitPoint.position;
        isSitting = false;
    }
}
