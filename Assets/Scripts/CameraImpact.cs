using System.Collections;
using UnityEngine;

public class CameraImpact : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakePower = 5f;
    public GameObject camera;


    private IEnumerator ShakeRoutine()
    {
        float timer = 0f;
        float t = 0f;
        while (t < 1f)
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / shakeDuration);
            var _csp = Mathf.Lerp(shakePower, 0, t);

            var _xOff = Random.Range(-_csp, _csp);
            var _yOff = Random.Range(-_csp, _csp);

            camera.transform.position = new Vector2(_xOff, _yOff);
            yield return new WaitForEndOfFrame();
        }
    }

    public void Impact()
    {
        StartCoroutine(ShakeRoutine());
    }
}
