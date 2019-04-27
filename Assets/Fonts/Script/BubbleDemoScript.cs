using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BubbleDemoScript : MonoBehaviour 
{
	public Text bubbleText;
    public Text bubbleTitleTxt;
    public Text bubble3Dtxt;
    public Text bubble3DTitleTxt;
    public GameObject bubble;
    public GameObject bubbleTitle;
    public GameObject bubble3D;
    public GameObject bubble3DTitle;

    public GameObject mainCamera;
    public GameObject worldCamera;
	
	void Start ()
	{
        worldCamera.SetActive(false);
        mainCamera.SetActive(true);
        bubbleTitleTxt.text = "Font JazzCreate Bubble";
		bubbleText.text = "☺☻♥♦♣♠•◘○◙♂♀♪♫☼►◄↕‼▬↨↑↓→←\n" + "∟↔▲▼!#$%&'()*+,-./0123456789:;<=>?@\n"
            + "ABCDEFGHIJKLMNOPQRSTUVWXYZ\n`abcdefghijklmnopqrstuvwxyz\nîìÄÅÉæÆôöòûùÿÖÜ \n ¢£¥ƒáíóúñÑªº¿¬½¼¡«»░▒▓\n "
                + "│┤╣║╗┐└┴┬├─┼╚╔╩╦╣║╗•§©®¶" + "\nThanks for using fonts from JazzCreates2015©.";
        bubble3DTitleTxt.text = "Font JazzCreate Bubble 3D";
        bubble3Dtxt.text = " 100 Usable Charcters " + "\n abcdefghijklmnopqrstuvwxyz " + "\n ABCDEFGHIJKLMNOPQRSTUVWXYZ " +
            " 0123456789 " + " \n !£$%&*()_-=+;:'@#, \n <.>/?`¬§¢¥ƒ¿½¼¡«»©®¶ ";
        bubble.SetActive(false);
        bubbleTitle.SetActive(false);
        bubble3D.SetActive(false);
        bubble3DTitle.SetActive(false);
        StopCoroutine("CycleFonts");
        StartCoroutine("CycleFonts");
    }

    IEnumerator CycleFonts()
    {
        bubble3D.SetActive(false);
        bubble3DTitle.SetActive(false);
        bubble.SetActive(true);
        bubbleTitle.SetActive(true);
        yield return new WaitForSeconds(5);
        bubble.SetActive(false);
        bubbleTitle.SetActive(false);
        bubble3D.SetActive(true);
        bubble3DTitle.SetActive(true);

        yield return new WaitForSeconds(5);
        mainCamera.SetActive(false);
        worldCamera.SetActive(true);
    }
}