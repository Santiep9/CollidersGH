using UnityEngine;

public class ResetearBolos : MonoBehaviour
{
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    private Rigidbody rb;

    void Start()
    {
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    public void Reiniciar()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }
}
