using UnityEngine;

public class Vfx : MonoBehaviour
{
    private float value;
    private Material material;

    private void Awake()
    {
        value = 1.0f;
        material = GetComponent<MeshRenderer>().material;
    }

    public static void Instant(GameObject item)
    {
        var go = Instantiate(Resources.Load<Vfx>("vfx"));

        var material = item.GetComponent<MeshRenderer>().material;
        var color = material.GetColor("basecolor");

        go.GetComponent<MeshRenderer>().material.SetColor("basecolor", color);
        go.transform.position = item.transform.position + Vector3.forward;

        var rb = go.gameObject.AddComponent<Rigidbody>();

        go.transform.rotation = item.transform.rotation;
        rb.AddForce(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(10.0f, 13.0f)), ForceMode.Impulse);
    }

    private void Update()
    {
        value = Mathf.MoveTowards(value, -1.0f, Time.deltaTime);
        material.SetFloat("_dissolveAmount", value);
        if(value <= -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
