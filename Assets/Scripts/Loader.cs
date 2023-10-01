using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject loadingGroup;
    public GameObject loadingFiller;
    private Vector3 loadingGroupOriginalScale;
    private Vector3 loadingGroupScaleTo;

    void Start()
    {
        // get first the original localscale
        loadingGroupOriginalScale = loadingGroup.transform.localScale;

        // set the largest scale for animation
        loadingGroupScaleTo = loadingGroupOriginalScale * 1.1f;

        // set the scale to 0
        loadingGroup.transform.localScale = new Vector3(0, 0, 0);

        ScaleUp();
    }

    private void ScaleUp()
    {
        loadingGroup.transform.DOScale(loadingGroupScaleTo, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(1, LoopType.Yoyo)
            .OnComplete(ScaleNormal);
    }

    private void ScaleNormal()
    {
        loadingGroup.transform.DOScale(loadingGroupOriginalScale, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(1, LoopType.Yoyo)
            .OnComplete(FillUp);
    }

    private void FillUp()
    {
        loadingFiller.GetComponent<Image>().fillAmount = 0;

        loadingFiller.GetComponent<Image>().DOFillAmount(100f, 1f)
            .SetEase(Ease.InOutSine)
            .SetLoops(1, LoopType.Incremental);
    }

}
