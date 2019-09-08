using System;
using System.Collections.Generic;
using Xunit;

namespace Object_Change_Tracker.Tests
{
    public class ChangeDetector_Tests
    {
        private SimplePoco originalObject;
        private SimplePoco changedObject;
        private SimplePocoNoID noIdOriginal;
        private SimplePocoNoID noIdChanged;
        private static readonly DateTime date = new DateTime(2019, 3, 5, 11, 27, 48);
        private static ChangeDetector sut;
        
        public ChangeDetector_Tests()
        {
            sut = new ChangeDetector();

            originalObject = new SimplePoco() { ID = 30, name = "Name", boolean = true, date = DateTime.MinValue, number = 42 };
            changedObject = new SimplePoco() { ID = 30, name = "Kyle", boolean = true, date = DateTime.MinValue, number = 42 };
        }

        [Fact]
        public void PocoWithNoID()
        {
            noIdOriginal = new SimplePocoNoID() { name = "Name", boolean = true, date = DateTime.MinValue, number = 42 };
            noIdChanged = new SimplePocoNoID() { name = "Kyle", boolean = true, date = DateTime.MinValue, number = 42 };

            List<Change> result = sut.GetChanges(noIdOriginal, noIdChanged, "Kyle", date);

            Assert.Single(result);
        }

        [Fact]
        public void SimplePocoSingleChange()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);

            Assert.Single(result);
        }

        [Fact]
        public void NewValueSetTest()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);

            Assert.Equal("Kyle", result[0].NewValue);
        }

        [Fact]
        public void OldValueSetTest()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);

            Assert.Equal("Name", result[0].OldValue);
        }

        [Fact]
        public void PropertyChangedSetTest()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);

            Assert.Equal("name", result[0].PropertyChanged);
        }
        [Fact]
        public void DateSetTest()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);
            Assert.Equal(date, result[0].TimeStamp);
        }
        [Fact]
        public void ObjectNameTest()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);

            Assert.Equal("SimplePoco", result[0].ObjectName);
        }

        [Fact]
        public void ChangedByTest()
        {
            List<Change> result = sut.GetChanges(originalObject, changedObject, "Kyle", date);

            Assert.Equal("Kyle", result[0].ChangedBy);
        }

        [Fact]
        public void SimplePocoMultipleChanges()
        {
            var old = new SimplePoco() { ID = 30, name = "Name", boolean = true, date = DateTime.MinValue, number = 42 };
            var changed = new SimplePoco() { ID = 30, name = "Kyle", boolean = false, date = DateTime.MinValue, number = 42 };

            List<Change> result = sut.GetChanges(old, changed, "Kyle", date);

            Assert.Equal(2, result.Count);
        }
    }

    class SimplePoco
    {
        public int ID { get; set; }

        public string name { get; set; }

        public int number { get; set; }

        public bool boolean { get; set; }

        public DateTime date { get; set; }

        public SimplePoco()
        {
            ID = -1;
            name = "";
            number = -1;
            boolean = true;
            date = DateTime.MinValue;
        }
    }

    class SimplePocoNoID
    {
        public string name { get; set; }

        public int number { get; set; }

        public bool boolean { get; set; }

        public DateTime date { get; set; }

        public SimplePocoNoID()
        {
            name = "";
            number = -1;
            boolean = true;
            date = DateTime.MinValue;
        }
    }
}
