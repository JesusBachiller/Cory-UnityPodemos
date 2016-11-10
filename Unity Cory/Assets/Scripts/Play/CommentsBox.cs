using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CommentsBox : MonoBehaviour {

    private GameObject commentText;
    private GameObject commentImage;
    private GameObject nextButton;
    private GameObject skipAllButton;
    private int currentCommentIndex;

    // Use this for initialization
    void Start () {        
        if (Game.getCurrentLevel().comments.Count == 0)
        {
            Game.setCommentsEnabled(false);
            GetComponent<Canvas>().enabled = false;
        }
        else
        {
            Game.setCommentsEnabled(true);
            currentCommentIndex = 0;
            GetComponent<Canvas>().enabled = true;

            commentText = GameObject.FindGameObjectWithTag("CommentText");
            commentText.GetComponent<Text>().text = Game.getCurrentLevel().comments[currentCommentIndex].text;


            commentImage = GameObject.FindGameObjectWithTag("CommentImage");
            commentImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Game.getCurrentLevel().comments[currentCommentIndex].imagePath) as Sprite;

            nextButton = GameObject.FindGameObjectWithTag("NextCommentButton");
            nextButton.GetComponent<Button>().onClick.AddListener(() => nextComment());

            skipAllButton = GameObject.FindGameObjectWithTag("SkipAllCommentsButton");
            skipAllButton.GetComponent<Button>().onClick.AddListener(() => skipAllComments());

        }
    }

    private void nextComment()
    {
        currentCommentIndex++;
        if (currentCommentIndex <= Game.getCurrentLevel().comments.Count - 1)
        {
            commentText.GetComponent<Text>().text = Game.getCurrentLevel().comments[currentCommentIndex].text;
            commentImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Game.getCurrentLevel().comments[currentCommentIndex].imagePath) as Sprite;
        }
        else
        {
            Game.setCommentsEnabled(false);
            GetComponent<Canvas>().enabled = false;
        }
    }

    private void skipAllComments()
    {
        Game.setCommentsEnabled(false);
        GetComponent<Canvas>().enabled = false;
    }


}
