using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject loadingGroup;
    public GameObject loadingFiller;
    public GameObject bulb;
    private Vector3 loadingGroupOriginalScale;
    private Vector3 loadingGroupScaleTo;
    //10-8-2023 : CM : Commented : For future use
    //private AsyncOperation loadingOperation;

    private 

    void Start()
    {
        // get first the original localscale
        loadingGroupOriginalScale = loadingGroup.transform.localScale;

        // set the largest scale for animation
        loadingGroupScaleTo = loadingGroupOriginalScale * 1.1f;

        // set the scale to 0
        loadingGroup.transform.localScale = new Vector3(0, 0, 0);

        OpacityUp();
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

        //10-8-2023 : CM : Commented : For future use
        //loadingOperation = SceneManager.LoadSceneAsync("SampleScene");
    }

    private void FillUp()
    {
        
        loadingFiller.GetComponent<Image>().fillAmount = 0;

        //10-8-2023 : CM : Commented : For future use
        //loadingFiller.GetComponent<Image>().DOFillAmount(loadingOperation.progress, 1f)
        loadingFiller.GetComponent<Image>().DOFillAmount(100f, 1f)
            .SetEase(Ease.InOutSine)
            .SetLoops(1, LoopType.Incremental)
            .OnComplete(() =>
            {
                // 10-8-2023 : CM : Commented|Explain : for future use of async loading
                //if(!loadingOperation.isDone)
                //{
                //    FillUp();
                //}
                //else
                //{
                    SceneManager.LoadScene(1);
                //}
            });
    }

    private void OpacityUp()
    {
        Color origColor = bulb.GetComponent<Image>().color;

        bulb.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        bulb.GetComponent<Image>().DOColor(origColor, 0.5f)
            .SetEase(Ease.InOutSine)
            .OnComplete(ScaleUp);

    }
}
