using UnityEngine;

public class BoardSpin : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("I'm attached to " + name);
    }

    // Update is called once per frame
    private void Update()
    {
        // TODO: Something or other
        transform.Rotate(new Vector3(0.0f, rotationSpeed * Time.deltaTime, 0.0f), Space.World);
    }
}
