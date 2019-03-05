using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Object_Change_Tracker.Tests
{
    public class ChangeDetector_Tests
    {
        [Fact]
        public void SimplePocoSingleChange()
        {
            var sut = new ChangeDetector();

            var old = new SimplePoco() { ID = 30, name = "Name", boolean = true, date = DateTime.MinValue, number = 42 };
            var changed = new SimplePoco() { ID = 30, name = "Kyle", boolean = true, date = DateTime.MinValue, number = 42 };
            DateTime date = new DateTime(2019, 3, 5, 11, 27, 48);

            List<Change> result = sut.GetChanges(old, changed, "Kyle", date);

            Assert.Single(result);
            var item = result[0];

            Assert.Equal(30, item.ObjectID);
            Assert.Equal("SimplePoco", item.ObjectName);
            Assert.Equal("Kyle", item.ChangedBy);
            Assert.Equal(date, item.TimeStamp);
            Assert.Equal("name", item.PropertyChanged);
            Assert.Equal("Name", item.OldValue);
            Assert.Equal("Kyle", item.NewValue);
        }

        [Fact]
        public void SimplePocoMultipleChanges()
        {
            var sut = new ChangeDetector();

            var old = new SimplePoco() { ID = 30, name = "Name", boolean = true, date = DateTime.MinValue, number = 42 };
            var changed = new SimplePoco() { ID = 30, name = "Kyle", boolean = false, date = DateTime.MinValue, number = 42 };
            DateTime date = new DateTime(2019, 3, 5, 11, 27, 48);

            List<Change> result = sut.GetChanges(old, changed, "Kyle", date);

            Assert.Equal(2, result.Count);
            //var item = result[1];
            
            //Assert.Equal(30, item.ObjectID);
            //Assert.Equal("SimplePoco", item.ObjectName);
            //Assert.Equal("Kyle", item.ChangedBy);
            //Assert.Equal(date, item.TimeStamp);
            //Assert.Equal("name", item.PropertyChanged);
            //Assert.Equal("Name", item.OldValue);
            //Assert.Equal("Kyle", item.NewValue);

            //item = result[0];

            //Assert.Equal(30, item.ObjectID);
            //Assert.Equal("SimplePoco", item.ObjectName);
            //Assert.Equal("Kyle", item.ChangedBy);
            //Assert.Equal(date, item.TimeStamp);
            //Assert.Equal("boolean", item.PropertyChanged);
            //Assert.Equal("true", item.OldValue);
            //Assert.Equal("false", item.NewValue);
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
}
