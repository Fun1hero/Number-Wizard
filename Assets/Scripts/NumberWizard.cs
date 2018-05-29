using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	public Text number;
	int max, min, guess, maxGuessesAllowed;

	// Use this for initialization
	void Start () {
		Welcome();

	}
	void Welcome () { 
		guess = 0;
		max = 1000;
		min = 1;
		guess = Random.Range(min,max);
		max = max + 1;
		maxGuessesAllowed = Random.Range(8,15);

		number.text = guess.ToString();

	}

	public void Guess (bool state){
		if (state) {
			min = guess;
			guess = binary(min,max);
			number.text = guess.ToString();
		} else {
			max = guess;
			guess = binary(min,max);
			number.text = guess.ToString();
		}
	}

	int binary (int min, int max){
		int res = (min + max) / 2;
		maxGuessesAllowed -= 1;
		if (guess == 1000 || guess == 1 && maxGuessesAllowed <= 1)
			SceneManager.LoadScene("Lose");
		if (maxGuessesAllowed <= 0) 
			SceneManager.LoadScene("Win"); 
		
		return res;
	}
}
