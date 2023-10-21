using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FakeVolumetricCone : MonoBehaviour
{
    [SerializeField]
    private Light light;
    
    [SerializeField]
    private Transform cone;

    [SerializeField]
    private bool refresh;

    private void OnValidate()
    {
        if (!refresh)
            return;
        refresh = false;

        light.GetComponent<UniversalAdditionalLightData>();

        float coneLength = light.range;
        float coneWidth = 2f * coneLength * Mathf.Tan(Mathf.Deg2Rad * light.spotAngle * .5f);

        cone.localScale = new Vector3(coneWidth, coneWidth, coneLength);
    }
}
