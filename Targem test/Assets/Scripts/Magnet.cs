using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    public GameObject magneticField;
    public float magnetForce;
    public Text collusionText;
    private bool isHit = false;
    private float collisionForce = 1000;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce((magneticField.transform.position - transform.position) * magnetForce * Time.smoothDeltaTime);
    }

    private void OnCollisionEnter(Collision boxItem)
    {
        if (boxItem.collider.name != "Magnetic field")
        {
            boxItem.collider.GetComponent<Renderer>().material.color = Color.red;

            boxItem.gameObject.GetComponent<Rigidbody>().AddForce((boxItem.gameObject.transform.position - transform.position) * collisionForce * Time.smoothDeltaTime);

            if (!isHit && boxItem.gameObject.name == "Magnet")
            {
                collusionText.text = "Столкновений: " + ++collusionText.GetComponent<CollisionCount>().collusionCount;
                isHit = true;
                StartCoroutine(HitCooldown());
            }
        }
    }

    private IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isHit = false;
    }
}