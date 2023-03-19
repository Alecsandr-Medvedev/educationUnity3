using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBox : MonoBehaviour
{
    [SerializeField] private AnimationCurve _moveCurve;
    private Resources _resources;

    public void MoveTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveToPoint(transform.position, targetPosition, false));
    }

    public void setResources(Resources resources)
    {
        _resources = resources;
    }

    // Перемещение монеты из точки a в b за 1 секунду
    private IEnumerator MoveToPoint(Vector3 a, Vector3 b, bool isDestroy)
    {
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            float x = Mathf.Lerp(a.x, b.x, t);

            float yzInterpolant = _moveCurve.Evaluate(t);
            float y = Mathf.LerpUnclamped(a.y, b.y, yzInterpolant);
            float z = Mathf.LerpUnclamped(a.z, b.z, yzInterpolant);

            Vector3 position = new Vector3(x, y, z);
            transform.position = position;
            yield return null;
        }
        if (isDestroy)
        {
            Destroy(gameObject);
        }
    }

    public void Take()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Vector3 nextPosition = transform.position + new Vector3(0, -transform.localScale.y, 0);
        StartCoroutine(MoveToPoint(transform.position, nextPosition, true));
        _resources.CollectCoins(1, transform.position);

    }
}
