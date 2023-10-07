using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class AnimationManager : MonoBehaviour
{
    public static float duration = .7f;
    public float startPosY = 1500f;
    public CanvasGroup canvas;
    public RectTransform logo, sublogo, profile, actionButtons, bgPattern;

    public List<RectTransform> menuButtons;


    // Start is called before the first frame update
    void Start()
    {

        CanvasGroup canvasGp = this.gameObject.GetComponent<CanvasGroup>();
        Image logoImg = logo.GetComponent<Image>();
        CanvasGroup profileGp = profile.GetComponent<CanvasGroup>();
        CanvasGroup actionButtonsGp = actionButtons.GetComponent<CanvasGroup>();
        Sequence menuRootSeq = DOTween.Sequence();
        Sequence logoSeq = DOTween.Sequence();


        /* start - starting values */


        canvasGp.alpha = 0f;
        profileGp.alpha = 0f;
        actionButtonsGp.alpha = 0f;
        logoImg.color = new Color(logoImg.color.r, logoImg.color.r, logoImg.color.r, 0);
        logo.transform.localScale = Vector3.zero;
        //setting the initial scale of menu buttons
        foreach (var item in menuButtons)
        {

            item.transform.localScale = Vector3.zero;
        }

        logo.transform.localPosition = new Vector2(0, 0);
        /* end - starting values */


        menuRootSeq.Append(canvasGp.DOFade(1f, duration).SetEase(Ease.OutBounce));

        logoSeq.Append(logo.DOScale(1.3f, 2f).SetEase(Ease.OutElastic));
        logoSeq.AppendInterval(.5f);
        logoSeq.Append(logo.DOAnchorPos(new Vector2(0, 700f), duration, false).OnStart(() => { logo.DOScale(1f, duration); }));
        menuRootSeq.Insert(.5f, logoSeq.OnComplete(() => { StartCoroutine("menuButtonsAnimation"); }));
        menuRootSeq.Insert(5.5f, profileGp.DOFade(1f, duration / 1.5f));
        menuRootSeq.Insert(5.5f, actionButtonsGp.DOFade(1f, duration / 1.5f)).OnComplete(() => { GameHandlerScript.loadProfiles(); });

        /* OnComplete(() => { StartCoroutine("menuButtonsAnimation"); }); */
        logoImg.DOColor(new Color(logoImg.color.r, logoImg.color.r, logoImg.color.r, 1), duration);

        //menuRootSeq.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator menuButtonsAnimation()
    {

        foreach (var item in menuButtons)
        {
            item.transform.DOScale(1f, duration).SetEase(Ease.OutBounce);

            yield return new WaitForSeconds(.3f);
        }
    }

    public static void ZoomIn(CanvasGroup obj)
    {
        obj.DOFade(1f, duration/5);
        obj.transform.DOScale(1f, duration/5).OnComplete(() => { obj.interactable = true; });

    }

   /*  public AnimationManager(CanvasGroup obj)
    {
        canvas = obj;
        void ZoomIn()
        {
            canvas.DOFade(1f, duration);
            canvas.transform.DOScale(1f, duration).OnComplete(() => { canvas.interactable = true; });

        }
    } */

}
