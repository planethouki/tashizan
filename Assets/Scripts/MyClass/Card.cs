using System;

public class Card
{
        public int Number;
        public string Mark;
        
        public Card(int number, int markIndex)
        {
                if (markIndex == 0)
                {
                        this.Mark = "Spade";                        
                }
                else if (markIndex == 1)
                {
                        this.Mark = "Clover";
                }
                else if (markIndex == 2)
                {
                        this.Mark = "Heart";
                }
                else if (markIndex == 3)
                {
                        this.Mark = "Dia";
                }
                
                this.Number = number;
        }

        public static Card[] GenerateFullSet(int numCard)
        {
                var cards = new Card[numCard];
                for (int i = 0; i < numCard; i++)
                {
                        cards[i] = new Card((i % 13) + 1, i / 13);
                }

                return cards;
        }
        
        public static Card[] Shuffle(Card[] cards)
        {
                Random rnd = new Random();
                for (int i = 0; i < cards.Length; i++)
                {
                        int n = rnd.Next(cards.Length);
                        Card tmp = cards[n];
                        cards[n] = cards[i];
                        cards[i] = tmp;
                }

                return cards;
        }
}