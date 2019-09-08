using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Object_Change_Tracker;

namespace Object_Change_Tracker.Tests
{
    public class Change_Tests
    {
        private const string objName = "Test Object";
        private const string propChange = "Name";
        private const string oldVal = "Marco";
        private const string newVal = "Polo";
        private const string changedBy = "Kyle";
        private static readonly DateTime date = new DateTime(2018, 1, 14);

        [Fact]
        public void TestSetAndGetObjectName()
        {
            var sut = new Change();

            sut.ObjectName = objName;

            Assert.Equal(objName, sut.ObjectName);
        }

        [Fact]
        public void TestSetAndGetPropertyChanged()
        {
            var sut = new Change();

            sut.PropertyChanged = propChange;

            Assert.Equal(propChange, sut.PropertyChanged);
        }

        [Fact]
        public void TestSetAndGetOldValue()
        {
            var sut = new Change();

            sut.OldValue = oldVal;

            Assert.Equal(oldVal, sut.OldValue);
        }

        [Fact]
        public void TestSetAndGetNewValue()
        {
            var sut = new Change();

            sut.NewValue = newVal;

            Assert.Equal(newVal, sut.NewValue);
        }

        [Fact]
        public void TestSetAndGetChangedBy()
        {
            var sut = new Change
            {
                ChangedBy = changedBy
            };

            Assert.Equal(changedBy, sut.ChangedBy);
        }

        [Fact]
        public void TestSetAndGetTimeStamp()
        {
            var sut = new Change
            {
                TimeStamp = date
            };

            Assert.Equal(date, sut.TimeStamp);
        }

        [Fact]
        public void ConstructorTest()
        {
            DateTime dateTime = new DateTime(2019, 3, 4, 11, 27, 44);
            Change referenceChange = new Change();
            referenceChange.ObjectName = "SampleObject";
            referenceChange.ObjectID = 42;
            referenceChange.PropertyChanged = "Property";
            referenceChange.OldValue = "Prop1";
            referenceChange.NewValue = "Property1";
            referenceChange.ChangedBy = "The Dude";
            referenceChange.TimeStamp = dateTime;

            var sut = new Change(referenceChange.ObjectName, 
                                 referenceChange.ObjectID,
                                 referenceChange.PropertyChanged, 
                                 referenceChange.OldValue,
                                 referenceChange.NewValue, 
                                 referenceChange.ChangedBy, 
                                 referenceChange.TimeStamp);

            Assert.Equal(referenceChange.ObjectName, sut.ObjectName);
            Assert.Equal(referenceChange.ObjectID, sut.ObjectID);        
            Assert.Equal(referenceChange.PropertyChanged, sut.PropertyChanged);
            Assert.Equal(referenceChange.OldValue, sut.OldValue);
            Assert.Equal(referenceChange.NewValue, sut.NewValue);
            Assert.Equal(referenceChange.ChangedBy, sut.ChangedBy);
            Assert.Equal(referenceChange.TimeStamp, sut.TimeStamp);
        }

        [Fact]
        public void DefaultConstructorTest()
        {
            var sut = new Change();

            Assert.Equal("", sut.ObjectName);
            Assert.Equal(-1, sut.ObjectID);
            Assert.Equal("", sut.PropertyChanged);
            Assert.Equal("", sut.OldValue);
            Assert.Equal("", sut.NewValue);
            Assert.Equal("", sut.ChangedBy);
            Assert.Equal(DateTime.MinValue, sut.TimeStamp);
        }
    }
}
