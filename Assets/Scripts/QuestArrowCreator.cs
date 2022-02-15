using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestArrowCreator : MonoBehaviour
{
    [SerializeField] private PointingArrow _arrow;
    [SerializeField] private Image _arrowView;

    private QuestPoint[] _questPoints;
    private ArrowCanvas _arrowCanvas;

    private void Start()
    {
        _arrowCanvas = FindObjectOfType<ArrowCanvas>();
        _questPoints = FindObjectsOfType<QuestPoint>();

        foreach (var quest in _questPoints)
        {
            CreatePointingArrow(quest);
        }
    }

    public void CreatePointingArrow(QuestPoint quest)
    {
        var arrow = Instantiate(_arrow);
        var view = Instantiate(_arrowView);

        view.transform.SetParent(_arrowCanvas.transform);
        arrow.transform.SetParent(this.transform);
        arrow.transform.localPosition = Vector3.zero;
        arrow.transform.localScale = Vector3.one;
        arrow.transform.rotation = new Quaternion(0, 0, 0, 0);

        arrow.SetImage(view);
        arrow.SetTarget(quest);
    }
}
