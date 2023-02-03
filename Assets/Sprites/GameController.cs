using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public string myAns = "";
	public int myAnsCnt = 1;
	public string myAnsDisplay = "";
	public string myAns1 = "";
	public string myAns2 = "";
	public string myAns3 = "";
	public int nextNum = 1;
	public string[] ansList = new string[102];

	public float t;
	bool runtime = true;
	float nextTime = 1.0f;
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (runtime) {
			t += Time.deltaTime;
			if (t >= nextTime) {
				RandAns ();
				t = 0;
			}
		}
		GameObject.Find ("MyAns").GetComponent<Text> ().text = myAnsDisplay;

	}

	void RandAns() {
		int ansCnt = Random.Range (1, 3 + 1);
		if (nextNum == 99 && ansCnt == 3) {
			ansCnt = 2;
		}
		if (nextNum == 100) {
			ansCnt = 1;
		}
		string currentAns = "";
		currentAns += ansList [nextNum - 1];
		nextNum += 1;
		if (ansCnt >= 2) {
			currentAns += " ";
			currentAns += ansList [nextNum - 1];
			nextNum += 1;
		}
		if (ansCnt >= 3) {
			currentAns += " ";
			currentAns += ansList [nextNum - 1];
			nextNum += 1;
		}
		GameObject.Find ("CurrentAns").GetComponent<Text> ().text = currentAns;
		nextTime = Random.Range (1f, 5f);
		if (nextNum == 101) {
			runtime = false;
		}
	}

	void Init() {
		int clapCnt = 0;
		string tempString;
		for (int i = 0; i < 100; i++) {
			tempString = (i + 1) + "";
			for (int c = 0; c < tempString.Length; c++) {
				if (tempString [c] == '3') {
					clapCnt += 1;
				}
				else if (tempString [c] == '6') {
					clapCnt += 1;
				}
				else if (tempString [c] == '9') {
					clapCnt += 1;
				}
			}
			if (clapCnt == 0) {
				ansList[i] = tempString;
			}
			else {
				ansList [i] = new string ('#', clapCnt);
			}
			clapCnt = 0;
		}
	}

	public void Btn1() {
		myAns += '1';
		myAnsDisplay += '1';
	}
	public void Btn2() {
		myAns += '2';
		myAnsDisplay += '2';
	}
	public void Btn3() {
		myAns += '3';
		myAnsDisplay += '3';
	}
	public void Btn4() {
		myAns += '4';
		myAnsDisplay += '4';
	}
	public void Btn5() {
		myAns += '5';
		myAnsDisplay += '5';
	}
	public void Btn6() {
		myAns += '6';
		myAnsDisplay += '6';
	}
	public void Btn7() {
		myAns += '7';
		myAnsDisplay += '7';
	}
	public void Btn8() {
		myAns += '8';
		myAnsDisplay += '8';
	}
	public void Btn9() {
		myAns += '9';
		myAnsDisplay += '9';
	}
	public void Btn0() {
		if (myAnsDisplay.Length > 0) {
			myAns += '0';
			myAnsDisplay += '0';
		}
	}
	public void BtnCheck() {
		if (myAnsCnt == 1) {
			myAns1 = myAns;
			if (myAns1 == ansList [nextNum - 1]) {
				GameObject.Find ("CurrentAns").GetComponent<Text> ().text = myAnsDisplay;
				nextNum += myAnsCnt;
				nextTime = Random.Range (1f, 5f);
				t = 0;
				print ("OK");
			} else {
				print ("NO");
			}
		}
		else if (myAnsCnt == 2) {
			myAns2 = myAns;
			if ((myAns1 == ansList [nextNum - 1]) && (myAns2 == ansList [nextNum])) {
				GameObject.Find ("CurrentAns").GetComponent<Text> ().text = myAnsDisplay;
				nextNum += myAnsCnt;
				nextTime = Random.Range (1f, 5f);
				t = 0;
				print ("OK");
			} else {
				print ("NO");
			}
		}
		else if (myAnsCnt == 3) {
			myAns3 = myAns;
			if ((myAns1 == ansList [nextNum - 1]) && (myAns2 == ansList [nextNum]) && (myAns3 == ansList [nextNum + 1])) {
				GameObject.Find ("CurrentAns").GetComponent<Text> ().text = myAnsDisplay;
				nextNum += myAnsCnt;
				nextTime = Random.Range (1f, 5f);
				t = 0;
				print ("OK");
			} else {
				print ("NO");
			}
		}
		ansReset ();
	}
	public void BtnBackspace() {
		if (myAns.Length > 0) {
			myAns = myAns.Substring (0, myAns.Length - 1);
			myAnsDisplay = myAnsDisplay.Substring (0, myAnsDisplay.Length - 1);
		}
	}
	public void BtnBackspaceAll() {
		myAns = "";
		myAnsDisplay = "";
	}
	public void BtnClap() {
		myAns += '#';
		myAnsDisplay += '#';
	}
	public void BtnAnd() {
		if (myAns.Length > 0) {
			if (myAns1 == "") {
				myAns1 = myAns;
				myAns = "";
				myAnsDisplay += " ";
			}
			else if (myAns2 == "") {
				myAns2 = myAns;
				myAns = "";
				myAnsDisplay += " ";
			}
			myAnsCnt += 1;
		}
	}
	void ansReset() {
		myAns = "";
		myAns1 = "";
		myAns2 = "";
		myAns3 = "";
		myAnsDisplay = "";
		myAnsCnt = 1;
	}
}