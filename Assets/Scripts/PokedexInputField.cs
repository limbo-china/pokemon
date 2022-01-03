using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokedexInputField : MonoBehaviour
{
    public TMP_InputField inputText;
    public Animator inputFieldAnimator;

    private string inAnim = "In";
    private string outAnim = "Out";

    void Start()
    {
        inputText = gameObject.GetComponent<TMP_InputField>();
        inputFieldAnimator = gameObject.GetComponent<Animator>();

        inputText.onSelect.AddListener(delegate { animateIn(); });
        inputText.onEndEdit.AddListener(delegate { animateOut(); });
        updateState();
    }

    void OnEnable()
    {
        if (inputText == null)
            return;

        inputText.ForceLabelUpdate();
        updateState();
    }

    public void animateIn()
    {
        inputFieldAnimator.Play(inAnim);
    }

    public void animateOut()
    {
        if (inputText.text.Length == 0)
            inputFieldAnimator.Play(outAnim);
    }

    public void updateState()
    {
        if (inputText.text.Length == 0)
            animateOut();
        else
            animateIn();
    }
}
