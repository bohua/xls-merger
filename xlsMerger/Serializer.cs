using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace XlsMerger
{
    public class Serializer
    {
        public Serializer()
        {
        }

        public void SerializeObject(string filename, ObjectToSerialize objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public ObjectToSerialize DeSerializeObject(string filename)
        {
            ObjectToSerialize objectToSerialize;
            if (!File.Exists(filename)) {
                return null;
            }
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            try
            {
                objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
                stream.Close();
                return objectToSerialize;
            }catch(Exception ex){
                return null;
            }
            
        }
    }

	/*
    [Serializable()]
    public class ObjectToSerialize : ISerializable
    {
        private List<RukuSheet> rukuSheets;

        public List<RukuSheet> RukuSheets
        {
            get { return this.rukuSheets; }
            set { this.rukuSheets = value; }
        }

        public ObjectToSerialize()
        {
        }

        public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            this.rukuSheets = (List<RukuSheet>)info.GetValue("RukuSheets", typeof(List<RukuSheet>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("RukuSheets", this.rukuSheets);
        }
    }*/

	[Serializable()]
	public class ObjectToSerialize : ISerializable
	{
		private RukuPrintSheet rukuPrintSheet;

		public RukuPrintSheet RukuPrintSheet
		{
			get { return this.rukuPrintSheet; }
			set { this.rukuPrintSheet = value; }
		}

		public ObjectToSerialize()
		{
		}

		public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
		{
			this.rukuPrintSheet = (RukuPrintSheet)info.GetValue("RukuPrintSheet", typeof(RukuPrintSheet));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("RukuPrintSheet", this.rukuPrintSheet);
		}
	}
}