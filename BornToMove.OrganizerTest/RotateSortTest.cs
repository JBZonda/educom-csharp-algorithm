using BornToMove.DAL;
using NUnit.Framework;
using Organizer;

namespace BornToMove.OrganizerTest
{
    [TestFixture]
    public class RotateSortTest
    {

        [Test]
        public void testSortEmpty()
        {

            RotateSort<int> sorter = new RotateSort<int>();
            List<int> input = new List<int>();

            var result = sorter.Sort(input, Comparer<int>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(input));
        }

        [Test]
        public void testSortOneElement() {
            RotateSort<int> sorter = new RotateSort<int>();
            List<int> input = new List<int>() { 5 };

            var result = sorter.Sort(input, Comparer<int>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(1).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 5 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 5 }));

        }

        [Test]
        public void testSortTwoElements()
        {
            RotateSort<int> sorter = new RotateSort<int>();
            List<int> input = new List<int> { 72, 5 };

            var result = sorter.Sort(input, Comparer<int>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(2).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 5, 72 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 72, 5 }));

        }

        [Test]
        public void testSortThreeEqual()
        {
            RotateSort<int> sorter = new RotateSort<int>();
            List<int> input = new List<int> { 5, 5, 5 };

            var result = sorter.Sort(input, Comparer<int>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(3).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 5, 5, 5 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 5, 5, 5 }));

        }

        [Test]
        public void testSortUnsortedArray()
        {
            RotateSort<int> sorter = new RotateSort<int>();
            List<int> input = new List<int> { 12, -10, 4 };

            var result = sorter.Sort(input, Comparer<int>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(3).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { -10, 4, 12 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 12, -10, 4 }));

        }

        [Test]
        public void testSortUnsortedArrayWithZero()
        {
            RotateSort<int> sorter = new RotateSort<int>();
            List<int> input = new List<int> { 12, 0, -10, 4, 0, 0 };

            var result = sorter.Sort(input, Comparer<int>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(6).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { -10, 0, 0, 0, 4, 12 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 12, 0, -10, 4, 0, 0 }));

        }

        [Test]
        public void testSortUnsortedArrayDouble()
        {
            RotateSort<double> sorter = new RotateSort<double>();
            List<double> input = new List<double> { 12.87, 0.0, -10.2, 44, 0.0, 0.2 };

            var result = sorter.Sort(input, Comparer<double>.Default);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(6).Items);
            Assert.That(result, Is.EquivalentTo(new double[] { -10.2, 0.0, 0.0, 0.2, 12.87, 44 }));
            Assert.That(input, Is.EquivalentTo(new double[] { 12.87, 0.0, -10.2, 44, 0.0, 0.2 }));

        }

        [Test]
        public void testSortUnsortedArrayMoveRating()
        {
            RotateSort<MoveRating> sorter = new RotateSort<MoveRating>();
            List<MoveRating> input = new List<MoveRating>();
            input.Add(new MoveRating() {
                Move = new Move() { Id = 1},
                Id =1,
                Rating=3.4,
                Vote=4.3
            });
            input.Add(new MoveRating()
            {
                Move = new Move() { Id = 1},
                Id = 2,
                Rating = 3.2,
                Vote = 2.5
            });

            var result = sorter.Sort(input, new RatingsConverter());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(2).Items);
            Assert.That(result[1].Vote, Is.EqualTo(2.5));
            Assert.That(result[0].Vote, Is.EqualTo(4.3));

        }
    }

}