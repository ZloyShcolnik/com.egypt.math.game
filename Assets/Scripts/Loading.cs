using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] Image filled;
    [SerializeField] ScreenOrientation orientation = ScreenOrientation.Portrait;

    private void Awake()
    {
        Screen.orientation = orientation;
    }

    private IEnumerator Start()
    {
        var et = 0.0f;
        var duration = 3.5f;
        while(et < duration)
        {
            filled.fillAmount = et / duration;

            et += Time.deltaTime;
            yield return null;
        }

        FindObjectOfType<UIScreenController>().OpenCanvas("menu");
        Destroy(gameObject);
    }
}
