using System;
using System.Collections.Generic;
using System.Text;
public class Scripture
{
    private List<Word> _words;
    private Reference _reference;


    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split().Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide){

        var random = new Random();

        for (int i = 0; i < numberToHide; i++) 
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText() {

        StringBuilder displayText = new StringBuilder(); // stringbuilder helps modify strings variable which make it posible to work with the foreach
        
        foreach (Word word in _words)
        {   
            displayText.Append(word.IsHidden() ? " _____ " : word.GetDisplayText());
            displayText.Append(" ");
            
            //atemp to not hide already hiding word //
            // if (word.GetDisplayText() == " _____ ") {
            //     displayText.Append(word.IsHidden() ? " _____ " : word.GetDisplayText());
            //     displayText.Append(" ");
            // }

        }
        return displayText.ToString().Trim();
    }

    public bool IsCompletelyHidden(){
        foreach (Word word in _words) {
            if (!word.IsHidden()){
                return false;
            }
        }
        return true;
    }
}