using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuoteList 
{
    public string chosenQuote = "";
    protected string[] quoteList;
    protected virtual void SaveQuote()
    {

    }
    protected void RandomizeQuote()
    {

    }
}

public class PlayerLocationStatusQuoteList : QuoteList
{
    protected override void SaveQuote()
    {
        quoteList = new string[1];
    }
}
