using System;
using System.Collections.Generic;

namespace Object_Change_Tracker
{
    public class ChangeDetector
    {
        List<Change> changes;
        Change change;

        public ChangeDetector()
        {
            changes = new List<Change>();
        }

        public List<Change> GetChanges(object OriginalObject, object ChangedObject, string UpdatedBy, DateTime Timestamp)
        {
            // get the name of the object
            string objectName = ChangedObject.GetType().Name;

            // loop through the properties for this object and record the changes
            foreach(System.Reflection.PropertyInfo prop in ChangedObject.GetType().GetProperties())
            {
                //Only handle properties that are of "standard" types (i.e. string, integer, datetime, boolean, etc.) and are not read-only
                //Custom properties (also known as complex properties) should be handled individually by calling WriteChange directly
                //Also, don't write changes for those properties we don't care about (NoChangeLogProperties)
                if(prop.PropertyType.Namespace != null &&
                    prop.PropertyType.Namespace == "System" &&
                    prop.CanWrite)
                {
                    change = getChangeObject(objectName,
                        int.Parse(ChangedObject.GetType().GetProperty("ID").GetValue(ChangedObject, null).ToString()),
                        prop.Name,
                        OriginalObject.GetType().GetProperty(prop.Name).GetValue(OriginalObject, null) == null ? "" : OriginalObject.GetType().GetProperty(prop.Name).GetValue(OriginalObject, null).ToString(),
                        ChangedObject.GetType().GetProperty(prop.Name).GetValue(ChangedObject, null) == null ? "" : ChangedObject.GetType().GetProperty(prop.Name).GetValue(ChangedObject, null).ToString(),
                        UpdatedBy,
                        Timestamp);

                    if(change != null)
                    {
                        changes.Add(change);
                    }
                }
            }

            return changes;
        }

        Change getChangeObject(string objectName, int objectID, string property, string oldValue, string newValue, string changedBy, DateTime timestamp)
        {
            // handle null dates
            if(oldValue == "1/1/0001 12:00:00 AM")
            {
                oldValue = "";
            }

            if(newValue == "1/1/0001 12:00:00 AM")
            {
                newValue = "";
            }

            if (oldValue != newValue)
            {
                Change change = new Change(objectName, objectID, property, oldValue, newValue, changedBy, timestamp);
                return change;
            }

            return null;
        }
    }
}
