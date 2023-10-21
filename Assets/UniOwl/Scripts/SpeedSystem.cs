using UnityEngine;

public class SpeedSystem : MonoBehaviour
{
    [SerializeField]
    private RunningLinesSystem rls;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera vCam;
    private Cinemachine.CinemachineBasicMultiChannelPerlin shaker;

    [SerializeField]
    [Range(0f, 1f)]
    private float strength;
    [SerializeField]
    private float walkFOV, runFOV;

    [SerializeField]
    private Rigidbody target;
    [SerializeField]
    private float maxVelocity;

    private void Awake()
    {
        shaker = vCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        strength = Mathf.Clamp01(target.velocity.magnitude / maxVelocity);
        rls.strength = strength;
        shaker.m_AmplitudeGain = strength;
        vCam.m_Lens.FieldOfView = Mathf.Lerp(walkFOV, runFOV, strength);
    }
}
