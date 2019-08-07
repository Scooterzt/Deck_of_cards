using System.Globalization;
using System;
using System.Collections.Generic;

namespace Deck_of_cards
{
    class Program
    {
        public class Card{// create class Card 
            public string stringVal{get;set;}
            public string suit{get;set;}
            public int val{get;set;}
            public Card(string Stringval, string Suit, int Val){ // Crad constractor!
                stringVal = Stringval;
                suit = Suit;
                val = Val;
            }

        }
        public class Deck{
            public List<Card> cards = new List<Card>(); // cards empty list

            public Deck(){   //COnstractor to create objects
                NewDeck();
            }
            public void NewDeck(){ // Method to create deck of cards
                 string[] suitarr = new string[4] {"Clubs", "Spades", "Hearts", "Diamonds"};
                 string[] valarr = new string[13] {"Ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "Jack", "Queen", "King"};
                 for(int i=0; i<valarr.Length;i++){
                     for(int j=0; j<suitarr.Length;j++){
                         Card newcard = new Card(valarr[i], suitarr[j], i+1);
                         cards.Add(newcard);
                    }
                }
            }
            public Card Deal(){ // method to take card by player
                Card deal = cards[0];
                cards.RemoveAt(0);
                return deal;
            }
            public void Reset(){ // method to reset deck of cards with return newdeck
                cards.Clear();
                NewDeck();
            }
            public void Shuffle(){ // shuffle cards in deck of cards
                Random rand = new Random();
                for(int i = cards.Count -1; i>0; i--){
                    int  n = rand.Next(i+1);
                    Card temp = cards[i]; // Card object like int or string
                    cards[i] = cards[n];
                    cards[n] = temp;
                }
            }
        }
        public class Player{
            public string name {get; set;}
            List<Card> hand {get; set;} = new List<Card>();
            public Card Draw(Deck deckdraw){ // method to get card from deck and add it ti player cards
                Card newCard = deckdraw.Deal();
                hand.Add(newCard); 
                return newCard;
            }
            public Card Discard(int index){ // Method remove cards from player hends
                if(index > hand.Count-1){
                    return null;
                }
                Card card = hand[index];
                hand.RemoveAt(index); 
                return card;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Deck of Cards");
            Deck deckOfCards = new Deck();
            Player tester = new Player();
            deckOfCards.Shuffle();
            Console.WriteLine(tester.Draw(deckOfCards).stringVal);
            Console.WriteLine(tester.Draw(deckOfCards));
            Console.WriteLine(tester.Draw(deckOfCards));
            Console.WriteLine(tester.Discard(2));
        }
    }
}
