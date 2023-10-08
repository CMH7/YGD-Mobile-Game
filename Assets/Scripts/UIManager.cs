using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public float fadeTime = 1f;
    private CanvasGroup shopCanvasGp;
    private RectTransform shopRectTrans;

    public List<GameObject> items ;
    void Start()
    {
        //shopPanel.SetActive(false);
        shopCanvasGp = shopPanel.GetComponent<CanvasGroup>();
        shopRectTrans = shopPanel.GetComponent<RectTransform>();
        shopCanvasGp.alpha = 0f;
    }

    public void ShopFadeIn()
    {
        //shopPanel.SetActive(true);
        shopCanvasGp.alpha = 0f;
        shopRectTrans.transform.localPosition = new Vector2(0, -500f);
        shopCanvasGp.DOFade(1, fadeTime);
        shopRectTrans.DOAnchorPos(new Vector2(0, 0), fadeTime, false).SetEase(Ease.OutElastic);
        StartCoroutine("ItemsAnimation");
    }

    public void ShopFadeOut()
    {
        Debug.Log("click");
        shopCanvasGp.alpha = 1f;
        shopRectTrans.transform.localPosition = new Vector2(0, 0);
        shopCanvasGp.DOFade(0f, fadeTime);
        shopRectTrans.DOAnchorPos(new Vector2(0, -500f), fadeTime, false).SetEase(Ease.OutQuint);
    }

    IEnumerator ItemsAnimation(){
        foreach(var item in items){
            item.transform.localScale = Vector3.zero;
        }
        foreach(var item in items){
            item.transform.DOScale(1f,fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(.2f);
        }
    }
}
