using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [Header("Load Level")]
    public SystemController systemController;
    public int Level;
    public List<GameObject> texts = new List<GameObject>();
    public GameObject Board;
    public GameObject Player;
    public bool NeedPressKey;

    private GameObject currentText;
    private GameObject nextText;
    private int text_num = 0;
    private void Start() {
        currentText = texts[0];
        foreach (var item in texts) {
            text_num++;
        }
        if (texts.FindIndex(currentText => currentText == this.currentText) != text_num - 1)
            nextText = texts[texts.FindIndex(currentText => currentText == this.currentText) + 1];
        else {
            nextText = null;
        }
        if (Player != null && NeedPressKey) {
            Player.GetComponent<PlayerController>().CanMove = false;
            Player.GetComponent<PlayerUnit>().LoseEnergy = false;
        }
    }

    private void Update() {
        if ((Input.anyKeyDown || !NeedPressKey) && currentText.GetComponent<CanvasGroup>().alpha == 1) {
            currentText.GetComponent<Fade>().CanFade = true;
            if (nextText != null)
                StartCoroutine(NextText());
            else {
                if (systemController != null) {
                    systemController.LoadScene(Level);
                }
                if (Board != null && Board.GetComponent<CanvasGroup>().alpha == 1) {
                    Board.GetComponent<Fade>().CanFade = true;
                }
                if (Player != null && NeedPressKey) {
                    Player.GetComponent<PlayerController>().CanMove = true;
                    Player.GetComponent<PlayerUnit>().LoseEnergy = true;
                }
            }
        }
    }

    IEnumerator NextText() {
        yield return new WaitForSeconds(2);
        currentText.SetActive(false);
        nextText.SetActive(true);
        currentText = nextText;
        if (texts.FindIndex(currentText => currentText == this.currentText) != text_num - 1)
            nextText = texts[texts.FindIndex(currentText => currentText == this.currentText) + 1];
        else {
            nextText = null;
        }
    }
}
