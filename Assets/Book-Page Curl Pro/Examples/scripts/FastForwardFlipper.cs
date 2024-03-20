using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BookCurlPro;
namespace BookCurlPro.Examples
{
    public class FastForwardFlipper : MonoBehaviour
    {
        public AutoFlip flipper;
        BookPro book;
        public InputField pageNumInputField;
        public void GotoPage()
        {
            int pageNum = int.Parse(pageNumInputField.text);
            if (pageNum < 0) pageNum = 0;
            if (pageNum > flipper.ControledBook.papers.Length * 2) pageNum = flipper.ControledBook.papers.Length * 2 - 1;
            flipper.enabled = true;
            flipper.PageFlipTime = 0.2f;
            flipper.TimeBetweenPages = 0;
            flipper.StartFlipping((pageNum + 1) / 2);
        }
    }
}