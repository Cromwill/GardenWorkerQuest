using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestArrowCreator : MonoBehaviour
{
    [SerializeField] private PointingArrow _arrow;
    [SerializeField] private Image _arrowView;

    private ArrowCanvas _arrowCanvas;

    private void Awake()
    {
        _arrowCanvas = FindObjectOfType<ArrowCanvas>();
    }

    public void CreatePointingArrow(QuestPoint quest)
    {
        var arrow = Instantiate(_arrow);
        var view = Instantiate(_arrowView);

        view.transform.SetParent(_arrowCanvas.transform);
        arrow.transform.SetParent(this.transform);
        arrow.transform.localPosition = Vector3.zero;
        view.transform.localScale = Vector3.one;
        arrow.transform.rotation = new Quaternion(0, 0, 0, 0);

        arrow.SetImage(view);
        arrow.SetTarget(quest);
    }
}
