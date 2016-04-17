using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class MatchScreen : MonoBehaviour
{
	Text _text;
	RectTransform _rect;
	int _noOfLine = -1;

	// Use this for initialization
	void Start ()
	{
		_text = GetComponent<Text> ();
		_rect = GetComponent<RectTransform> ();

		// Match Screen
		_rect.sizeDelta = new Vector2 (Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If overflow
		if (GetStringHeight (_text.text, _text.fontSize, 2) > _rect.sizeDelta.y) {
			
			// Increase size
			_rect.sizeDelta = new Vector2 (
				_rect.sizeDelta.x, 
				_rect.sizeDelta.y + GetCharHeight (_text.fontSize)
			);

			// Shift
			_rect.localPosition = new Vector3 (
				_rect.localPosition.x,
				_rect.localPosition.y + (GetCharHeight (_text.fontSize) / 2),
				_rect.localPosition.z
			);
		}
	}

	float GetStringHeight (string s, int size, int startFrom = 1)
	{
		return GetCharHeight (size) * (s.Count (c => c == '\n') + startFrom);
	}

	float GetCharHeight (float size)
	{
		return size + 8f;
	}

	public void Push (string msg)
	{
		_text.text += "\n+ " + msg;
	}

	public void Hold (string msg)
	{
		_text.text += "\n# " + msg;
	}

	public void UnHold (string replace = "", string with = "")
	{
		_text.text = _text.text.Replace ('#', '+');
		if (replace.Length > 0)
			_text.text = _text.text.Replace (replace, with);
	}
}
