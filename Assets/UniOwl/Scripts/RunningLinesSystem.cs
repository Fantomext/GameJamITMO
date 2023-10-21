using UnityEngine;

public class RunningLinesSystem : MonoBehaviour
{
    [SerializeField]
    private RunningLine prefab;
    [SerializeField]
    private RectTransform parent;

    [SerializeField]
    private int numLines;
    [SerializeField]
    private float speed;

    [SerializeField]
    private float fromDist, toDist;

    private RunningLine[] lines;

    public float strength = 0f;

    private void Awake()
    {
        lines = new RunningLine[numLines];

        for (int i = 0; i < numLines; i++)
        {
            Vector2 direction = Random.insideUnitCircle.normalized * .5f;

            var line = Instantiate(prefab, parent);

            line.fromDistance = fromDist;
            line.toDistance = Random.Range(fromDist, toDist);
            line.offset = Random.Range(line.fromDistance, line.toDistance);
            line.direction = direction;

            lines[i] = line;

            float angle = Vector2.SignedAngle(Vector2.down, direction * 2f);

            var rectTr = line.transform as RectTransform;
            rectTr.rotation = Quaternion.Euler(0f, 0f, angle);

            var color = line.image.color;
            color.a *= Random.value;
            line.image.color = color;
        }
    }

    private void Start()
    {
        for (int i = 0; i < numLines; i++)
        {
            var line = lines[i];
            var rectTr = line.transform as RectTransform;
            rectTr.anchoredPosition = parent.sizeDelta * line.direction * 4f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < numLines; i++)
        {
            var line = lines[i];
            var rectTr = line.transform as RectTransform;

            float distance = Mathf.PingPong(Time.time * speed + line.offset, line.fromDistance - line.toDistance) + line.toDistance;
            float farDistance = 4f;

            float t = Mathf.Lerp(farDistance, distance, strength);
            rectTr.anchoredPosition = parent.sizeDelta * line.direction * t;
        }
    }
}
