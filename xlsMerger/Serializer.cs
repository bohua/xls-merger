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

		public void SerializeRukuObject(string filename, RukuToSerialize objectToSerialize)
		{
			Stream stream = File.Open(filename, FileMode.Create);
			BinaryFormatter bFormatter = new BinaryFormatter();
			bFormatter.Serialize(stream, objectToSerialize);
			stream.Close();
		}

		public RukuToSerialize DeSerializeRukuObject(string filename)
		{
			RukuToSerialize objectToSerialize;
			if (!File.Exists(filename))
			{
				return null;
			}
			Stream stream = File.Open(filename, FileMode.Open);
			BinaryFormatter bFormatter = new BinaryFormatter();
			try
			{
				objectToSerialize = (RukuToSerialize)bFormatter.Deserialize(stream);
				stream.Close();
				return objectToSerialize;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public void SerializeChukuObject(string filename, ChukuToSerialize objectToSerialize)
		{
			Stream stream = File.Open(filename, FileMode.Create);
			BinaryFormatter bFormatter = new BinaryFormatter();
			bFormatter.Serialize(stream, objectToSerialize);
			stream.Close();
		}

		public ChukuToSerialize DeSerializeChukuObject(string filename)
		{
			ChukuToSerialize objectToSerialize;
			if (!File.Exists(filename))
			{
				return null;
			}
			Stream stream = File.Open(filename, FileMode.Open);
			BinaryFormatter bFormatter = new BinaryFormatter();
			try
			{
				objectToSerialize = (ChukuToSerialize)bFormatter.Deserialize(stream);
				stream.Close();
				return objectToSerialize;
			}
			catch (Exception ex)
			{
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
	public class RukuToSerialize : ISerializable
	{
		private RukuPrintSheet rukuPrintSheet;

		public RukuPrintSheet RukuPrintSheet
		{
			get { return this.rukuPrintSheet; }
			set { this.rukuPrintSheet = value; }
		}

		public RukuToSerialize()
		{
		}

		public RukuToSerialize(SerializationInfo info, StreamingContext ctxt)
		{
			this.rukuPrintSheet = (RukuPrintSheet)info.GetValue("RukuPrintSheet", typeof(RukuPrintSheet));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("RukuPrintSheet", this.rukuPrintSheet);
		}
	}

	[Serializable()]
	public class ChukuToSerialize : ISerializable
	{
		private ChukuPrintSheet chukuPrintSheet;

		public ChukuPrintSheet ChukuPrintSheet
		{
			get { return this.chukuPrintSheet; }
			set { this.chukuPrintSheet = value; }
		}

		public ChukuToSerialize()
		{
		}

		public ChukuToSerialize(SerializationInfo info, StreamingContext ctxt)
		{
			this.chukuPrintSheet = (ChukuPrintSheet)info.GetValue("ChukuPrintSheet", typeof(ChukuPrintSheet));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ChukuPrintSheet", this.chukuPrintSheet);
		}
	}
}