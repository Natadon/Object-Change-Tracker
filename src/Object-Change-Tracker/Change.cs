using System;

namespace Object_Change_Tracker
{
    public class Change
    {
        /// <summary>
        /// ID that can be used for saving the data in Entity Framework
        /// </summary>
        public int ID { get; set; }

        public string ObjectName { get; set; }

        public int ObjectID { get; set; }

        public string PropertyChanged { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string ChangedBy { get; set; }

        public DateTime TimeStamp { get; set; }

        public Change()
        {
            ObjectName = "";
            ObjectID = -1;
            PropertyChanged = "";
            OldValue = "";
            NewValue = "";
            ChangedBy = "";
            TimeStamp = DateTime.MinValue;
        }

        public Change(string ObjectName, int ObjectID, string PropertyChanged, string OldValue, string NewValue, string ChangedBy, DateTime TimeStamp)
        {
            this.ObjectName = ObjectName;
            this.ObjectID = ObjectID;
            this.PropertyChanged = PropertyChanged;
            this.OldValue = OldValue;
            this.NewValue = NewValue;
            this.ChangedBy = ChangedBy;
            this.TimeStamp = TimeStamp;
        }
    }
}
