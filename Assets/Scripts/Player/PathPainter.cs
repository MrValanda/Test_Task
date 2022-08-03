using UnityEngine;

public class PathPainter : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Movement _movement;

    private void Update()
    {
        if (_movement.Path.Count == 0) return;
        DrawPath();
    }
    private void DrawPath()
    {
        _lineRenderer.positionCount = _movement.Path.Count + 1;
        _lineRenderer.SetPosition(0, _movement.transform.position);
        for (var i = 0; i < _movement.Path.Count; i++)
        {
            _lineRenderer.SetPosition(i + 1, _movement.Path[i]);
        }
    }
}
