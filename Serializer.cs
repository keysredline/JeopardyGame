using System;
//Dev: Justin F
//Date: 12/03/2021
//Class: 151
//Script: Jeopardy 
//using statements for serialization
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Jeopardy
{
    /// <summary>
    /// this class will serialize and de-serialize person objects
    /// </summary>
    static class Serializer
    {
        public static string SerializeNow(Player myPerson)
        {
            //setup a memory stream object that is needed
            //to hold the obj in memory during the
            //format and transformation process
            MemoryStream myStream = new MemoryStream();

            //setup the binary formatting obj that
            //performs the format process
            BinaryFormatter myFormat = new BinaryFormatter();

            //we call the serailize method, passing the
            //stream so we know where to save and obj it
            //will transform
            myFormat.Serialize(myStream, myPerson);

            //now that the obj is serialized, covert to
            //Base64 for encoding and easy storage
            string serializedValue = Convert.ToBase64String(myStream.ToArray());
            //close the stream
            myStream.Close();
            //call the Insert method of the DA class
            //DataAdapter.Insert(serializedValue);

            // return the serialized data
            return serializedValue;
        }
        public static object DeSerializeNow(string encodedData)
        {
            //create a generic object to hold the object
            //since we don't know the type of the obj yet
            object type;

            //create a stream and binary formatter
            //to reverse the encoding and give the
            //stream the incoming data
            MemoryStream myStream = new MemoryStream(Convert.FromBase64String(encodedData));
            BinaryFormatter myFormat = new BinaryFormatter();

            //deserialize what we have in memory into
            //the generic object
            type = myFormat.Deserialize(myStream);

            //test what type of object it is
            if (type.GetType().Name == "Person")
            {
                //its a person!
                Player myPerson = (Player)type;
                // we could do some stuff with the Person object here, but it really isn't the correct place

            }

            //close the stream
            myStream.Close();

            return type;
        }
    }//
}
