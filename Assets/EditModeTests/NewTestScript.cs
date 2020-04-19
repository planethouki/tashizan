using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Compilation;
using UnityEngine.TestTools;
using UnityEngine;

namespace EditModeTests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        [Test]
        public void CardGenerate()
        {
            var cards = Card.GenerateFullSet(52);
            Assert.That(cards.Length, Is.EqualTo(52));
            Assert.That(cards[0].Number, Is.EqualTo(1));
            Assert.That(cards[0].Mark, Is.EqualTo("Spade"));
            Assert.That(cards[13].Number, Is.EqualTo(1));
            Assert.That(cards[13].Mark, Is.EqualTo("Clover"));
            Assert.That(cards[26].Number, Is.EqualTo(1));
            Assert.That(cards[26].Mark, Is.EqualTo("Heart"));
            Assert.That(cards[39].Number, Is.EqualTo(1));
            Assert.That(cards[39].Mark, Is.EqualTo("Dia"));
            Assert.That(cards[51].Number, Is.EqualTo(13));
            Assert.That(cards[51].Mark, Is.EqualTo("Dia"));
        }

        [Test]
        public void CardShuffle()
        {
            var cards = Card.Shuffle(Card.GenerateFullSet(52));
            Assert.That(cards.Length, Is.EqualTo(52));
            var markStats = new Dictionary<string, int>();
            var numStats = new Dictionary<int, int>();
            markStats["Spade"] = 0;
            markStats["Heart"] = 0;
            markStats["Clover"] = 0;
            markStats["Dia"] = 0;
            for (int i = 1; i <= 13; i++)
            {
                numStats[i] = 0;
            }
            for (int i = 0; i < cards.Length; i++)
            {
                markStats[cards[i].Mark]++;
                numStats[cards[i].Number]++;
            }
            
            Assert.That(markStats["Spade"], Is.EqualTo(13));
            Assert.That(markStats["Heart"], Is.EqualTo(13));
            Assert.That(markStats["Clover"], Is.EqualTo(13));
            Assert.That(markStats["Dia"], Is.EqualTo(13));
            for (int i = 1; i <= 13; i++)
            {
                Assert.That(numStats[i], Is.EqualTo(4));
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
