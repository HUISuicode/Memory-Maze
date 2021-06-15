using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleSimon : MonoBehaviour
{
	public Button YellowButton; 
	public Button BlueButton;  
	public Button RedButton; 
	public Button GreenButton; 
	public Button play;
	public Text LoseText;
	public Text WinText;
	public float GameSpeed;  
	public static bool SaimonSimple;


	AudioSource Csharp;
	AudioSource Ehigh;  
	AudioSource A;     
	AudioSource Elow;   

	private Button[] buttons;           
	private List<Button> CPUmoves;     

	Button buttonPress;

	void Start()
	{
		LoseText.enabled = false;
		ResetColors();
		ButtonsEnabled(true);

		YellowButton.onClick.AddListener(() => ButtonClick(0));
        BlueButton.onClick.AddListener(() => ButtonClick(1));
        RedButton.onClick.AddListener(() => ButtonClick(2));
        GreenButton.onClick.AddListener(() => ButtonClick(3));
		CameraSwitch.saimonBool = false;

		play.onClick.AddListener(() => StartCoroutine(Play()));

        Csharp = YellowButton.GetComponent<AudioSource>();
        Ehigh = BlueButton.GetComponent<AudioSource>();
        A = RedButton.GetComponent<AudioSource>();
        Elow = GreenButton.GetComponent<AudioSource>();

        buttons = new Button[4] { YellowButton, BlueButton, RedButton, GreenButton };

		CPUmoves = new List<Button>();
	}

	IEnumerator Play()
	{
		play.interactable = false;
		bool lose = false;
		bool win = false;
		int count = 0;
		LoseText.enabled = false;
        ResetColors();
        CPUmoves.Clear();

		int ButtonIndex;
		while (!lose && !win)
		{
			if (count == 2)
			{
				win = true;
				break;
			}
			ButtonsEnabled(false);
			ButtonIndex = Random.Range(0, 4);  
			CPUmoves.Add(buttons[ButtonIndex]);    

			foreach (Button move in CPUmoves)
			{ 
				move.onClick.Invoke();
				yield return new WaitForSeconds(GameSpeed + 0.1f);
				ResetColors();
				yield return new WaitForSeconds(0.1f);
			}
			buttonPress = null;

			for (int i = 0; i < CPUmoves.Count; i++)
			{
				Button nextButton = CPUmoves[i];
				ButtonsEnabled(true);
				yield return new WaitUntil(() => buttonPress != null);
				ButtonsEnabled(false);
				if (nextButton != buttonPress)
				{
					lose = true;
					break;
				}
				buttonPress = null;
				ResetColors();
				yield return new WaitForSeconds(GameSpeed + 0.1f);  
				ButtonsEnabled(true);
			}
			count++;
		}
		if (win && !lose)
		{
			ButtonsEnabled(false);
			WinText.enabled = true;
			HintsMenu.hintCount++;
			lose = true;
			SaimonSimple = false;
			HintsMenu.currentHint++;
			PlayerPrefs.SetInt("currentHint", HintsMenu.currentHint);
			PlayerPrefs.SetInt("hintCount", HintsMenu.hintCount);
			Debug.Log("1");
		}
		else if
			(lose && !win)
		{
			LoseText.enabled = true;
			play.interactable = true;
			Debug.Log("2");
		}
		else if (lose && win)
		{
			count = 0;
			LoseText.enabled = false;
			play.interactable = true;
			SaimonSimple = false;
			Debug.Log("3");
		}
		
	}
	public void Quit()
    {
		CameraSwitch.camera = true;
		SaimonSimple = false;
		play.interactable = true;
    }

	void ButtonClick(int button)
	{
		switch (button)
		{
			case 0:
				Csharp.SetScheduledEndTime(AudioSettings.dspTime + GameSpeed);
				YellowButton.image.color = Color.white;
				buttonPress = YellowButton;
				break;
			case 1:
				Ehigh.SetScheduledEndTime(AudioSettings.dspTime + GameSpeed);
				BlueButton.image.color = Color.white;
				buttonPress = BlueButton;
				break;
			case 2:
				A.SetScheduledEndTime(AudioSettings.dspTime + GameSpeed);
				RedButton.image.color = Color.white;
				buttonPress = RedButton;
				break;
			case 3:
				Elow.SetScheduledEndTime(AudioSettings.dspTime + GameSpeed);
				GreenButton.image.color = Color.white;
				buttonPress = GreenButton;
				break;
			default:
				Debug.LogError(button + " is not a valid button code.");
				break;
		}
	}

	void ResetColors()
	{
		YellowButton.image.color = Color.yellow;
		BlueButton.image.color = Color.blue;
		RedButton.image.color = Color.red;
		GreenButton.image.color = Color.green;
	}

	void ButtonsEnabled(bool enable)
	{
		YellowButton.interactable = enable;
		BlueButton.interactable = enable;
		RedButton.interactable = enable;
		GreenButton.interactable = enable;
	}
}
