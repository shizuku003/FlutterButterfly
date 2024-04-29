using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField]
    private TextAsset _explainData = default;
    [SerializeField]
    private Text _dialogueText = default;
    [Tooltip("何秒でテキスト消すか")]
    [SerializeField]
    private float _deleteTime = 5f;

    private float _timer = 0f;
    private bool _isShowDialogue = false;
    private int _index = 0;
    private List<string[]> _tutorialMessaegs = new();

    private void Start()
    {
        TextLoad();
        ShowText();
    }

    private void Update()
    {
        if (_isShowDialogue)
        {
            _timer += Time.deltaTime;
            if (_timer > _deleteTime)
            {
                _isShowDialogue = false;
                _index++;
                _dialogueText.text = "";
                _timer = 0f;
                if (_index == _tutorialMessaegs.Count - 1) { _dialogueText.color = Color.white; }
            }
        }
    }

    private void TextLoad()
    {
        if (!_explainData) { return; }

        var messages = _explainData.text.Split(",,");
        foreach (var message in messages) { _tutorialMessaegs.Add(message.Split("\n")); }
    }

    public void ShowText()
    {
        if (_index == _tutorialMessaegs.Count) { return; }

        _dialogueText.text = "";
        _isShowDialogue = true;
        var dialogue = _tutorialMessaegs[_index];
        foreach (var message in dialogue) { _dialogueText.text += message + "\n"; }
    }
}
